Public Class StokOpname

    Private Sub StokOpname_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.DataSource = DSet.Tables("DataBarang")
        ComboBox1.ValueMember = "KodeBarang"
        ComboBox1.DisplayMember = "KodeBarang"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New FormLaporan("StokOpname")
        f.kodebarang = ComboBox1.SelectedValue
        f.Show()
    End Sub
End Class