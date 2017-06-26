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

    Sub insertDTerima(nota As String, idbarang As String, namabarang As String, satuan As String, jumlah As String)
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

        End Try
        Return temp
    End Function
End Module