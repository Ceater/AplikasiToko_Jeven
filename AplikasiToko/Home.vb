Public Class Home
    Public hakAkses As String = ""
    Public MenuStrip(19) As ToolStripMenuItem
    Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        LoadDataSet()
        MenuStrip(0) = M1
        MenuStrip(1) = M2
        MenuStrip(2) = M3
        MenuStrip(3) = T1
        MenuStrip(4) = T2
        MenuStrip(5) = T3
        MenuStrip(6) = T4
        MenuStrip(7) = T5
        MenuStrip(8) = T6
        MenuStrip(9) = T7
        MenuStrip(10) = T8
        MenuStrip(11) = L1
        MenuStrip(12) = L2
        MenuStrip(13) = L3
        MenuStrip(14) = L4
        MenuStrip(15) = L5
        MenuStrip(16) = L6
        MenuStrip(17) = L7
        MenuStrip(18) = L8
        MenuStrip(19) = L9
        Dim temp(MenuStrip.Count - 1) As String
        For i = 0 To MenuStrip.Count - 1
            temp(i) = hakAkses.Substring(i, 1)
            If temp(i) = "1" Then
                MenuStrip(i).Enabled = True
            Else
                MenuStrip(i).Enabled = False
            End If
        Next
        AutoUpdatePersediaanAwal()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel4.Text = Date.Now.ToString("dd - MMMM - yyyy")
        ToolStripStatusLabel6.Text = TimeOfDay.ToString("h:mm:ss tt")
        cekStokMinimum()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        LoginForm.Show()
        Me.Close()
    End Sub

    Private Sub BarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles M1.Click
        If Application.OpenForms().OfType(Of FormLaporanPenjualan).Any Then
        Else
            Dim f As New Barang
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M2.Click
        If Application.OpenForms().OfType(Of FormLaporanPenjualan).Any Then
        Else
            Dim f As New Staff
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T1.Click
        If Application.OpenForms().OfType(Of FormLaporanPenjualan).Any Then
        Else
            Dim f As New Penjualan
            f.MdiParent = Me
            f.setStaff(ToolStripStatusLabel2.Text)
            f.Show()
        End If
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M3.Click
        If Application.OpenForms().OfType(Of FormLaporanPenjualan).Any Then
        Else
            Dim f As New Pelanggan
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T2.Click
        If Application.OpenForms().OfType(Of FormLaporanPenjualan).Any Then
        Else
            Dim f As New TerimaBarang
            f.MdiParent = Me
            f.setStaff(ToolStripStatusLabel2.Text)
            f.Show()
        End If
    End Sub

    Private Sub PembayaranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T3.Click
        If Application.OpenForms().OfType(Of FormLaporanPenjualan).Any Then
        Else
            Dim f As New Pembayaran
            f.MdiParent = Me
            f.setStaff(ToolStripStatusLabel2.Text)
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
            Dim f As New ReturTerima(ToolStripStatusLabel2.Text)
            f.MdiParent = Me
            f.Show()
        End If
    End Sub

    Private Sub T7_Click(sender As Object, e As EventArgs) Handles T7.Click
        If Application.OpenForms().OfType(Of ReturJual).Any Then
        Else
            Dim f As New ReturJual(ToolStripStatusLabel2.Text)
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

    Private Sub PenjualanToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles L1.Click
        Dim f As New FormLaporanPenjualan
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub PembelianToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles L2.Click
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
End Class