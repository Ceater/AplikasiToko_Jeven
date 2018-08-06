Public Class HargaAmbilan

    Private Sub HargaAmbilan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = ModuleHargaAmbilan.getData("").Tables("DataAmbilan")

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        DataGridView1.DataSource = ModuleHargaAmbilan.getData(TextBox1.Text).Tables("DataAmbilan")
    End Sub
End Class