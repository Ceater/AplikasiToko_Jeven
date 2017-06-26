Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleTransaksi
    Dim cmd As SqlCommand
    Sub insertHJual(nota As String, tgl As String, grandtot As Integer, pelanggan As String, idstaff As String)
        Try
            constring.Open()
            cmd = New SqlCommand("Insert into HJual values(@a,@b,@c,@d,@e)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", tgl))
                .Add(New SqlParameter("@c", grandtot))
                .Add(New SqlParameter("@d", pelanggan))
                .Add(New SqlParameter("@e", idstaff))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertDJual(nota As String, idbarang As String, namabarang As String, satuan As String, harga As Integer, jumlah As Integer, diskon As String, subtot As Integer)
        Try
            constring.Open()
            cmd = New SqlCommand("Insert into DJual values(@a,@b,@c,@d,@e,@f,@g,@h)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", idbarang))
                .Add(New SqlParameter("@c", namabarang))
                .Add(New SqlParameter("@d", satuan))
                .Add(New SqlParameter("@e", harga))
                .Add(New SqlParameter("@f", jumlah))
                .Add(New SqlParameter("@g", diskon))
                .Add(New SqlParameter("@h", subtot))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertPembayaran(nota As String, tgl As String, uangbayar As Integer)
        Try
            constring.Open()
            cmd = New SqlCommand("Insert into TbPembayaran values(@a,@b,@c)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", tgl))
                .Add(New SqlParameter("@c", uangbayar))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Function cekNotaJual(nota As String) As Boolean
        Dim temp As Boolean = False
        Try
            constring.Open()
            cmd = New SqlCommand("select NoNotaJual from HJual where NoNotaJual=@a", constring)
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
