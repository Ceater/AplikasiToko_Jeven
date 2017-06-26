Public Class Staff
    Dim chkbox(12) As CheckBox
    Private Sub Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = DSet.Tables("DataStaff")
        setGV()
        chkbox(0) = M1
        chkbox(1) = M2
        chkbox(2) = M3
        chkbox(3) = M4
        chkbox(4) = T1
        chkbox(5) = T2
        chkbox(6) = T3
        chkbox(7) = T4
        chkbox(8) = T5
        chkbox(9) = L1
        chkbox(10) = L2
        chkbox(11) = L3
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            TextBox1.ReadOnly = True
            Tambah.Text = "Rubah"
            Dim x(12) As String
            For i = 0 To 12
                x(i) = DataGridView1.Rows(e.RowIndex).Cells(5).Value.substring(i, 1)
                If x(i) = "1" Then
                    chkbox(i).Checked = True
                Else
                    chkbox(i).Checked = False
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Reset_btn(sender As Object, e As EventArgs) Handles Reset.Click
        If Tambah.Text = "Rubah" Then
            Dim result As Integer = MessageBox.Show("Anda ingin mengosongkan kolom?", "Peringatan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Clear()
            ElseIf result = DialogResult.No Then
            End If
        Else
            MsgBox("Pilih staff yang ingin dihapus terlebih dahulu")
        End If
    End Sub

    Private Sub Tambah_Click(sender As Object, e As EventArgs) Handles Tambah.Click
        If sender.text = "Tambah" Then
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then
                Dim previl As String = ""
                For i = 0 To chkbox.Count - 1
                    If chkbox(i).Checked = True Then
                        previl &= "1"
                    Else
                        previl &= "0"
                    End If
                Next
                If cekIDStaff(TextBox1.Text) Then
                    insertStaff(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, previl)
                    LoadDataSet()
                    Clear()
                Else
                    MsgBox("ID sudah terdaftar")
                End If
            Else
                MsgBox("Jangan ada yang dikosongi")
            End If
        Else
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then
                Dim previl As String = ""
                For i = 0 To chkbox.Count - 1
                    If chkbox(i).Checked = True Then
                        previl &= "1"
                    Else
                        previl &= "0"
                    End If
                Next
                updateStaff(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, previl)
                LoadDataSet()
                Clear()
            Else
                MsgBox("Jangan ada yang dikosongi")
            End If
        End If
    End Sub

    Private Sub Hapus_Click(sender As Object, e As EventArgs) Handles Hapus.Click
        Dim result As Integer = MessageBox.Show("Anda ingin menghapus data?", "Peringatan", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            deleteStaff(TextBox1.Text)
            LoadDataSet()
            Clear()
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    'Procedure and Function
    Sub setGV()
        DataGridView1.Columns(0).HeaderText = "ID Staff"
        DataGridView1.Columns(1).HeaderText = "Password"
        DataGridView1.Columns(2).HeaderText = "Nama"
        DataGridView1.Columns(3).HeaderText = "Alamat"
        DataGridView1.Columns(4).HeaderText = "Nomer Telepon"
        DataGridView1.Columns(5).Visible = False
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.1
        DataGridView1.Columns(1).Width = temp * 0.15
        DataGridView1.Columns(2).Width = temp * 0.27
        DataGridView1.Columns(3).Width = temp * 0.3
        DataGridView1.Columns(4).Width = temp * 0.15
        DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Sub Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox1.ReadOnly = False
        Tambah.Text = "Tambah"
        M1.Checked = False
        M2.Checked = False
        M3.Checked = False
        M4.Checked = False
        L1.Checked = False
        L2.Checked = False
        L3.Checked = False
        T1.Checked = False
        T2.Checked = False
        T3.Checked = False
        T4.Checked = False
        T5.Checked = False
    End Sub
End Class