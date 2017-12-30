Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModulePelanggan
    Dim cmd As SqlCommand

    Sub insertPelanggan(nama As String, alamat As String, tlp As String, JenisPelanggan As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into TbPelanggan Values(@a,@b,@c,@d)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nama))
                .Add(New SqlParameter("@b", alamat))
                .Add(New SqlParameter("@c", tlp))
                .Add(New SqlParameter("@d", JenisPelanggan))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub updatePelanggan(nama As String, alamat As String, tlp As String, JenisPelanggan As String, id As String)
        Try
            constring.Open()
            cmd = New SqlCommand("update TbPelanggan set NamaPelanggan=@a, TlpPelanggan=@b, AlamatPelanggan=@c, TipePelanggan=@d where NoPelanggan=@e", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nama))
                .Add(New SqlParameter("@b", alamat))
                .Add(New SqlParameter("@c", tlp))
                .Add(New SqlParameter("@d", JenisPelanggan))
                .Add(New SqlParameter("@e", id))
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
            cmd = New SqlCommand("delete TbPelanggan where NoPelanggan=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", id))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub
End Module