Public Class Pembelian
    Private Sub Pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            loadNotaTerima()
        Catch ex As Exception

        End Try
    End Sub

    Sub loadNotaTerima()
        ListBox1.DataSource = DSet.Tables("DataPembelian")
        ListBox1.DisplayMember = "NoNotaTerima"
        ListBox1.ValueMember = "NoNotaTerima"
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            DataGridView1.DataSource = getDetailBarangTerima(ListBox1.SelectedValue).Tables("DataPembelian")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class