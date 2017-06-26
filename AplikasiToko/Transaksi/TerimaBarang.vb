Public Class TerimaBarang
    Dim DTable As New DataTable
    Dim DRow As DataRow
    Dim TotBarang As Integer 'Total Barang
    Dim TotJumBarang As Integer 'Total Jumlah Barang
    Dim staff As String = ""

    Private Sub TerimaBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern
    End Sub

    Private Sub Penjualan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        setGV()
        ComboBox1.DataSource = DSet.Tables("DataBarang")
        ComboBox1.ValueMember = "NamaBarang"
        ComboBox1.DisplayMember = "KodeBarang"
    End Sub

    Private Sub ComboBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            Try
                Dim addorappend As Boolean = True 'Digunakan untuk menentukan apakah tambah baru atau tambah jumlah
                If DataGridView1.RowCount = 0 Then
                    addorappend = True
                Else
                    For Each f In DataGridView1.Rows
                        If f.cells(0).value = ComboBox1.SelectedText Then
                            f.Cells(3).Value += 1
                            addorappend = False
                        Else
                            addorappend = True
                        End If
                    Next
                End If
                If addorappend Then
                    DRow = DTable.NewRow
                    DRow("Kode Barang") = ComboBox1.SelectedText
                    DRow("Nama Barang") = ComboBox1.SelectedValue
                    DRow("Satuan") = DSet.Tables("DataBarang").Rows(ComboBox1.SelectedIndex).Item(3).ToString
                    DRow("Jumlah") = 1
                    DTable.Rows.Add(DRow)
                End If
                cekTotal()
            Catch ex As Exception
                MsgBox("Kode barang tidak ditemukan")
                DataGridView1.Focus()
            End Try
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If (DataGridView1.CurrentCell.ColumnIndex = 3) Then 'put columnindextovalidate
            RemoveHandler e.Control.KeyPress, AddressOf ValidateKeyPress
            AddHandler e.Control.KeyPress, AddressOf ValidateKeyPress
        End If
    End Sub

    Private Sub ValidateKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DRow = DTable.Rows(DataGridView1.CurrentCell.RowIndex)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        cekTotal()
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        cekTotal()
    End Sub

    Private Sub Proses_Click(sender As Object, e As EventArgs) Handles Proses.Click
        If NotaTxt.Text <> "" And DataGridView1.RowCount <> 0 Then
            Dim result As Integer = MessageBox.Show("Apakah semua barang sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                If cekNotaTerima(NotaTxt.Text) Then
                    MsgBox("Nota sudah terdaftar")
                Else
                    insertHTerima(NotaTxt.Text, tgl, staff)
                    For Each f In DataGridView1.Rows
                        insertDTerima(NotaTxt.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, f.Cells(3).Value)
                        updateStok(f.Cells(3).Value, f.Cells(0).Value)
                    Next
                    MsgBox("Transaksi Berhasil")
                    clear()
                    LoadDataSet()
                End If
            ElseIf result = DialogResult.No Then
                End If
        Else
            MsgBox("Cek nomer nota atau data barang")
        End If
    End Sub


    'Procedure and Function
    Sub setGV()
        DTable.Columns.Add("Kode Barang")
        DTable.Columns.Add("Nama Barang")
        DTable.Columns.Add("Satuan")
        DTable.Columns.Add("Jumlah")
        DataGridView1.DataSource = DTable
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.34
        DataGridView1.Columns(1).Width = temp * 0.3
        DataGridView1.Columns(2).Width = temp * 0.2
        DataGridView1.Columns(3).Width = temp * 0.1
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
    End Sub

    Sub cekTotal()
        Try
            TotBarang = 0
            TotJumBarang = 0
            For Each f In DataGridView1.Rows
                TotBarang += 1
                TotJumBarang += f.Cells(3).Value
            Next
            Label8.Text = TotJumBarang
            Label4.Text = TotBarang
        Catch ex As Exception

        End Try
    End Sub

    Sub setStaff(x As String)
        staff = x
    End Sub

    Sub clear()
        DTable.Clear()
        NotaTxt.Text = ""
        ComboBox1.SelectedIndex = 0
    End Sub
End Class