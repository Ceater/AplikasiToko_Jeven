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

            cmd = New SqlCommand("Insert into TbMutasi(NoNota,Deskripsi,Keluar,Masuk,Date_i,User_i) VALUES(@a,@b,@c,@d,@e,@f,@g)", constring)
            Dim deskripsi As String = "Retur Jual-" & idbarang & "-" & nama
            With cmd.Parameters
                .Add(New SqlParameter("@a", NoReturJual))
                .Add(New SqlParameter("@b", deskripsi))
                .Add(New SqlParameter("@c", 0))
                .Add(New SqlParameter("@d", jumlah))
                .Add(New SqlParameter("@e", DateTime.Now))
                .Add(New SqlParameter("@f", userLogin))
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
        Dim notaFormat, tglSkr As String
        tglSkr = String.Format("{0:ddMMyy}", DateTime.Now)
        Try
            constring.Open()
            notaFormat = "%" & tglSkr & "%"
            'cmd = New SqlCommand("select TOP 1 NoNotaJual from HJual order by NoNotaJual desc", constring)
            cmd = New SqlCommand("SELECT TOP 1 SUBSTRING(NoNotaReturJual, 9, 4) as Nota FROM HReturJual WHERE SUBSTRING(NoNotaReturJual, 1, 8) LIKE '" & notaFormat & "' ORDER BY NoNotaReturJual DESC;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                temp = CInt(reader.GetValue(0)) + 1
                If temp.Length = 1 Then
                    temp = "RJ" & tglSkr & "000" & temp
                ElseIf temp.Length = 2 Then
                    temp = "RJ" & tglSkr & "00" & temp
                ElseIf temp.Length = 3 Then
                    temp = "RJ" & tglSkr & "0" & temp
                Else
                    temp = "RJ" & tglSkr & temp
                End If
            Else
                temp = "RJ" & tglSkr & "0001"
            End If
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            temp = "RJ" & tglSkr & "0001"
            constring.Close()
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
            cmd = New SqlCommand("SELECT CASE WHEN (ISNULL(sum(DRJ.Subtotal) - SisaPiutang, 0)) <= -1 THEN 0 ELSE ISNULL(sum(DRJ.Subtotal) - SisaPiutang, 0) END AS UangSudahRetur FROM HReturJual HRJ INNER JOIN DReturJual DRJ ON HRJ.NoNotaReturJual = DRJ.NoNotaReturJual  INNER JOIN TbPiutang Tb ON HRJ.NoNotaJual=Tb.NoNotaJual WHERE HRJ.NoNotaJual = '" & KodeNota & "' GROUP BY HRJ.NoNotaJual, SisaPiutang;", constring)
            x = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return x
    End Function
End Module