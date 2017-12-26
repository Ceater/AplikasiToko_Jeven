Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleReturJual
    Function getDetailBarangJual(ByVal NoNota As String) As DataTable
        Dim result As New DataSet
        constring.Open()
        Dim cmd As String = "select DT.IDBarang, DT.NamaBarang, DT.Satuan, DT.HargaSatuan, DT.Jumlah, DT.Diskon, DT.Subtotal from HJual HT, DJual DT where HT.NoNotaJual = DT.NoNotaJual and HT.NoNotaJual = '" & NoNota & "' EXCEPT select DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.HargaSatuan, DRT.Jumlah, DRT.Diskon, DRT.Subtotal  from HReturJual HRT, DReturJual DRT where HRT.NoNotaReturJual = DRT.NoNotaReturJual and HRT.NoNotaJual = '" & NoNota & "'"
        SqlAdapter = New SqlDataAdapter(cmd, constring)
        SqlAdapter.Fill(result, "Hasil")
        constring.Close()
        Return result.Tables("Hasil")
    End Function

    Sub insertHReturJual(NoReturJual As String, NoNotaJual As String, Tgl As String, id As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into HReturJual values(@a,@b,@c,@d)", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", NoReturJual))
                cmd.Parameters.Add(New SqlParameter("@b", NoNotaJual))
                cmd.Parameters.Add(New SqlParameter("@c", Tgl))
                cmd.Parameters.Add(New SqlParameter("@d", id))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertDReturJual(NoReturJual As String, idbarang As String, nama As String, satuan As String, harga As String, jumlah As Integer, diskon As Integer, subtotal As Integer)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into DReturJual values(@a,@b,@c,@d,@e,@f,@g,@h)", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", NoReturJual))
                cmd.Parameters.Add(New SqlParameter("@b", idbarang))
                cmd.Parameters.Add(New SqlParameter("@c", nama))
                cmd.Parameters.Add(New SqlParameter("@d", satuan))
                cmd.Parameters.Add(New SqlParameter("@e", harga))
                cmd.Parameters.Add(New SqlParameter("@f", jumlah))
                cmd.Parameters.Add(New SqlParameter("@g", diskon))
                cmd.Parameters.Add(New SqlParameter("@h", subtotal))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Function cekNotaReturJual(nota As String) As Boolean
        Dim result As Boolean = False
        Try
            constring.Open()
            cmd = New SqlCommand("select NoNotaReturJual from HReturJual where NoNotaReturJual = @a", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", nota))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                result = True
            Else
                result = False
            End If
            constring.Close()
        Catch ex As Exception
            result = False
            constring.Close()
        End Try
        Return result
    End Function

    Function getNotaReturJual()
        Dim temp As String = ""
        Try
            constring.Open()
            cmd = New SqlCommand("select TOP 1 NoNotaReturJual from HReturJual order by NoNotaReturJual desc", constring)
            temp = CInt(cmd.ExecuteScalar.substring(2) + 1)
            If temp.Length = 1 Then
                temp = "RJ0000" & temp
            ElseIf temp.Length = 2 Then
                temp = "RJ000" & temp
            ElseIf temp.Length = 3 Then
                temp = "RJ00" & temp
            ElseIf temp.Length = 4 Then
                temp = "RJ0" & temp
            Else
                temp = "RJ" & temp
            End If
            constring.Close()
        Catch ex As Exception
            temp = "RJ00001"
            constring.Close()
        End Try
        Return temp
    End Function

    Function getNamaPelanggan(kodenota As String)
        Dim hsl As String
        constring.Open()
        cmd = New SqlCommand("select NamaPelanggan from HJual where NoNotaJual=@a", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@a", kodenota))
        End With
        hsl = cmd.ExecuteScalar
        constring.Close()
        Return hsl
    End Function
End Module