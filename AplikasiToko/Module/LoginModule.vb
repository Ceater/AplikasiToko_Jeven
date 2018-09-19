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
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub
End Module
