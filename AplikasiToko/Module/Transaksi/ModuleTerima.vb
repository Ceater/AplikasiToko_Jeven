Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleTerima
    Dim cmd As SqlCommand
    Sub insertHTerima(nota As String, tgl As String, idstaff As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into HTerima Values(@a,@b,@c)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", tgl))
                .Add(New SqlParameter("@c", idstaff))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertDTerima(nota As String, idbarang As String, namabarang As String, satuan As String, jumlah As Double)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into DTerima Values(@a,@b,@c,@d,@e)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", idbarang))
                .Add(New SqlParameter("@c", namabarang))
                .Add(New SqlParameter("@d", satuan))
                .Add(New SqlParameter("@e", jumlah))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Function cekNotaTerima(nota As String) As Boolean
        Dim temp As Boolean = False
        Try
            constring.Open()
            cmd = New SqlCommand("select NoNotaTerima from HTerima where NoNotaTerima=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                temp = True
            End If
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
        Return temp
    End Function

    Function getNotaTerima() As String
        Dim temp As String = ""
        Dim notaFormat, tglSkr As String
        tglSkr = String.Format("{0:ddMMyy}", DateTime.Now)
        Try
            constring.Open()
            notaFormat = "%" & tglSkr & "%"
            'cmd = New SqlCommand("select TOP 1 NoNotaJual from HJual order by NoNotaJual desc", constring)
            cmd = New SqlCommand("SELECT TOP 1 SUBSTRING(NoNotaTerima, 8, 4) as Nota FROM HTerima WHERE SUBSTRING(NoNotaTerima, 1, 7) LIKE '" & notaFormat & "' ORDER BY NoNotaTerima DESC;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                temp = CInt(reader.GetValue(0)) + 1
                If temp.Length = 1 Then
                    temp = "T" & tglSkr & "000" & temp
                ElseIf temp.Length = 2 Then
                    temp = "T" & tglSkr & "00" & temp
                ElseIf temp.Length = 3 Then
                    temp = "T" & tglSkr & "0" & temp
                Else
                    temp = "T" & tglSkr & temp
                End If
            Else
                temp = "T" & tglSkr & "0001"
            End If
            constring.Close()
        Catch ex As Exception
            temp = "T" & tglSkr & "0001"
            constring.Close()
        End Try
        Return temp
    End Function
End Module