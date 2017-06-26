Public Class FormLaporanTerima
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            Dim f As New FormLaporan("LaporanTerimaBarang")
            f.mode = "1"
            f.Text = "Laporan Penerimaan Barang"
            f.Show()
        ElseIf RadioButton2.Checked Then
            Dim f As New FormLaporan("LaporanTerimaBarang")
            f.mode = "2"
            f.Text = "Laporan Penerimaan Barang"
            f.tglAwal = DateTimePicker1.Value
            f.tglAkhir = DateTimePicker2.Value
            f.Show()
        ElseIf RadioButton3.Checked Then
            Dim f As New FormLaporan("LaporanTerimaBarang")
            f.mode = "3"
            f.tglAwal = DateTimePicker3.Value
            f.Text = "Laporan Penerimaan Barang"
            f.Show()
        End If
    End Sub
End Class