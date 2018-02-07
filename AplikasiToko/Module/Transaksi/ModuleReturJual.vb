Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleReturJual
    Function getDetailBarangJual(ByVal NoNota As String) As DataTable
        Dim result As New DataSet
        constring.Open()
        Try
            Dim cmd As String = "select DJx.IDBarang, DJx.NamaBarang, DJx.Satuan, DJx.HargaSatuan, DJx.Jumlah - ISNULL((select sum(DRJ.Jumlah) From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0) as Jumlah, DJx.Diskon, ((DJx.Jumlah - ISNULL((select sum(DRJ.Jumlah) From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0))*(DJx.HargaSatuan-Diskon)) as Subtotal From HJual HJx, DJual DJx Where HJx.NoNotaJual=DJx.NoNotaJual and DJx.Jumlah <> ISNULL((select sum(DRJ.Jumlah) From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0) and HJx.NoNotaJual='" & NoNota & "'"
            SqlAdapter = New SqlDataAdapter(cmd, constring)
            SqlAdapter.Fill(result, "Hasil")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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

    Sub insertDReturJual(NoReturJual As String, idbarang As String, nama As String, satuan As String, harga As String, jumlah As Double, diskon As Double, subtotal As Double)
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
            'MsgBox(ex.ToString)
        End Try
        Return temp
    End Function

    Function getNamaPelanggan(kodenota As String)
        Dim hsl As String
        constring.Open()
        Try
            cmd = New SqlCommand("select NamaPelanggan from HJual where NoNotaJual=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", kodenota))
            End With
            hsl = cmd.ExecuteScalar
        Catch ex As Exception
            hsl = "-"
        End Try
        constring.Close()
        Return hsl
    End Function

    Function TotalUangSudahDiRetur(KodeNota As String)
        Dim x As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select ISNULL(sum(DRJ.Subtotal),0) from HReturJual HRJ, DReturJual DRJ where HRJ.NoNotaReturJual = DRJ.NoNotaReturJual and HRJ.NoNotaJual = '" & KodeNota & "'", constring)
            x = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return x
    End Function
End Module