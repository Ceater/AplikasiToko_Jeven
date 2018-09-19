Public Class ReturJual
    Dim ReturTotal As Boolean = False 'True jika ternyata pembelian batal, False jika retur sebagian.
    Dim staff As String = ""
    Dim maxQty As ArrayList
    Dim formReady As Boolean = False
    Public Sub New(ByVal id As String)
        InitializeComponent()
        staff = id
    End Sub

    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            clear()
            formReady = True
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = getNotaReturJual()
        Dim count = 0, totalHargaBarang As Integer = 0
        Dim result As Integer = MessageBox.Show("Apakah semua barang sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
        Dim msg As String = ""
        TextBox1.Text = getNotaReturJual()
        If result = DialogResult.Yes Then
            For Each f In dgv.Rows
                count += 1
            Next
            If cekNotaReturJual(TextBox1.Text) Then
                MsgBox("Nomer Nota Sudah Pernah Digunakan")
            Else
                Dim qtyOk As Boolean = True
                Dim counter As Integer = 0
                For Each f As DataGridViewRow In Me.dgv.Rows
                    Dim temp2 As String = CStr(f.Cells(4).Value).Replace(",", ".")
                    Dim sat As Double = CDbl(Val(temp2))
                    If CDbl(maxQty(counter)) < CDbl(sat) Then
                        qtyOk = False
                        msg &= "Kode: " & f.Cells(0).Value & " Maksimal: " & maxQty(counter) & vbCrLf
                    End If
                    counter += 1
                Next
                If count <> 0 And qtyOk Then
                    Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                    insertHReturJual(TextBox1.Text, ComboBox1.SelectedValue, tgl, staff)
                    For Each f As DataGridViewRow In Me.dgv.Rows
                        If f.Cells(4).Value <> 0 Then
                            Dim fHarga = 0, fDiskon = 0, fSubtotal As Integer = 0
                            fHarga = f.Cells(3).Value
                            fDiskon = f.Cells(5).Value
                            fDiskon = f.Cells(6).Value
                            Dim temp As String = f.Cells(4).Value
                            Dim temp2 As String = temp.Replace(",", ".")
                            Dim fJumlah As Double = CDbl(Val(temp2))
                            insertDReturJual(TextBox1.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, fHarga, fJumlah, fDiskon, fDiskon)
                            totalHargaBarang += fDiskon
                            updateStok(fJumlah, f.Cells(0).Value)
                        End If
                    Next
                    updatePiutang(ComboBox1.SelectedValue, tgl, 0, staff, totalHargaBarang)
                    If lb_FullRetur.Visible = True And CInt(lb_Kekurangan.Text) <> 0 Then
                        MsgBox("Insert Pembayaran")
                    End If
                    LoadDataSet()
                    MsgBox("Sukses melakukan retur Jual barang")
                    clear()
                Else
                    MsgBox("Pastikan sudah ada barang yang dipilih atau jumlah barang tidak melebihi batas" & vbCrLf & "===================================" & vbCrLf & msg)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim totalRetur As Integer = 0
        maxQty = New ArrayList
        Try
            If ComboBox1.SelectedIndex <> -1 And formReady Then
                Dim TbSet As DataTable = getDetailBarangJual(ComboBox1.SelectedValue)

                Dim clonedDT As DataTable = TbSet.Clone()
                clonedDT.Columns("Jumlah").DataType = GetType(String)
                For Each row As DataRow In TbSet.Rows
                    clonedDT.ImportRow(row)
                Next

                dgv.DataSource = clonedDT
                For Each f As DataGridViewRow In Me.dgv.Rows
                    maxQty.Add(f.Cells(4).Value)
                Next
                Label4.Text = getNamaPelanggan(ComboBox1.SelectedValue)
                Dim AL As String = getDetailTagihan(ComboBox1.SelectedValue)
                Dim x() As String = AL.Split("-")
                lb_TotalTagihan.Text = FormatCurrency(x(3))
                lb_PembayaranDiterima.Text = FormatCurrency(x(4))
                lb_Kekurangan.Text = FormatCurrency(x(5))
                If (CInt(x(7)) < CInt(x(6))) Then
                    totalRetur = x(7)
                Else
                    totalRetur = x(6)
                End If
                lb_totalretur.Text = FormatCurrency(totalRetur)
                setGv()
                cekTotal()
            End If
        Catch ex As Exception
#If DEBUG Then
            MsgBox(ex.ToString)
#Else
        CheckBox4.Enabled = False
#End If
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New ReturJualCariNota
        If f.ShowDialog = DialogResult.OK Then
            ComboBox1.SelectedValue = f.pilihanNota
        End If
    End Sub


    'dgv
    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        Try
            Dim temp As String = dgv.Rows(e.RowIndex).Cells(4).Value
            Dim temp2 As String = temp.Replace(",", ".")
            Dim fJumlah As Double = CDbl(Val(temp2))
            dgv.Rows(e.RowIndex).Cells(6).Value = (dgv.Rows(e.RowIndex).Cells(3).Value - dgv.Rows(e.RowIndex).Cells(5).Value) * fJumlah
            cekTotal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        If (dgv.CurrentCell.ColumnIndex = 4) Then 'put columnindextovalidate
            RemoveHandler e.Control.KeyPress, AddressOf ValidateKeyPress
            AddHandler e.Control.KeyPress, AddressOf ValidateKeyPress
        End If
    End Sub

    Private Sub ValidateKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Asc(e.KeyChar) <> 45 AndAlso Asc(e.KeyChar) <> 46 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    'Function and Procedure
    Sub cekTotal()
        Dim JumlahUangRetur = 0, BnykJenisBarang = 0, BnykBarang As Double = 0
        For Each f In dgv.Rows
            Dim temp As String = f.Cells(4).Value
            Dim temp2 As String = temp.Replace(",", ".")
            Dim fJumlah As Double = CDbl(Val(temp2))

            BnykJenisBarang += 1
            BnykBarang += fJumlah
            JumlahUangRetur += f.cells(6).value
        Next
        lb_TotalUangyangSudahDiretur.Text = FormatCurrency(TotalUangSudahDiRetur(ComboBox1.SelectedValue))
        lb_BanyakJenisBarang.Text = BnykJenisBarang
        lb_TotalJumlahBarang.Text = BnykBarang

        If (CInt(lb_Kekurangan.Text) - JumlahUangRetur >= 1) Then
            lb_TotalUangYangDikembalikan.Text = 0
        Else
            lb_TotalUangYangDikembalikan.Text = FormatCurrency(CStr(JumlahUangRetur - CInt(lb_Kekurangan.Text)))
        End If

        'If ((CInt(lb_PembayaranDiterima.Text) - CInt(lb_TotalUangyangSudahDiretur.Text)) - JumlahUangRetur) <= 0 Then
        '    lb_TotalUangYangDikembalikan.Text = FormatCurrency((CInt(lb_PembayaranDiterima.Text) - CInt(lb_TotalUangyangSudahDiretur.Text)))
        'Else
        '    lb_TotalUangYangDikembalikan.Text = FormatCurrency(JumlahUangRetur)
        'End If
        If (JumlahUangRetur + CInt(lb_TotalUangyangSudahDiretur.Text) = CInt(lb_TotalTagihan.Text)) Then
            lb_FullRetur.Visible = True
        Else
            lb_FullRetur.Visible = False
        End If

    End Sub

    Sub setGv()
        Dim temp As Double = dgv.Size.Width
        dgv.Columns(0).Width = temp * 0.19
        dgv.Columns(1).Width = temp * 0.3
        dgv.Columns(2).Width = temp * 0.1
        dgv.Columns(3).Width = temp * 0.1
        dgv.Columns(4).Width = temp * 0.1
        dgv.Columns(5).Width = temp * 0.1
        dgv.Columns(6).Width = temp * 0.1
        dgv.Columns(0).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(2).ReadOnly = True
        dgv.Columns(3).ReadOnly = True
        dgv.Columns(5).ReadOnly = True
        dgv.Columns(6).ReadOnly = True
        dgv.Columns(0).HeaderText = "Kode Barang"
        dgv.Columns(1).HeaderText = "Nama Barang"
        dgv.Columns(2).HeaderText = "Satuan"
        dgv.Columns(3).HeaderText = "Harga"
        dgv.Columns(4).HeaderText = "Jumlah"
        dgv.Columns(5).HeaderText = "Diskon"
        dgv.Columns(6).HeaderText = "Subtotal"
    End Sub

    Sub clear()
        Try
            ComboBox1.DataSource = getDataTB("HJx.NoNotaJual", "HJual HJx, DJual DJx", "HJx.NoNotaJual=DJx.NoNotaJual and DJx.Jumlah <> ISNULL((select sum(DRJ.Jumlah) From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0)", "HJx.TglNota DESC", "HJx.NoNotaJual, HJx.TglNota")
            ComboBox1.ValueMember = "NoNotaJual"
            ComboBox1.SelectedIndex = -1
            DateTimePicker1.MaxDate = Now
            TextBox1.Text = getNotaReturJual()
            ComboBox1.SelectedIndex = 0
            cekTotal()
        Catch ex As Exception
            'MsgBox(ex.ToString)
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

    Function ReverseFormatCurrency(xx As String)
        Dim s As Integer = 0
        For i = 0 To xx.Length - 1
            If xx.Substring(i, 1) = "0" Then
                s += 1
            End If
        Next
        s = CInt(xx) * (10 ^ s)
        Return s
    End Function
End Class