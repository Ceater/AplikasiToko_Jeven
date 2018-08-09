Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Penjualan
    Dim DTable As New DataTable
    Dim DRow As DataRow
    Dim GTotal As Double 'Grand Total
    Dim TotBarang As Double 'Total Barang
    Dim TotJumBarang As Double 'Total Jumlah Barang
    Dim Pembayaran As Double
    Dim staff As String = ""
    Dim PilihanHarga As String = ""
    Dim KodeBarang As String = ""
    'Variable Label
    Dim pembayarantxt1 As Label
    Dim grandtotaltxt1 As Label
    Dim grandtotaltxt2 As Label


    Private Sub Penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grandtotaltxt1 = Label6
        grandtotaltxt2 = Label12
        pembayarantxt1 = Label15
        NotaTxt.Text = getNotaJual()
        DateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.LongDatePattern
    End Sub

    Private Sub Penjualan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        setGV()
        ComboBox1.DataSource = DSet.Tables("DataBarang")
        ComboBox1.ValueMember = "NamaBarang"
        ComboBox1.DisplayMember = "KodeBarang"
        ComboBox2.DataSource = getDataTBDSet("*", "TbPelanggan", "TipePelanggan='Toko'").Tables("result")
        ComboBox2.ValueMember = "NamaPelanggan"
        ComboBox2.DisplayMember = "NamaPelanggan"
        ComboBox3.DataSource = getDataTBDSet("*", "TbPelanggan", "TipePelanggan='Toko'").Tables("result")
        ComboBox3.ValueMember = "NamaPelanggan"
        ComboBox3.DisplayMember = "NamaPelanggan"
    End Sub

    Private Sub ComboBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            JmlBarang.Focus()
        End If
    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles CashRB.CheckedChanged, KreditRB.CheckedChanged
        cekTotal()
    End Sub

    Private Sub Radio_CheckedChanged(sender As Object, e As EventArgs) Handles R1.CheckedChanged, R2.CheckedChanged, R3.CheckedChanged
        If R1.Checked Then
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            PilihanHarga = "HargaNormal"
        ElseIf R2.Checked Then
            ComboBox2.Enabled = True
            ComboBox3.Enabled = False
            PilihanHarga = "HargaToko"
        ElseIf R3.Checked Then
            ComboBox2.Enabled = False
            ComboBox3.Enabled = True
            PilihanHarga = "HargaSales"
        End If
        clear()
    End Sub


    'dgv
    Private Sub dgv_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        cekTotal()
    End Sub

    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        Dim sat As Double = CDbl(Val(dgv.Rows(e.RowIndex).Cells(4).Value))
        Dim tot As Double = dgv.Rows(e.RowIndex).Cells(3).Value * sat
        Dim disc As Double = dgv.Rows(e.RowIndex).Cells(5).Value
        disc = disc * sat
        If disc = 0 Then
            dgv.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(CStr(tot))
        ElseIf disc >= 1 Then
            dgv.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(CStr(tot - disc))
        ElseIf disc <= -1 Then
            dgv.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(CStr(tot + disc))
        End If
        cekTotal()
    End Sub

    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        If (dgv.CurrentCell.ColumnIndex = 4 Or dgv.CurrentCell.ColumnIndex = 5) Then 'put columnindextovalidate
            RemoveHandler e.Control.KeyPress, AddressOf ValidateKeyPress
            AddHandler e.Control.KeyPress, AddressOf ValidateKeyPress
        End If
    End Sub

    Private Sub ValidateKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DRow = DTable.Rows(dgv.CurrentCell.RowIndex)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Asc(e.KeyChar) <> 45 AndAlso Asc(e.KeyChar) <> 46 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgv_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgv.UserDeletedRow
        cekTotal()
    End Sub


    'JmlBarang
    Private Sub JmlBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles JmlBarang.KeyDown
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Or e.KeyCode = 8 Or e.KeyCode = 46 Or e.KeyCode <> 45 Or e.KeyCode <> 46 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub JmlBarang_KeyUp(sender As Object, e As KeyEventArgs) Handles JmlBarang.KeyUp
        If sender.text = "" Then
            sender.text = "0"
        End If

        If e.KeyCode = Keys.Enter Then
            Dim JumlahBarang As Double = CDbl(Val(JmlBarang.Text))
            Try
                KodeBarang = ComboBox1.Text
                Dim addorappend As Boolean = True 'Digunakan untuk menentukan apakah tambah baru atau tambah jumlah
                If dgv.RowCount = 0 Then
                    addorappend = True
                Else
                    addorappend = True
                    For Each f In dgv.Rows
                        If f.cells(0).value = KodeBarang Then
                            f.Cells(4).Value += JumlahBarang
                            addorappend = False
                        End If
                    Next
                End If
                If addorappend Then
                    Dim result As Dictionary(Of String, String) = getDetailbarang(KodeBarang)
                    DRow = DTable.NewRow
                    DRow("Kode Barang") = KodeBarang
                    DRow("Nama Barang") = ComboBox1.SelectedValue
                    DRow("Satuan") = result("SatuanBarang")
                    DRow("Harga Satuan") = FormatCurrency(result(PilihanHarga))
                    DRow("Jumlah") = JumlahBarang
                    DRow("Diskon") = 0
                    DRow("Sub Total") = FormatCurrency(DRow("Harga Satuan") * JumlahBarang)
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

    Private Sub JmlBarang_Enter(sender As Object, e As EventArgs) Handles JmlBarang.Enter
        JmlBarang.Select(0, JmlBarang.Text.Length)
    End Sub


    'JmlBayar
    Private Sub JmlBayar_KeyDown(sender As Object, e As KeyEventArgs) Handles JmlBayar.KeyDown
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Or e.KeyCode = 8 Or e.KeyCode = 46 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub JmlBayar_KeyUp(sender As Object, e As KeyEventArgs) Handles JmlBayar.KeyUp
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


    'ButtonEvent
    Private Sub Proses_btn_Click(sender As Object, e As EventArgs) Handles Proses_btn.Click
        Dim printPreview As Boolean = False
        If CheckBox3.Checked Then
            printPreview = True
        End If
        NotaTxt.Text = getNotaJual()
        If NotaTxt.Text <> "" And dgv.RowCount <> 0 Then
            Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
            Dim temp As String = ""
            If R1.Checked Then
                If TamuTxt.Text <> "" Then
                    temp = TamuTxt.Text
                Else
                    temp = "Tamu"
                End If
            ElseIf R2.Checked Then
                temp = ComboBox2.Text
            ElseIf R3.Checked Then
                temp = ComboBox3.Text
            End If
            Dim result As Integer = MessageBox.Show("Apakah semua barang sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                If cekNotaJual(NotaTxt.Text) Then
                    MsgBox("Nota sudah terdaftar")
                Else
                    If CheckBox2.Checked Then
                        Dim f As New InfoSuratJalanLuarKota
                        Dim dr As DialogResult
                        dr = f.ShowDialog()
                        If dr = DialogResult.OK Then
                            Dim xz(5) As String
                            xz = f.x
                            xz(0) = NotaTxt.Text
                            xz(1) = tgl
                            xz(2) = temp
                            Dim h As New FormLaporan("SuratJalanLuarKota")
                            h.Width = 0
                            h.Height = 0
                            h.detailNotaLuarKota = xz
                            h.Show()
                            If printPreview Then
                            Else
                                h.Close()
                            End If
                        End If
                    End If
                    insertHJual(NotaTxt.Text, tgl, GTotal, temp, staff)
                    For Each f In dgv.Rows
                        insertDJual(NotaTxt.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, f.Cells(3).Value, f.Cells(4).Value, f.Cells(5).Value, f.Cells(6).Value)
                        updateStok(-f.Cells(4).Value, f.Cells(0).Value)
                    Next
                    insertPembayaran(NotaTxt.Text, tgl, Pembayaran)
                    Dim g As New FormLaporan("NotaPenjualan")
                    g.Width = 0
                    g.Height = 0
                    g.LaporanNoNota = NotaTxt.Text
                    g.copyNota = "Asli"
                    g.Show()
                    If printPreview Then
                    Else
                        g.Close()
                    End If
                    g = New FormLaporan("NotaPenjualan")
                    g.LaporanNoNota = NotaTxt.Text
                    g.copyNota = "Copy 1"
                    g.Show()
                    If printPreview Then
                    Else
                        g.Close()
                    End If
                    g = New FormLaporan("NotaPenjualan")
                    g.LaporanNoNota = NotaTxt.Text
                    g.copyNota = "Copy 2"
                    g.Show()
                    If printPreview Then
                    Else
                        g.Close()
                    End If
                    If CheckBox1.Checked Then
                        g = New FormLaporan("SuratJalan")
                        g.LaporanNoNota = NotaTxt.Text
                        g.Show()
                        If printPreview Then
                        Else
                            g.Close()
                        End If
                    End If
                    LoadDataSet()
                    clear()
                End If
            ElseIf result = DialogResult.No Then
            End If
        Else
            MsgBox("Cek nomer nota atau data barang")
        End If
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


    'Procedure and Function
    Sub setGV()
        DTable.Columns.Add("Kode Barang")
        DTable.Columns.Add("Nama Barang")
        DTable.Columns.Add("Satuan")
        DTable.Columns.Add("Harga Satuan")
        DTable.Columns.Add("Jumlah")
        DTable.Columns.Add("Diskon")
        DTable.Columns.Add("Sub Total")
        dgv.DataSource = DTable
        Dim temp As Double = dgv.Size.Width
        dgv.Columns(0).Width = temp * 0.15
        dgv.Columns(1).Width = temp * 0.245
        dgv.Columns(2).Width = temp * 0.1
        dgv.Columns(3).Width = temp * 0.15
        dgv.Columns(4).Width = temp * 0.12 - 41
        dgv.Columns(5).Width = temp * 0.1
        dgv.Columns(6).Width = temp * 0.13
        dgv.Columns(0).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(2).ReadOnly = True
        dgv.Columns(3).ReadOnly = True
        dgv.Columns(6).ReadOnly = True
    End Sub

    Sub cekTotal()
        Try
            TotBarang = 0
            TotJumBarang = 0
            GTotal = 0
            Pembayaran = 0
            For Each f In dgv.Rows
                TotBarang += 1
                TotJumBarang += f.Cells(4).Value
                GTotal += f.Cells(6).Value
            Next
            If CashRB.Checked Then
                Pembayaran = GTotal
            ElseIf KreditRB.Checked Then
                Pembayaran = JmlBayar.Text
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

    Function FormatCurrency(xx As Double)
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
        Try
            DTable.Clear()
            CashRB.Checked = True
            JmlBayar.Text = "0"
            NotaTxt.Text = getNotaJual()
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
End Class