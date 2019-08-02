Public Class Supplier
    Dim kodeSup = "", kodeSal As String = ""
    Dim scrollIdx As Integer = 0
    Private Sub Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reloaddset()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            kodeSup = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox3.Text = TextBox1.Text
            DataGridView2.DataSource = getDataTBDSet("TKS.IDKontakSupplier, TKS.NamaSales, TS.NamaSupplier, TKS.TlpSales", "TbKontakSupplier As TKS INNER Join TbSupplier As TS On TS.IDSupplier = TKS.IDSupplier", "TS.IDSupplier='" & kodeSup & "'").Tables("result")
            setGV_2()
            scrollIdx = e.RowIndex
            Button1.Text = "Rubah"
            Button5.Text = "Tambah"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Try
            kodeSal = DataGridView2.Rows(e.RowIndex).Cells(0).Value
            TextBox3.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            TextBox4.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value
            TextBox5.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value
            Button5.Text = "Rubah"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sender.text = "Tambah" Then
            If TextBox1.Text <> "" Then
                insertSupplier(TextBox1.Text, TextBox2.Text)
                LoadDataSet()
                reloaddset()
                clear()
            Else
                MsgBox("Jangan ada yang dikosongi")
            End If
        Else
            If TextBox1.Text <> "" Then
                updateSupplier(kodeSup, TextBox1.Text, TextBox2.Text)
                LoadDataSet()
                reloaddset()
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
                deleteSupplier(kodeSup)
                LoadDataSet()
                reloaddset()
                clear()
            ElseIf result = DialogResult.No Then
            End If
        Else
            MsgBox("Pilih Supplier yang ingin dihapus terlebih dahulu")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If sender.text = "Tambah" Then
            If TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then
                insertSales(kodeSup, TextBox4.Text, TextBox5.Text)
                LoadDataSet()
                reloaddset()
                clear_2()
            Else
                MsgBox("Jangan ada yang dikosongi")
            End If
        Else
            If TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then
                updateSales(kodeSup, TextBox4.Text, TextBox5.Text, kodeSal)
                LoadDataSet()
                reloaddset()
                clear_2()
            Else
                MsgBox("Jangan ada yang dikosongi")
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button5.Text = "Rubah" Then
            Dim result As Integer = MessageBox.Show("Anda ingin menghapus data?", "Peringatan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                deleteSales(kodeSal)
                LoadDataSet()
                reloaddset()
                clear_2()
            ElseIf result = DialogResult.No Then
            End If
        Else
            MsgBox("Pilih Sales yang ingin dihapus terlebih dahulu")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        clear_2()
    End Sub

    Sub setGV()
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama"
        DataGridView1.Columns(2).HeaderText = "Alamat"
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(1).Width = temp * 0.3
        DataGridView1.Columns(2).Width = temp * 0.63
    End Sub

    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        Button1.Text = "Tambah"
        reloaddset()
        Try
            DataGridView1.FirstDisplayedScrollingRowIndex = scrollIdx
        Catch ex As Exception

        End Try
    End Sub

    Sub setGV_2()
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).HeaderText = "Nama"
        DataGridView2.Columns(2).HeaderText = "Supplier"
        DataGridView2.Columns(3).HeaderText = "Telepon"
        Dim temp As Double = DataGridView2.Size.Width
        DataGridView2.Columns(1).Width = temp * 0.2
        DataGridView2.Columns(2).Width = temp * 0.54
        DataGridView2.Columns(3).Width = temp * 0.2
    End Sub

    Sub clear_2()
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Button5.Text = "Tambah"
        Try
            DataGridView2.FirstDisplayedScrollingRowIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Sub reloaddset()
        DataGridView1.DataSource = getDataTBDSet("*", "TbSupplier").Tables("result")
        DataGridView2.DataSource = getDataTBDSet("TKS.IDKontakSupplier, TKS.NamaSales, TS.NamaSupplier, TKS.TlpSales", "TbKontakSupplier As TKS INNER Join TbSupplier As TS On TS.IDSupplier = TKS.IDSupplier").Tables("result")
        setGV()
        setGV_2()
    End Sub
End Class