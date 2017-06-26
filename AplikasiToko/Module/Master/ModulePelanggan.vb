Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModulePelanggan
    Dim cmd As SqlCommand

    Sub insertPelanggan(nama As String, alamat As String, tlp As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into TbPelanggan Values(@a,@b,@c)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nama))
                .Add(New SqlParameter("@b", alamat))
                .Add(New SqlParameter("@c", tlp))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub updatePelanggan(nama As String, alamat As String, tlp As String, id As String)
        Try
            constring.Open()
            cmd = New SqlCommand("update TbPelanggan set NamaPelanggan=@a, TlpPelanggan=@b, AlamatPelanggan=@c where NoPelanggan=@d", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nama))
                .Add(New SqlParameter("@b", alamat))
                .Add(New SqlParameter("@c", tlp))
                .Add(New SqlParameter("@d", id))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub deletePelanggan(id As String)
        Try
            constring.Open()
            cmd = New SqlCommand("delete TbPelanggan where NoPelanggan=@d", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@d", id))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub
End Module