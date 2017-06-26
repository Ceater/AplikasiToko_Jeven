Public Class Pelanggan
    Dim kodePel As String = ""
    Private Sub Pelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = DSet.Tables("DataPelanggan")
        setGV()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        kodePel = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        Button1.Text = "Rubah"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sender.text = "Tambah" Then
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                insertPelanggan(TextBox1.Text, TextBox2.Text, TextBox3.Text)
                LoadDataSet()
                clear()
            Else
                MsgBox("Jangan ada yang dikosongi")
            End If
        Else
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                updatePelanggan(TextBox1.Text, TextBox2.Text, TextBox3.Text, kodePel)
                LoadDataSet()
                clear()
            Else
                MsgBox("Jangan ada yang dikosongi")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button1.Text = "Rubah" Then
            Dim result As Integer = MessageBox.Show("Anda ingin menghapus data?", "Peringatan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                deletePelanggan(kodePel)
                LoadDataSet()
                clear()
            ElseIf result = DialogResult.No Then
            End If
        Else
            MsgBox("Pilih pelanggan yang ingin dihapus terlebih dahulu")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear()
    End Sub

    'Procedure and Function
    Sub setGV()
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama"
        DataGridView1.Columns(2).HeaderText = "Alamat"
        DataGridView1.Columns(3).HeaderText = "Telepon"
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(1).Width = temp * 0.25
        DataGridView1.Columns(2).Width = temp * 0.54
        DataGridView1.Columns(3).Width = temp * 0.2
    End Sub

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Button1.Text = "Tambah"
    End Sub
End Class