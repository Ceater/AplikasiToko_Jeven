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
        Try
            constring.Open()
            cmd = New SqlCommand("select TOP 1 NoNotaTerima from HTerima order by NoNotaTerima desc", constring)
            temp = CInt(cmd.ExecuteScalar.substring(1) + 1)
            If temp.Length = 1 Then
                temp = "T0000" & temp
            ElseIf temp.Length = 2 Then
                temp = "T000" & temp
            ElseIf temp.Length = 3 Then
                temp = "T00" & temp
            ElseIf temp.Length = 4 Then
                temp = "T0" & temp
            Else
                temp = "T" & temp
            End If
            constring.Close()
        Catch ex As Exception
            temp = "T00001"
            constring.Close()
        End Try
        Return temp
    End Function
End Module