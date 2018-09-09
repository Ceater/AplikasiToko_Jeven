Imports System.Data.Sql
Imports System.Data.SqlClient

Module LoginModule
    Function cekLogin(ByVal id As String, ByVal pw As String) As Boolean
        Dim x As Boolean = False
        constring.Open()
        cmd = New SqlCommand("select IDStaff from TbStaff where Lower(IDStaff)=@user and Password =@pw", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@user", id.ToLower))
            .Add(New SqlParameter("@pw", pw))
        End With
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.HasRows Then
            x = True
        End If
        constring.Close()
        Return x
    End Function

    Function getHAkses(ByVal id As String) As String
        Dim temp As String = ""
        Try
            constring.Open()
            cmd = New SqlCommand("select HakAkses from TbStaff where Lower(IDStaff)=@user", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@user", id.ToLower))
            End With
            temp = cmd.ExecuteScalar
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
        Return temp
    End Function

    Sub cekUpdate()
        Dim temp As String = ""
        Try
            constring.Open()
            'Cek versi saat ini
            cmd = New SqlCommand("SELECT value1 FROM TbConfig WHERE keynote='Versi'", constring)
            temp = cmd.ExecuteScalar
            If VersiSekarang <> temp Then
                'Jika database belum terupdate ke versi terbaru
                cmd = New SqlCommand("
                ALTER TABLE [TbPembayaran] ADD Date_i datetime;
                ALTER TABLE [TbPembayaran] ADD Date_u datetime;
                ALTER TABLE [TbPembayaran] ADD User_i varchar(100);
                ALTER TABLE [TbPembayaran] ADD User_u varchar(100);
                CREATE TABLE [dbo].[TbPiutang](
	                [NoNotaPiutang] [varchar](25) NOT NULL,
	                [NoNotaJual] [varchar](25) NULL,
	                [GrandTotal] [float] NULL,
	                [SisaPiutang] [float] NOT NULL,
	                [TotalRetur] [float] NOT NULL,
	                [Date_i] [datetime] NULL,
	                [Date_u] [datetime] NULL,
	                [User_i] [varchar](100) NULL,
	                [User_u] [varchar](100) NULL,
                 CONSTRAINT [PK_TbPiutang] PRIMARY KEY CLUSTERED 
                (
	                [NoNotaPiutang] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                ALTER TABLE [dbo].[TbPiutang] ADD  CONSTRAINT [DF_TbPiutang_SisaPiutang]  DEFAULT ((0)) FOR [SisaPiutang];
                ALTER TABLE [dbo].[TbPiutang] ADD  CONSTRAINT [DF_TbPiutang_TotalRetur]  DEFAULT ((0)) FOR [TotalRetur];
                UPDATE TbConfig Set value1=@a1 WHERE keynote='Versi';
                ", constring)
                With cmd.Parameters
                    .Add(New SqlParameter("@a1", VersiSekarang))
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                extraCommand()
            End If
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub extraCommand()
        Dim counter As Integer = 0
        Dim temp As String = ""
        Dim sqlBatch As String = ""
        cmd = New SqlCommand("SELECT HJ.TglNota, HJ.NoNotaJual, HJ.GrandTotal, SUM(TP.UangBayar) as UangBayar, (HJ.GrandTotal - SUM(TP.UangBayar)) as 'Kekurangan'
            FROM HJual HJ RIGHT JOIN TbPembayaran TP ON HJ.NoNotaJual=TP.NoNotaJual
            GROUP BY HJ.TglNota, HJ.NoNotaJual, HJ.GrandTotal ORDER BY HJ.TglNota DESC;", constring)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.HasRows Then
            While reader.Read
                Dim NoNotaPiutang As String = String.Format("{0:ddMMyy}", DateTime.Now)
                temp = CInt(counter) + 1
                If temp.Length = 1 Then
                    temp = "PT" & NoNotaPiutang & "000" & temp
                ElseIf temp.Length = 2 Then
                    temp = "PT" & NoNotaPiutang & "00" & temp
                ElseIf temp.Length = 3 Then
                    temp = "PT" & NoNotaPiutang & "0" & temp
                Else
                    temp = "PT" & NoNotaPiutang & temp
                End If
                Dim NoNotaJual = "", User_i = "", User_u As String = ""
                Dim GrandTotal = 0, SisaPiutang As Integer = 0

                temp = SqlSafe(temp)
                NoNotaJual = SqlSafe(reader.GetValue(1))
                GrandTotal = reader.GetValue(2)
                SisaPiutang = reader.GetValue(4)
                User_i = "System"

                sqlBatch &= "INSERT INTO TbPiutang(NoNotaPiutang, NoNotaJual, GrandTotal, SisaPiutang, Date_i, User_i) VALUES('" & temp & "', '" & NoNotaJual & "', " & GrandTotal & ", " & SisaPiutang & ", '" & DateTime.Now & "', '" & User_i & "');"
                counter += 1
            End While
            reader.Close()
            cmd = New SqlCommand(sqlBatch, constring)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("UPDATE TbPiutang SET TotalRetur = ISNULL((SELECT SUM(Subtotal) as GrandTotal FROM HReturJual HJ INNER JOIN DReturJual DJ ON HJ.NoNotaReturJual = DJ.NoNotaReturJual WHERE NoNotaJual = TbPiutang.NoNotaJual),0);", constring)
            cmd.ExecuteNonQuery()
        End If
    End Sub
End Module
