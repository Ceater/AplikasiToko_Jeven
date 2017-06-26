Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleStaff
    Dim cmd As SqlCommand
    Function cekIDStaff(idstaff As String) As Boolean
        Dim result As Boolean = False
        Try
            constring.Open()
            cmd = New SqlCommand("select * from TbStaff where lower(IDstaff)=lower(@a)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", idstaff))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                result = False
            Else
                result = True
            End If
            constring.Close()
        Catch ex As Exception
            constring.Close()
            result = True
        End Try
        Return result
    End Function

    Sub insertStaff(idstaff As String, password As String, nama As String, alamat As String, notlp As String, hakakses As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into TbStaff Values(@a,@b,@c,@d,@e,@f)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", idstaff))
                .Add(New SqlParameter("@b", password))
                .Add(New SqlParameter("@c", nama))
                .Add(New SqlParameter("@d", alamat))
                .Add(New SqlParameter("@e", notlp))
                .Add(New SqlParameter("@f", hakakses))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub updateStaff(idstaff As String, password As String, nama As String, alamat As String, notlp As String, hakakses As String)
        Try
            constring.Open()
            cmd = New SqlCommand("update TbStaff set Password=@b, NamaStaff=@c, Alamat=@d, NoTlp=@e, HakAkses=@f where IDstaff=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", idstaff))
                .Add(New SqlParameter("@b", password))
                .Add(New SqlParameter("@c", nama))
                .Add(New SqlParameter("@d", alamat))
                .Add(New SqlParameter("@e", notlp))
                .Add(New SqlParameter("@f", hakakses))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub deleteStaff(idstaff As String)
        Try
            constring.Open()
            cmd = New SqlCommand("delete TbStaff where IDstaff=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", idstaff))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub
End Module