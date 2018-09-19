Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModulePembayaran
    Dim cmd As SqlCommand
    Function loadTagihan(searchMonth As Integer, searchYear As Integer, Optional keyword As String = "%") As ArrayList
        If keyword = "" Then
            keyword = "%"
        End If
        keyword = "%" & keyword & "%"
        Dim x As New ArrayList
        Try
            constring.Open()
            cmd = New SqlCommand("SELECT T.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal, H.GrandTotal - sum(T.UangBayar) as Kekurangan FROM HJual H, TbPembayaran T WHERE H.NoNotaJual = T.NoNotaJual AND MONTH(H.TglNota) = @a AND YEAR(H.TglNota) = @b AND T.NoNotaJual LIKE @c GROUP BY T.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal HAVING  (H.GrandTotal - sum(T.UangBayar)) <> 0 ORDER BY H.TglNota DESC;", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", searchMonth))
                .Add(New SqlParameter("@b", searchYear))
                .Add(New SqlParameter("@c", keyword))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read
                x.Add(reader.GetValue(0) & "---" & reader.GetValue(1) & "---" & reader.GetValue(2) & "---" & reader.GetValue(3) & "---" & reader.GetValue(4))
            End While
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
        Return x
    End Function

    Function cekNotaPembayaran()
        Dim temp As Double
        Try
            constring.Open()
            cmd = New SqlCommand("select NoNotaPembayaran from TbPembayaran order by NoNotaPembayaran desc", constring)
            temp = cmd.ExecuteScalar
            temp += 1
            constring.Close()
        Catch ex As Exception
            temp = 1
            constring.Close()
        End Try
        Return temp
    End Function

    Function getDetailTagihan(NomerNota As String)
        Dim x As String = ""
        Try
            constring.Open()
            cmd = New SqlCommand("SELECT T.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal, sum(T.UangBayar) as 'Pembayaran Diterima', ISNULL(CASE WHEN (Tp.SisaPiutang - TotalRetur) <= 0 THEN 0 ELSE Tp.SisaPiutang - TotalRetur END, 0) as Kekurangan, ISNULL(Tp.TotalRetur,0) as TotalRetur, Tp.SisaPiutang FROM  HJual H INNER JOIN TbPembayaran T ON H.NoNotaJual=T.NoNotaJual INNER JOIN TbPiutang Tp ON T.NoNotaJual=Tp.NoNotaJual WHERE H.NoNotaJual = '" & NomerNota & "' GROUP BY T.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal, Tp.TotalRetur, Tp.SisaPiutang;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            reader.Read()
            x = reader.GetValue(0) & "-" & reader.GetValue(1) & "-" & reader.GetValue(2) & "-" & reader.GetValue(3) & "-" & reader.GetValue(4) & "-" & reader.GetValue(5) & "-" & reader.GetValue(6) & "-" & reader.GetValue(7)
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
        Return x
    End Function
End Module