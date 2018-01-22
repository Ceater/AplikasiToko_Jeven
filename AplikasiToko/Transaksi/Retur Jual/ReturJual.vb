Public Class ReturJual
    Dim staff As String = ""
    Public Sub New(ByVal id As String)
        InitializeComponent()
        staff = id
    End Sub

    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            ComboBox1.DataSource = DSet.Tables("ReturJualDataNotaJual")
            ComboBox1.ValueMember = "NoNotaJual"
            ComboBox1.SelectedIndex = 1
            ComboBox1.SelectedIndex = 0
            DateTimePicker1.MaxDate = Now
            TextBox1.Text = getNotaReturJual()
            clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count As Integer = 0
        Dim result As Integer = MessageBox.Show("Apakah semua barang sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            For Each selectedItem As DataGridViewRow In dgv.SelectedRows
                count += 1
            Next selectedItem
            If cekNotaReturJual(TextBox1.Text) Then
                MsgBox("Nomer Nota Sudah Pernah Digunakan")
            Else
                If count <> 0 Then
                    Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                    insertHReturJual(TextBox1.Text, ComboBox1.SelectedValue, tgl, staff)
                    For Each f As DataGridViewRow In Me.dgv.Rows
                        If f.Selected Then
                            insertDReturJual(TextBox1.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, f.Cells(3).Value, f.Cells(4).Value, f.Cells(5).Value, f.Cells(6).Value)
                            updateStok(f.Cells(4).Value, f.Cells(0).Value)
                        End If
                    Next
                    LoadDataSet()
                    MsgBox("Sukses melakukan retur Jual barang")
                    clear()
                Else
                    MsgBox("Pastikan sudah ada barang yang dipilih")
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            dgv.DataSource = getDetailBarangJual(ComboBox1.SelectedValue)
            Label4.Text = getNamaPelanggan(ComboBox1.SelectedValue)
            Dim AL As String = getDetailTagihan(ComboBox1.SelectedValue)
            Dim x() As String = AL.Split("-")
            lb_TotalTagihan.Text = FormatCurrency(x(3))
            lb_PembayaranDiterima.Text = FormatCurrency(x(4))
            lb_Kekurangan.Text = FormatCurrency(x(5))
            lb_TotalUangYangDikembalikan.Text = FormatCurrency(x(4))
            setGv()
        Catch ex As Exception
            'MsgBox(ex.ToString)
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
        dgv.Rows(e.RowIndex).Cells(6).Value = (dgv.Rows(e.RowIndex).Cells(3).Value - dgv.Rows(e.RowIndex).Cells(5).Value) * dgv.Rows(e.RowIndex).Cells(4).Value
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
            TextBox1.Text = getNotaReturJual()
            DateTimePicker1.Value = Now
            ComboBox1.SelectedIndex = 0
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
End Class