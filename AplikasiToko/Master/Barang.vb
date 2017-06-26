Public Class Barang

    Private Sub Barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = DSet.Tables("DataBarang")
        setGV()
        Try
            ComboBox1.DataSource = DSet.Tables("DataSatuan")
            ComboBox1.DisplayMember = "NamaSatuan"
            ComboBox1.ValueMember = "KodeSatuan"
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Data Satuan Barang Belum Di isi")
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Button1.Text = "Rubah"
            TextBox1.ReadOnly = True
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            ComboBox1.SelectedValue = getKodeSatuan(DataGridView1.Rows(e.RowIndex).Cells(3).Value)
            TextBox3.Text = FormatCurrency(DataGridView1.Rows(e.RowIndex).Cells(4).Value)
            NumericUpDown1.Value = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result As Integer = MessageBox.Show("Anda ingin mengosongkan kolom barang?", "Peringatan", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            clearall()
            Button1.Text = "Tambah"
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            If sender.text = "Rubah" Then
                updateBarang(TextBox1.Text, TextBox2.Text, 0, ComboBox1.SelectedValue, TextBox3.Text, NumericUpDown1.Value)
                MsgBox("Perubahan berhasil")
            Else
                insertBarang(TextBox1.Text, TextBox2.Text, 0, ComboBox1.SelectedValue, TextBox3.Text, NumericUpDown1.Value)
                MsgBox("Penambahan berhasil")
            End If
            LoadDataSet()
            clearall()
        Else
            MsgBox("Cek kelengkapan pengisian")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer = MessageBox.Show("Anda ingin menghapus barang?", "Peringatan", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If Button1.Text = "Rubah" Then
                deleteBarang(TextBox1.Text)
                MsgBox("Barang berhasil dihapus")
            Else
                MsgBox("Belum ada barang yang dipilih")
            End If
            LoadDataSet()
            clearall()
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Or e.KeyCode = 8 Or e.KeyCode = 46 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp
        If sender.text = "" Then
            sender.text = "0"
        Else
            If CInt(sender.text) <> 0 Then
                sender.text = FormatCurrency(sender.text)
            Else
                sender.text = CInt(sender.text)
            End If
        End If
        sender.select(sender.text.length, 0)
    End Sub

    'Function and Procedure

    Sub clearall()
        Button1.Text = "Tambah"
        TextBox1.ReadOnly = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = 0
        NumericUpDown1.Value = 0
        ComboBox1.SelectedIndex = 0
    End Sub

    Sub setGV()
        DataGridView1.Columns(0).HeaderText = "Kode"
        DataGridView1.Columns(1).HeaderText = "Nama Barang"
        DataGridView1.Columns(2).HeaderText = "Stok"
        DataGridView1.Columns(3).HeaderText = "Satuan"
        DataGridView1.Columns(4).HeaderText = "Harga"
        DataGridView1.Columns(5).HeaderText = "Pengingat"
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.1
        DataGridView1.Columns(1).Width = temp * 0.4
        DataGridView1.Columns(2).Width = temp * 0.07
        DataGridView1.Columns(3).Width = temp * 0.1
        DataGridView1.Columns(4).Width = temp * 0.1
        DataGridView1.Columns(5).Width = temp * 0.2
        DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Function FormatCurrency(xx As Integer)
        Dim s As String
        If xx <> 0 Then
            s = xx.ToString("###,###")
        Else
            s = xx
        End If
        Return s
    End Function
End Class