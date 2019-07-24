Public Class Home
    Public hakAkses As String = ""
    Public MenuStrip(22) As ToolStripMenuItem
    Dim isec As Integer = 0

    Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        userLogin = ToolStripStatusLabel2.Text
        ToolStripStatusLabel7.Text = "Versi " & VersiSekarang
        Timer1.Start()
        LoadDataSet()
        MenuStrip(0) = M1
        MenuStrip(1) = M2
        MenuStrip(2) = M3
        MenuStrip(3) = M4
        MenuStrip(4) = T1
        MenuStrip(5) = T2
        MenuStrip(6) = T3
        MenuStrip(7) = T4
        MenuStrip(8) = T5
        MenuStrip(9) = T6
        MenuStrip(10) = T7
        MenuStrip(11) = T8
        MenuStrip(12) = L1
        MenuStrip(13) = L2
        MenuStrip(14) = L3
        MenuStrip(15) = L4
        MenuStrip(16) = L5
        MenuStrip(17) = L6
        MenuStrip(18) = L7
        MenuStrip(19) = L8
        MenuStrip(20) = L9
        MenuStrip(21) = L10
        MenuStrip(22) = Setting
        Dim temp(MenuStrip.Count - 1) As String
        For i = 0 To MenuStrip.Count - 1
            Try
                temp(i) = hakAkses.Substring(i, 1)
            Catch ex As Exception
                temp(i) = 0
            End Try
            If temp(i) = "1" Then
                MenuStrip(i).Enabled = True
            Else
                MenuStrip(i).Enabled = False
            End If
        Next
        AutoUpdatePersediaanAwal()
        cekStokMinimum()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel4.Text = Date.Now.ToString("dd - MMMM - yyyy")
        ToolStripStatusLabel6.Text = TimeOfDay.ToString("h:mm:ss tt")
        isec = DateTime.Now.Second
        If isec = 0 Then
            'cekStokMinimum()
        End If
    End Sub

    Private Sub RefreshStokMinimumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshStokMinimumToolStripMenuItem.Click
        cekStokMinimum()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        LoginForm.Show()
        Me.Close()
    End Sub

    Private Sub BarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M1.Click

    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M2.Click
        If Application.OpenForms().OfType(Of Staff).Any Then
        Else
            Dim f As New Staff
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M3.Click
        If Application.OpenForms().OfType(Of Pelanggan).Any Then
        Else
            Dim f As New Pelanggan
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M4.Click
        If Application.OpenForms().OfType(Of Supplier).Any Then
        Else
            Dim f As New Supplier
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T1.Click
        If Application.OpenForms().OfType(Of Penjualan).Any Then
        Else
            Dim f As New Penjualan
            f.MdiParent = Me
            f.setStaff(userLogin)
            f.Show()
        End If
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T2.Click
        If Application.OpenForms().OfType(Of TerimaBarang).Any Then
        Else
            Dim f As New TerimaBarang
            f.MdiParent = Me
            f.setStaff(userLogin)
            f.Show()
        End If
    End Sub

    Private Sub PembayaranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T3.Click
        If Application.OpenForms().OfType(Of Pembayaran).Any Then
        Else
            Dim f As New Pembayaran
            f.MdiParent = Me
            f.setStaff(userLogin)
            f.Show()
        End If
    End Sub

    Private Sub StokOpnameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T4.Click
        If Application.OpenForms().OfType(Of StokOpname).Any Then
        Else
            Dim f As New StokOpname
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub PrintUlangNotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T5.Click
        If Application.OpenForms().OfType(Of PrintUlangNota).Any Then
        Else
            Dim f As New PrintUlangNota

            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub ReturBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T6.Click
        If Application.OpenForms().OfType(Of ReturTerima).Any Then
        Else
            Dim f As New ReturTerima(userLogin)
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub T7_Click(sender As Object, e As EventArgs) Handles T7.Click
        If Application.OpenForms().OfType(Of ReturJual).Any Then
        Else
            Dim f As New ReturJual(userLogin)
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub T8_Click(sender As Object, e As EventArgs) Handles T8.Click
        If Application.OpenForms().OfType(Of ReturJual).Any Then
        Else
            Dim f As New Pembelian
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub SetPersediaanAwalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetPersediaanAwalToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of SetPersediaanAwal).Any Then
        Else
            Dim f As New SetPersediaanAwal
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub PrinterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrinterToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of Printer).Any Then
        Else
            Dim f As New Printer
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub L1_Click(sender As Object, e As EventArgs) Handles L1.Click
        Dim f As New FormLaporanPenjualan
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub L2_Click(sender As Object, e As EventArgs) Handles L2.Click
        Dim f As New FormLaporanTerima
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub L3_Click(sender As Object, e As EventArgs) Handles L3.Click
        Dim f As New FormLaporan("LaporanPembayaran")
        f.Show()
    End Sub

    Private Sub L4_Click(sender As Object, e As EventArgs) Handles L4.Click
        Dim f As New FormLaporanReturTerima
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub L5_Click(sender As Object, e As EventArgs) Handles L5.Click
        Dim f As New FormLaporanReturJual
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub L6_Click(sender As Object, e As EventArgs) Handles L6.Click
        Dim f As New FormLaporan("LaporanStokBarang")
        f.Text = "Laporan Stok Barang"
        f.Show()
    End Sub

    Private Sub L7_Click(sender As Object, e As EventArgs) Handles L7.Click
        Dim f As New FormLaporanPembelian
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub L8_Click(sender As Object, e As EventArgs) Handles L8.Click
        Dim f As New FormLaporanLabaRugi
        f.Show()
    End Sub

    Private Sub L9_Click(sender As Object, e As EventArgs) Handles L9.Click
        Dim f As New FormLaporanPendapatan
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub L10_Click(sender As Object, e As EventArgs) Handles L10.Click
        Dim f As New GrafikLaporan
        f.MdiParent = Me
        f.Show()
    End Sub

    Sub cekStokMinimum()
        Dim DT As DataTable = DSet.Tables("DataStokMinim")
        ListBox1.Items.Clear()
        ListBox1.Items.Add("Stok Pengingat")
        ListBox1.Items.Add("=================")
        For Each f As DataRow In DT.Rows
            ListBox1.Items.Add(f(0) & " - " & f(1))
        Next
    End Sub

    Private Sub UpdateVersiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateVersiToolStripMenuItem.Click
        Dim f As New UpdateVersi(ToolStripStatusLabel7.Text.Substring(6))
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupDatabaseToolStripMenuItem.Click
        Dim f As New BackupDatabase
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub FormResetDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormResetDataToolStripMenuItem.Click
        Dim f As New ResetData
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub DaftarBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarBarangToolStripMenuItem.Click
        Dim f As New ListBarang
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub EditBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditBarangToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of Barang).Any Then
        Else
            Dim f As New Barang
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub HargaAmbilanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HargaAmbilanToolStripMenuItem1.Click
        If Application.OpenForms().OfType(Of HargaAmbilan).Any Then
        Else
            Dim f As New HargaAmbilan
            f.MdiParent = Me
            f.Show()
        End If
    End Sub
End Class