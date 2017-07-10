Public Class FormLaporanReturTerima
    Private Sub FormLaporanRetur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker2.MaxDate = Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            Dim f As New FormLaporan("LaporanReturTerima")
            f.mode = "1"
            f.Text = "Laporan Retur Barang"
            f.Show()
        ElseIf RadioButton2.Checked Then
            Dim f As New FormLaporan("LaporanReturTerima")
            f.mode = "2"
            f.Text = "Laporan Retur Barang"
            f.tglAwal = DateTimePicker1.Value
            f.tglAkhir = DateTimePicker2.Value
            f.Show()
        ElseIf RadioButton3.Checked Then
            Dim f As New FormLaporan("LaporanReturTerima")
            f.mode = "3"
            f.tglAwal = DateTimePicker3.Value
            f.Text = "Laporan Retur Barang"
            f.Show()
        End If
    End Sub
End Class