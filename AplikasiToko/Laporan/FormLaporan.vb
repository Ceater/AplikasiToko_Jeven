﻿Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class FormLaporan
    Public LaporanNoNota As String = ""
    Public mode As String = ""
    Public tglAwal As Date
    Public tglAkhir As Date
    Public kodebarang As String = ""
    Public copyNota As String = ""
    Public detailNotaLuarKota() As String
    Dim Jenis As String = ""

    Public Sub New(ByVal laporan As String)
        InitializeComponent()
        Jenis = laporan
    End Sub

    Private Sub crv_Load(sender As Object, e As EventArgs) Handles crv.Load
        Try
            Dim con As SqlConnection
            con = constring
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()

            Dim adapt As New SqlDataAdapter
            Dim dataset As New DataSet

            adapt.SelectCommand = cmd
            dataset.Clear()
            Dim rep As New ReportDocument
            rep.PrintOptions.PrinterName = getPrinter()
            rep.PrintOptions.PaperSize = getPaperSize()
            If Jenis = "NotaPenjualan" Then
                cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.GrandTotal, H.NamaPelanggan, H.IDStaff, D.IDBarang, D.NamaBarang, D.Satuan, D.HargaSatuan, D.Jumlah, D.Diskon, D.Subtotal from HJual H, DJual D where H.NoNotaJual=D.NoNotaJual and H.NoNotaJual=@a"
                cmd.Parameters.AddWithValue("@a", LaporanNoNota)
                adapt.Fill(dataset, "Penjualan")
                rep = New NotaPenjualan
                rep.SetDataSource(dataset)
                rep.SetParameterValue("copyNota", copyNota)
                rep.PrintOptions.PrinterName = getPrinter()
                rep.PrintOptions.PaperSize = getPaperSize()
                rep.PrintToPrinter(1, False, 0, 0)
            ElseIf Jenis = "SuratJalan" Then
                cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.GrandTotal, H.NamaPelanggan, H.IDStaff, D.IDBarang, D.NamaBarang, D.Satuan, D.HargaSatuan, D.Jumlah, D.Diskon, D.Subtotal from HJual H, DJual D where H.NoNotaJual=D.NoNotaJual and H.NoNotaJual=@a"
                cmd.Parameters.AddWithValue("@a", LaporanNoNota)
                adapt.Fill(dataset, "Penjualan")
                rep = New SuratJalan
                rep.SetDataSource(dataset)
                rep.PrintOptions.PrinterName = getPrinter()
                rep.PrintOptions.PaperSize = getPaperSize()
                rep.PrintToPrinter(1, False, 0, 0)
            ElseIf Jenis = "NotaPembayaran" Then
                cmd.CommandText = "SELECT H.NoNotaJual, T.NoNotaPembayaran, H.TglNota,H.NamaPelanggan, H.GrandTotal, T.TglBayar, T.UangBayar from HJual H, TbPembayaran T WHERE H.NoNotaJual = T.NoNotaJual and H.NoNotaJual=@a"
                cmd.Parameters.AddWithValue("@a", LaporanNoNota)
                adapt.Fill(dataset, "Detailpembayaran")
                rep = New NotaPembayaran
                rep.SetDataSource(dataset)
                rep.PrintOptions.PrinterName = getPrinter()
                rep.PrintOptions.PaperSize = getPaperSize()
                rep.PrintToPrinter(1, False, 0, 0)
            ElseIf Jenis = "LaporanPenjualan" Then
                If mode = "1" Then
                    cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.GrandTotal, H.NamaPelanggan, H.IDStaff, D.IDBarang, D.NamaBarang, D.Satuan, D.HargaSatuan, D.Jumlah, D.Diskon, D.Subtotal from HJual H, DJual D where H.NoNotaJual=D.NoNotaJual"
                    adapt.Fill(dataset, "Penjualan")
                    rep = New LaporanPenjualan
                    rep.SetDataSource(dataset)
                ElseIf mode = "2" Then
                    cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.GrandTotal, H.NamaPelanggan, H.IDStaff, D.IDBarang, D.NamaBarang, D.Satuan, D.HargaSatuan, D.Jumlah, D.Diskon, D.Subtotal from HJual H, DJual D where H.NoNotaJual=D.NoNotaJual and H.TglNota BETWEEN @tglAwal AND @tglAkhir ORDER BY H.TglNota"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM/dd/yyyy") & " 00:00:00")
                    cmd.Parameters.AddWithValue("@tglakhir", tglAkhir.ToString("MM/dd/yyyy") & " 23:59:59")
                    adapt.Fill(dataset, "Penjualan")
                    rep = New LaporanPenjualan
                    rep.SetDataSource(dataset)
                Else
                    cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.GrandTotal, H.NamaPelanggan, H.IDStaff, D.IDBarang, D.NamaBarang, D.Satuan, D.HargaSatuan, D.Jumlah, D.Diskon, D.Subtotal from HJual H, DJual D where H.NoNotaJual=D.NoNotaJual and month(H.TglNota) = @tglawal ORDER BY H.TglNota"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM"))
                    adapt.Fill(dataset, "Penjualan")
                    rep = New LaporanPenjualan
                    rep.SetDataSource(dataset)
                End If
            ElseIf Jenis = "LaporanTerimaBarang" Then
                If mode = "1" Then
                    cmd.CommandText = "SELECT H.NoNotaTerima, H.TglNota, H.IDStaff, D.IDBarang, D.Namabarang, D.Satuan, D.Jumlah From HTerima H, DTerima D Where H.NoNotaTerima = D.NoNotaTerima"
                    adapt.Fill(dataset, "Penerimaan")
                    rep = New LaporanPenerimaan
                    rep.SetDataSource(dataset)
                ElseIf mode = "2" Then
                    cmd.CommandText = "SELECT H.NoNotaTerima, H.TglNota, H.IDStaff, D.IDBarang, D.Namabarang, D.Satuan, D.Jumlah From HTerima H, DTerima D Where H.NoNotaTerima = D.NoNotaTerima and H.TglNota BETWEEN @tglAwal AND @tglAkhir ORDER BY H.TglNota"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM/dd/yyyy") & " 00:00:00")
                    cmd.Parameters.AddWithValue("@tglakhir", tglAkhir.ToString("MM/dd/yyyy") & " 23:59:59")
                    adapt.Fill(dataset, "Penerimaan")
                    rep = New LaporanPenerimaan
                    rep.SetDataSource(dataset)
                ElseIf mode = "3" Then
                    cmd.CommandText = "SELECT H.NoNotaTerima, H.TglNota, H.IDStaff, D.IDBarang, D.Namabarang, D.Satuan, D.Jumlah From HTerima H, DTerima D Where H.NoNotaTerima = D.NoNotaTerima and month(H.TglNota) = @tglawal ORDER BY H.TglNota"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM"))
                    adapt.Fill(dataset, "Penerimaan")
                    rep = New LaporanPenerimaan
                    rep.SetDataSource(dataset)
                End If
            ElseIf Jenis = "StokOpname" Then
                cmd.CommandText = "SELECT H.TglNota, H.NoNotaJual AS 'Nomer Nota', D.IDBarang, D.NamaBarang, D.Jumlah FROM HJual AS H INNER JOIN DJual AS D ON H.NoNotaJual = D.NoNotaJual where D.IDBarang = @a UNION SELECT HT.TglNota, HT.NoNotaTerima AS 'Nomer Nota', DT.IDBarang, DT.NamaBarang, DT.Jumlah FROM HTerima AS HT INNER JOIN DTerima AS DT ON HT.NoNotaTerima = DT.NoNotaTerima where DT.IDBarang = @a UNION SELECT HRT.TglReturTerima, HRT.NoNotaReturTerima AS 'Nomer Nota', DRT.IDBarang, DRT.NamaBarang, DRT.Jumlah FROM HReturTerima AS HRT INNER JOIN DReturTerima AS DRT ON HRT.NoNotaReturTerima = DRT.NoNotaReturTerima where DRT.IDBarang = @a"
                cmd.Parameters.AddWithValue("@a", kodebarang)
                adapt.Fill(dataset, "StokOpName")
                rep = New LaporanStokOpname
                rep.SetDataSource(dataset)
            ElseIf Jenis = "LaporanPembayaran" Then
                cmd.CommandText = "SELECT H.NoNotaJual, T.NoNotaPembayaran, H.TglNota,H.NamaPelanggan, H.GrandTotal, T.TglBayar, T.UangBayar from HJual H, TbPembayaran T WHERE H.NoNotaJual = T.NoNotaJual"
                adapt.Fill(dataset, "Detailpembayaran")
                rep = New LaporanPembayaran
                rep.SetDataSource(dataset)
            ElseIf Jenis = "LaporanReturTerima" Then
                If mode = "1" Then
                    cmd.CommandText = "select HRT.NoNotaReturTerima, HRT.NoNotaTerima, HRT.TglReturTerima, HRT.IDStaff, DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.Jumlah from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima"
                    adapt.Fill(dataset, "ReturBarang")
                    rep = New LaporanReturTerima
                    rep.SetDataSource(dataset)
                ElseIf mode = "2" Then
                    cmd.CommandText = "select HRT.NoNotaReturTerima, HRT.NoNotaTerima, HRT.TglReturTerima, HRT.IDStaff, DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.Jumlah from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and HRT.TglReturTerima BETWEEN @tglAwal AND @tglAkhir ORDER BY HRT.TglReturTerima"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM/dd/yyyy") & " 00:00:00")
                    cmd.Parameters.AddWithValue("@tglakhir", tglAkhir.ToString("MM/dd/yyyy") & " 23:59:59")
                    adapt.Fill(dataset, "ReturBarang")
                    rep = New LaporanReturTerima
                    rep.SetDataSource(dataset)
                ElseIf mode = "3" Then
                    cmd.CommandText = "select HRT.NoNotaReturTerima, HRT.NoNotaTerima, HRT.TglReturTerima, HRT.IDStaff, DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.Jumlah from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and month(HRT.TglReturTerima) = @tglawal ORDER BY HRT.TglReturTerima"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM"))
                    adapt.Fill(dataset, "ReturBarang")
                    rep = New LaporanReturTerima
                    rep.SetDataSource(dataset)
                End If
            ElseIf Jenis = "LaporanReturJual" Then
                If mode = "1" Then
                    cmd.CommandText = "select HRT.NoNotaReturJual, HRT.NoNotaJual, HRT.TglReturJual, HRT.IDStaff, DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.HargaSatuan, DRT.Jumlah, DRT.Diskon, DRT.Subtotal from HReturJual HRT, DReturJual DRT where HRT.NoNotaReturJual = DRT.NoNotaReturJual"
                    adapt.Fill(dataset, "ReturJual")
                    rep = New LaporanReturJual
                    rep.SetDataSource(dataset)
                ElseIf mode = "2" Then
                    cmd.CommandText = "select HRT.NoNotaReturJual, HRT.NoNotaJual, HRT.TglReturJual, HRT.IDStaff, DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.HargaSatuan, DRT.Jumlah, DRT.Diskon, DRT.Subtotal from HReturJual HRT, DReturJual DRT where HRT.NoNotaReturJual = DRT.NoNotaReturJual and HRT.TglReturJual BETWEEN @tglAwal AND @tglAkhir ORDER BY HRT.TglReturJual"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM/dd/yyyy") & " 00:00:00")
                    cmd.Parameters.AddWithValue("@tglakhir", tglAkhir.ToString("MM/dd/yyyy") & " 23:59:59")
                    adapt.Fill(dataset, "ReturJual")
                    rep = New LaporanReturJual
                    rep.SetDataSource(dataset)
                ElseIf mode = "3" Then
                    cmd.CommandText = "select HRT.NoNotaReturJual, HRT.NoNotaJual, HRT.TglReturJual, HRT.IDStaff, DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.HargaSatuan, DRT.Jumlah, DRT.Diskon, DRT.Subtotal from HReturJual HRT, DReturJual DRT where HRT.NoNotaReturJual = DRT.NoNotaReturJual and month(HRT.TglReturJual) = @tglawal ORDER BY HRT.TglReturJual"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM"))
                    adapt.Fill(dataset, "ReturJual")
                    rep = New LaporanReturJual
                    rep.SetDataSource(dataset)
                End If
            ElseIf Jenis = "LaporanStokBarang" Then
                cmd.CommandText = "select b.kodebarang, b.namabarang, b.stok, s.namasatuan, b.harganormal, b.hargatoko, b.hargasales from tbbarang b, tbsatuan s where b.satuanbarang = s.kodesatuan"
                adapt.Fill(dataset, "DetailStokBarang")
                rep = New LaporanBarang
                rep.SetDataSource(dataset)
            ElseIf Jenis = "LaporanPembelian" Then
                If mode = "1" Then
                    cmd.CommandText = "select HP.NoPembelian, HP.NoNotaTerima, HP.GrandTotal, HP.TglBayar, DP.IDBarang, DP.NamaBarang, DP.Satuan, DP.HargaSatuan, DP.Jumlah, DP.Subtotal from HPembelian HP, DPembelian DP where HP.NoPembelian = DP.NoPembelian"
                    adapt.Fill(dataset, "Pembelian")
                    rep = New LaporanPembelian
                    rep.SetDataSource(dataset)
                ElseIf mode = "2" Then
                    cmd.CommandText = "select HP.NoPembelian, HP.NoNotaTerima, HP.GrandTotal, HP.TglBayar, DP.IDBarang, DP.NamaBarang, DP.Satuan, DP.HargaSatuan, DP.Jumlah, DP.Subtotal from HPembelian HP, DPembelian DP, HTerima HT where HP.NoPembelian = DP.NoPembelian and HP.NoNotaTerima = HT.NoNotaTerima and HT.TglNota BETWEEN @tglAwal AND @tglAkhir ORDER BY HT.TglNota"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM/dd/yyyy") & " 00:00:00")
                    cmd.Parameters.AddWithValue("@tglakhir", tglAkhir.ToString("MM/dd/yyyy") & " 23:59:59")
                    adapt.Fill(dataset, "ReturJual")
                    rep = New LaporanPembelian
                    rep.SetDataSource(dataset)
                ElseIf mode = "3" Then
                    cmd.CommandText = "select HP.NoPembelian, HP.NoNotaTerima, HP.GrandTotal, HP.TglBayar, DP.IDBarang, DP.NamaBarang, DP.Satuan, DP.HargaSatuan, DP.Jumlah, DP.Subtotal from HPembelian HP, DPembelian DP, HTerima HT where HP.NoPembelian = DP.NoPembelian and HP.NoNotaTerima = HT.NoNotaTerima and month(HT.TglNota) = @tglawal ORDER BY HT.TglNota"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM"))
                    adapt.Fill(dataset, "ReturJual")
                    rep = New LaporanPembelian
                    rep.SetDataSource(dataset)
                End If
            ElseIf Jenis = "LaporanPendapatan" Then
                If mode = "1" Then
                    cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal, sum(T.UangBayar) as UangBayar from HJual H, TbPembayaran T  WHERE H.NoNotaJual = T.NoNotaJual group by H.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal"
                    adapt.Fill(dataset, "DetailPembayaran")
                    rep = New LaporanPendapatan
                    rep.SetDataSource(dataset)
                ElseIf mode = 2 Then
                    cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal, sum(T.UangBayar) as UangBayar from HJual H, TbPembayaran T  WHERE H.NoNotaJual = T.NoNotaJual and H.TglNota BETWEEN @tglAwal AND @tglAkhir group by H.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM/dd/yyyy") & " 00:00:00")
                    cmd.Parameters.AddWithValue("@tglakhir", tglAkhir.ToString("MM/dd/yyyy") & " 23:59:59")
                    adapt.Fill(dataset, "DetailPembayaran")
                    rep = New LaporanPendapatan
                    rep.SetDataSource(dataset)
                ElseIf mode = 3 Then
                    cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal, sum(T.UangBayar) as UangBayar from HJual H, TbPembayaran T  WHERE H.NoNotaJual = T.NoNotaJual and month(H.TglNota) = @tglawal group by H.NoNotaJual, H.TglNota, H.NamaPelanggan, H.GrandTotal"
                    cmd.Parameters.AddWithValue("@tglawal", tglAwal.ToString("MM"))
                    adapt.Fill(dataset, "DetailPembayaran")
                    rep = New LaporanPendapatan
                    rep.SetDataSource(dataset)
                End If
            ElseIf Jenis = "SuratJalanLuarKota" Then
                rep = New SuratJalanLuarKota
                rep.SetParameterValue("NomerNota", detailNotaLuarKota(0))
                rep.SetParameterValue("TanggalNota", detailNotaLuarKota(1))
                rep.SetParameterValue("Penerima", detailNotaLuarKota(2))
                rep.SetParameterValue("KotaTujuan", detailNotaLuarKota(3))
                rep.SetParameterValue("JumlahBarang", detailNotaLuarKota(4))
                rep.SetParameterValue("DeskripsiBarang", detailNotaLuarKota(5))
                rep.PrintOptions.PrinterName = getPrinter()
                rep.PrintOptions.PaperSize = getPaperSize()
                rep.PrintToPrinter(1, False, 0, 0)
            End If
            con.Close()
            crv.ReportSource = rep
            crv.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Function getPrinter()
        Dim path As String = "C:\AplikasiToko\printer.txt"
        Dim x1 As String
        Dim sr As StreamReader = New StreamReader(path)
        x1 = sr.ReadLine()
        sr.Dispose()
        Return x1
    End Function

    Function getPaperSize()
        Dim path As String = "C:\AplikasiToko\printer.txt"
        Dim x1 As String
        Dim result As PaperSize
        Dim sr As StreamReader = New StreamReader(path)
        sr.ReadLine()
        x1 = sr.ReadLine()
        sr.Dispose()
        If x1 = "A4" Then
            result = PaperSize.PaperA4
        ElseIf x1 = "A5" Then
            result = PaperSize.PaperA5
        End If
        Return result
    End Function
End Class