Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FormLaporan
    Public LaporanNoNota As String = ""
    Public mode As String = ""
    Public tglAwal As Date
    Public tglAkhir As Date
    Public kodebarang As String = ""
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
            If Jenis = "NotaPenjualan" Then
                cmd.CommandText = "SELECT H.NoNotaJual, H.TglNota, H.GrandTotal, H.NamaPelanggan, H.IDStaff, D.IDBarang, D.NamaBarang, D.Satuan, D.HargaSatuan, D.Jumlah, D.Diskon, D.Subtotal from HJual H, DJual D where H.NoNotaJual=D.NoNotaJual and H.NoNotaJual=@a"
                cmd.Parameters.AddWithValue("@a", LaporanNoNota)
                adapt.Fill(dataset, "Penjualan")
                rep = New NotaPenjualan
                rep.SetDataSource(dataset)
                rep.PrintOptions.PrinterName = "HP Deskjet 1010 series"
                rep.PrintToPrinter(1, False, 0, 0)
            ElseIf Jenis = "NotaPembayaran" Then
                cmd.CommandText = "SELECT H.NoNotaJual, T.NoNotaPembayaran, H.TglNota,H.NamaPelanggan, H.GrandTotal, T.TglBayar, T.UangBayar from HJual H, TbPembayaran T WHERE H.NoNotaJual = T.NoNotaJual and H.NoNotaJual=@a"
                cmd.Parameters.AddWithValue("@a", LaporanNoNota)
                adapt.Fill(dataset, "Detailpembayaran")
                rep = New NotaPembayaran
                rep.SetDataSource(dataset)
                rep.PrintOptions.PrinterName = "HP Deskjet 1010 series"
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
                cmd.CommandText = "Select H.TglNota, H.NoNotaJual As 'Nomer Nota', D.IDBarang, D.NamaBarang, D.Jumlah From HJual As H INNER Join DJual As D On H.NoNotaJual = D.NoNotaJual where D.IDBarang = @a UNION Select HT.TglNota, HT.NoNotaTerima As 'Nomer Nota', DT.IDBarang, DT.NamaBarang, DT.Jumlah From HTerima As HT INNER Join DTerima As DT On HT.NoNotaTerima = DT.NoNotaTerima where DT.IDBarang = @a"
                cmd.Parameters.AddWithValue("@a", kodebarang)
                adapt.Fill(dataset, "StokOpName")
                rep = New LaporanStokOpname
                rep.SetDataSource(dataset)
            ElseIf Jenis = "LaporanPembayaran" Then
                cmd.CommandText = "SELECT H.NoNotaJual, T.NoNotaPembayaran, H.TglNota,H.NamaPelanggan, H.GrandTotal, T.TglBayar, T.UangBayar from HJual H, TbPembayaran T WHERE H.NoNotaJual = T.NoNotaJual"
                adapt.Fill(dataset, "Detailpembayaran")
                rep = New LaporanPembayaran
                rep.SetDataSource(dataset)
            End If
            con.Close()
            crv.ReportSource = rep
            crv.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub print()

    End Sub
End Class