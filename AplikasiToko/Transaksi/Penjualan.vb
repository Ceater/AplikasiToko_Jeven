Public Class Penjualan
    Dim DTable As New DataTable
    Dim DRow As DataRow
    Dim GTotal As Integer 'Grand Total
    Dim TotBarang As Integer 'Total Barang
    Dim TotJumBarang As Integer 'Total Jumlah Barang
    Dim Pembayaran As Integer
    Dim staff As String = ""
    'Variable Label
    Dim pembayarantxt1 As Label
    Dim grandtotaltxt1 As Label
    Dim grandtotaltxt2 As Label


    Private Sub Penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grandtotaltxt1 = Label6
        grandtotaltxt2 = Label12
        pembayarantxt1 = Label15
        DateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern
    End Sub

    Private Sub Penjualan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        setGV()
        ComboBox1.DataSource = DSet.Tables("DataBarang")
        ComboBox1.ValueMember = "NamaBarang"
        ComboBox1.DisplayMember = "KodeBarang"
        ComboBox2.DataSource = DSet.Tables("DataPelanggan")
        ComboBox2.ValueMember = "NamaPelanggan"
        ComboBox2.DisplayMember = "NamaPelanggan"
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
                            f.Cells(4).Value += 1
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
                    DRow("Harga Satuan") = FormatCurrency(DSet.Tables("DataBarang").Rows(ComboBox1.SelectedIndex).Item(4).ToString)
                    DRow("Jumlah") = 1
                    DRow("Diskon %") = 0
                    DRow("Sub Total") = FormatCurrency(DRow("Harga Satuan"))
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
        If (DataGridView1.CurrentCell.ColumnIndex = 4 Or DataGridView1.CurrentCell.ColumnIndex = 5) Then 'put columnindextovalidate
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
        Dim tot As Integer = DataGridView1.Rows(e.RowIndex).Cells(3).Value * DataGridView1.Rows(e.RowIndex).Cells(4).Value
        Dim disc As Integer = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        If disc = 0 Then
            DataGridView1.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(CStr(tot))
        Else
            DataGridView1.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(CStr(tot - (tot * (disc / 100))))
        End If
        cekTotal()
    End Sub

    Private Sub Batal(sender As Object, e As EventArgs) Handles Batal_btn.Click
        Dim result As Integer = MessageBox.Show("Anda ingin mengosongkan daftar barang?", "Peringatan", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            DTable.Clear()
            GTotal = 0
            TotBarang = 0
            TotJumBarang = 0
            pembayarantxt1.Text = 0
            grandtotaltxt1.Text = 0
            grandtotaltxt2.Text = 0
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    Private Sub DataGridView1_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        cekTotal()
    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles CashRB.CheckedChanged, KreditRB.CheckedChanged
        cekTotal()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Or e.KeyCode = 8 Or e.KeyCode = 46 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If sender.text = "" Then
            sender.text = "0"
            cekTotal()
        Else
            cekTotal()
            If CInt(sender.text) <> 0 Then
                sender.text = FormatCurrency(sender.text)
            Else
                sender.text = CInt(sender.text)
            End If
        End If
        sender.select(sender.text.length, 0)
    End Sub

    Private Sub Proses_btn_Click(sender As Object, e As EventArgs) Handles Proses_btn.Click
        If NotaTxt.Text <> "" And DataGridView1.RowCount <> 0 Then
            Dim result As Integer = MessageBox.Show("Apakah semua barang sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                Dim temp As String
                If RadioButton1.Checked Then
                    temp = "Tamu"
                Else
                    temp = ComboBox2.SelectedValue
                End If
                If cekNotaJual(NotaTxt.Text) Then
                    MsgBox("Nota sudah terdaftar")
                Else
                    insertHJual(NotaTxt.Text, tgl, GTotal, temp, staff)
                    For Each f In DataGridView1.Rows
                        insertDJual(NotaTxt.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, f.Cells(3).Value, f.Cells(4).Value, f.Cells(5).Value, f.Cells(6).Value)
                        updateStok(-f.Cells(4).Value, f.Cells(0).Value)
                    Next
                    insertPembayaran(NotaTxt.Text, tgl, Pembayaran)
                    Dim g As New FormLaporan("NotaPenjualan")
                    g.LaporanNoNota = NotaTxt.Text
                    g.Width = 0
                    g.Height = 0
                    g.Show()
                    LoadDataSet()
                    clear()
                    g.Close()
                End If
            ElseIf result = DialogResult.No Then
            End If
        Else
            MsgBox("Cek nomer nota atau data barang")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        If RadioButton1.Checked Then
            ComboBox2.Enabled = False
        ElseIf RadioButton2.checked Then
            ComboBox2.Enabled = True
        End If
        'ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        cekTotal()
    End Sub

    'Procedure and Function
    Sub setGV()
        DTable.Columns.Add("Kode Barang")
        DTable.Columns.Add("Nama Barang")
        DTable.Columns.Add("Satuan")
        DTable.Columns.Add("Harga Satuan")
        DTable.Columns.Add("Jumlah")
        DTable.Columns.Add("Diskon %")
        DTable.Columns.Add("Sub Total")
        DataGridView1.DataSource = DTable
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.15
        DataGridView1.Columns(1).Width = temp * 0.245
        DataGridView1.Columns(2).Width = temp * 0.1
        DataGridView1.Columns(3).Width = temp * 0.15
        DataGridView1.Columns(4).Width = temp * 0.12 - 41
        DataGridView1.Columns(5).Width = temp * 0.1
        DataGridView1.Columns(6).Width = temp * 0.13
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(6).ReadOnly = True
    End Sub

    Sub cekTotal()
        Try
            TotBarang = 0
            TotJumBarang = 0
            GTotal = 0
            Pembayaran = 0
            For Each f In DataGridView1.Rows
                TotBarang += 1
                TotJumBarang += f.Cells(4).Value
                GTotal += f.Cells(6).Value
            Next
            If CashRB.Checked Then
                Pembayaran = GTotal
            ElseIf KreditRB.Checked Then
                Pembayaran = TextBox1.Text
            End If
            pembayarantxt1.Text = FormatCurrency(Pembayaran)
            grandtotaltxt1.Text = FormatCurrency(GTotal)
            grandtotaltxt2.Text = FormatCurrency(GTotal)
            Label8.Text = TotJumBarang
            Label3.Text = TotBarang
            Label19.Text = FormatCurrency(GTotal - Pembayaran)
        Catch ex As Exception

        End Try
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

    Sub setStaff(x As String)
        staff = x
    End Sub

    Sub clear()
        DTable.Clear()
        NotaTxt.Text = ""
        CashRB.Checked = True
        TextBox1.Text = "0"
        ComboBox1.SelectedIndex = 0
    End Sub
End Class