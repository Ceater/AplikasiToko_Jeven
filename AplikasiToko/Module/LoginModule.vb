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
                cmd = New SqlCommand("UPDATE TbConfig Set value1=@a1 WHERE keynote='Versi';", constring)
                With cmd.Parameters
                    .Add(New SqlParameter("@a1", VersiSekarang))
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
            constring.Close()
            If VersiSekarang <> temp Then
                doUpdate()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub doUpdate()
        constring.Open()
        cmd = New SqlCommand("
            CREATE TABLE DatabaseToko.dbo.TbMutasi(
	            NoMutasi int NOT NULL IDENTITY (1, 1),
	            NoNota varchar(50) NULL,
	            Deskripsi text NULL,
	            Keluar float(53) NULL,
	            Masuk float(53) NULL,
	            Stok float(53) NULL,
	            Date_i date NULL,
	            User_i varchar(MAX) NULL
	            )  ON [PRIMARY]
	             TEXTIMAGE_ON [PRIMARY]
            ALTER TABLE DatabaseToko.dbo.TbMutasi ADD CONSTRAINT
	            PK_TbMutasi PRIMARY KEY CLUSTERED(
	            NoMutasi) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
            ALTER TABLE DatabaseToko.dbo.TbMutasi SET (LOCK_ESCALATION = TABLE)
            DELETE FROM HTerima WHERE NoNotaTerima = 'T2408180001';
            DELETE FROM DTerima WHERE NoNotaTerima = 'T2408180001';", constring)
        cmd.ExecuteNonQuery()
        Dim stokAwal As New Dictionary(Of String, Double)
        cmd = New SqlCommand("SELECT 
	            KodeBarang, 
	            NamaBarang, 
	            Stok as 'Stok Sekarang', 
	            ISNULL((SELECT TOP 1 dter.Jumlah FROM DTerima dter WHERE dter.IDBarang = tbar.KodeBarang), 0) as 'Stok Awal'
            From TbBarang tbar;", constring)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read
            stokAwal.Add(reader.GetValue(0), dblConvertToVB(reader.GetValue(3)))
        End While
        reader.Close()
        cmd = New SqlCommand("SELECT H.TglNota, H.NoNotaJual AS 'Nomer Nota', D.IDBarang, D.NamaBarang, D.Jumlah 
            FROM HJual AS H INNER JOIN DJual AS D ON H.NoNotaJual = D.NoNotaJual
            UNION 
            SELECT HT.TglNota, HT.NoNotaTerima AS 'Nomer Nota', DT.IDBarang, DT.NamaBarang, DT.Jumlah 
            FROM HTerima AS HT INNER JOIN DTerima AS DT ON HT.NoNotaTerima = DT.NoNotaTerima 
            UNION 
            SELECT HRT.TglReturTerima, HRT.NoNotaReturTerima AS 'Nomer Nota', DRT.IDBarang, DRT.NamaBarang, DRT.Jumlah 
            FROM HReturTerima AS HRT INNER JOIN DReturTerima AS DRT ON HRT.NoNotaReturTerima = DRT.NoNotaReturTerima", constring)
        reader = cmd.ExecuteReader
        Dim sqlBatch As New Queue
        While reader.Read
            Dim nonota = "", deskripsi As String = ""
            Dim jKeluar = "0", jMasuk = "0", stokMut As String = "0"
            If (reader.GetValue(1).indexOf("J")) Then
                deskripsi = "Jual-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                jKeluar = reader.GetValue(4)
                stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) - dblConvertToVB(jKeluar)
                stokMut = stokAwal.Item(reader.GetValue(2))
            ElseIf (reader.GetValue(1).indexOf("T")) Then
                deskripsi = "Beli-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                jMasuk = reader.GetValue(4)
                stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) + dblConvertToVB(jMasuk)
                stokMut = stokAwal.Item(reader.GetValue(2))
            ElseIf (reader.GetValue(1).indexOf("RJ")) Then
                deskripsi = "Retur Jual-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                jMasuk = reader.GetValue(4)
                stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) + dblConvertToVB(jMasuk)
                stokMut = stokAwal.Item(reader.GetValue(2))
            ElseIf (reader.GetValue(1).indexOf("RT")) Then
                deskripsi = "Retur Beli-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                jKeluar = reader.GetValue(4)
                stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) - dblConvertToVB(jKeluar)
                stokMut = stokAwal.Item(reader.GetValue(2))
            End If
            nonota = SqlSafe(reader.GetValue(1))
            deskripsi = SqlSafe(deskripsi)
            jKeluar = jKeluar.Replace(",", ".")
            jMasuk = jMasuk.Replace(",", ".")
            stokMut = stokMut.Replace(",", ".")
            sqlBatch.Enqueue("Insert into TbMutasi(NoNota,Deskripsi,Keluar,Masuk,Date_i,User_i) VALUES('" & nonota & "', '" & deskripsi & "', " & jKeluar & ", " & jMasuk & ", " & stokMut & ", '" & DateTime.Now & "', 'System');")
        End While
        reader.Close()
        For Each r As String In sqlBatch
            Try
                cmd = New SqlCommand(r, constring)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(r)
            End Try
        Next
        constring.Close()
    End Sub
End Module
