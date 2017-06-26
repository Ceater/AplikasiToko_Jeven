Public Class PrintUlangNota
    Private Sub PrintUlangNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.DataSource = DSet.Tables("DataNotaPenjualan")
        ComboBox1.ValueMember = "NoNotaJual"
        ComboBox1.DisplayMember = "NoNotaJual"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FormLaporan("NotaPenjualan")
        f.LaporanNoNota = ComboBox1.SelectedValue
        f.Show()
    End Sub
End Class