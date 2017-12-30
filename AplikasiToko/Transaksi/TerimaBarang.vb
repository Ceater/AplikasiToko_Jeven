Public Class TerimaBarang
    Dim DTable As New DataTable
    Dim DRow As DataRow
    Dim TotBarang As Double 'Total Barang
    Dim TotJumBarang As Double 'Total Jumlah Barang
    Dim staff As String = ""

    Private Sub TerimaBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern
    End Sub

    Private Sub Penjualan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        setGV()
        ComboBox1.DataSource = DSet.Tables("DataBarang")
        ComboBox1.ValueMember = "NamaBarang"
        ComboBox1.DisplayMember = "KodeBarang"
        NotaTxt.Text = getNotaTerima()
    End Sub

    Private Sub Proses_Click(sender As Object, e As EventArgs) Handles Proses.Click
        If NotaTxt.Text <> "" And dgv.RowCount <> 0 Then
            Dim result As Integer = MessageBox.Show("Apakah semua barang sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                If cekNotaTerima(NotaTxt.Text) Then
                    MsgBox("Nota sudah terdaftar")
                Else
                    insertHTerima(NotaTxt.Text, tgl, staff)
                    For Each f In dgv.Rows
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New PenerimaanTambahBarang
        f.ShowDialog()
    End Sub

    'Dgv
    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        If (dgv.CurrentCell.ColumnIndex = 3) Then 'put columnindextovalidate
            RemoveHandler e.Control.KeyPress, AddressOf ValidateKeyPress
            AddHandler e.Control.KeyPress, AddressOf ValidateKeyPress
        End If
    End Sub

    Private Sub ValidateKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DRow = DTable.Rows(dgv.CurrentCell.RowIndex)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        cekTotal()
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        cekTotal()
    End Sub


    'Combobox1
    Private Sub ComboBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            JmlBarang.Focus()
        End If
    End Sub


    'JmlBarang
    Private Sub JmlBarang_KeyUp(sender As Object, e As KeyEventArgs) Handles JmlBarang.KeyUp
        Dim JumlahBarang As Double = CDbl(Val(sender.text))
        If sender.text = "" Then
            sender.text = "0"
        End If
        If e.KeyCode = Keys.Enter Then
            Try
                Dim addorappend As Boolean = True 'Digunakan untuk menentukan apakah tambah baru atau tambah jumlah
                If dgv.RowCount = 0 Then
                    addorappend = True
                Else
                    addorappend = True
                    For Each f In dgv.Rows
                        If f.cells(0).value = ComboBox1.Text Then
                            f.Cells(3).Value += JumlahBarang
                            addorappend = False
                        End If
                    Next
                End If
                If addorappend Then
                    DRow = DTable.NewRow
                    DRow("Kode Barang") = ComboBox1.Text
                    DRow("Nama Barang") = ComboBox1.SelectedValue
                    DRow("Satuan") = DSet.Tables("DataBarang").Rows(ComboBox1.SelectedIndex).Item(3).ToString
                    DRow("Jumlah") = JumlahBarang
                    DTable.Rows.Add(DRow)
                End If
                cekTotal()
            Catch ex As Exception
                MsgBox("Kode barang tidak ditemukan")
                dgv.Focus()
            End Try
            ComboBox1.Focus()
        End If
    End Sub

    'Procedure and Function
    Sub setGV()
        DTable.Columns.Add("Kode Barang")
        DTable.Columns.Add("Nama Barang")
        DTable.Columns.Add("Satuan")
        DTable.Columns.Add("Jumlah")
        dgv.DataSource = DTable
        Dim temp As Double = dgv.Size.Width
        dgv.Columns(0).Width = temp * 0.34
        dgv.Columns(1).Width = temp * 0.3
        dgv.Columns(2).Width = temp * 0.2
        dgv.Columns(3).Width = temp * 0.1
        dgv.Columns(0).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(2).ReadOnly = True
    End Sub

    Sub cekTotal()
        Try
            TotBarang = 0
            TotJumBarang = 0
            For Each f In dgv.Rows
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
        NotaTxt.Text = getNotaTerima()
        ComboBox1.SelectedIndex = 0
    End Sub
End Class