Public Class ReturJual
    Dim staff As String = ""
    Public Sub New(ByVal id As String)
        InitializeComponent()
        staff = id
    End Sub

    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            ComboBox1.DataSource = DSet.Tables("DataNotaPenjualan")
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
            For Each selectedItem As DataGridViewRow In DataGridView1.SelectedRows
                count += 1
            Next selectedItem
            If cekNotaReturJual(TextBox1.Text) Then
                MsgBox("Nomer Nota Sudah Pernah Digunakan")
            Else
                If count <> 0 Then
                    Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                    insertHReturJual(TextBox1.Text, ComboBox1.SelectedValue, tgl, staff)
                    For Each f As DataGridViewRow In Me.DataGridView1.Rows
                        If f.Selected Then
                            insertDReturJual(TextBox1.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, f.Cells(3).Value, f.Cells(4).Value, f.Cells(5).Value, f.Cells(6).Value)
                            updateStok(f.Cells(4).Value, f.Cells(0).Value)
                        End If
                    Next
                    MsgBox(constring.State.ToString)
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
            DataGridView1.DataSource = getDetailBarangJual(ComboBox1.SelectedValue)
            Label4.Text = getNamaPelanggan(ComboBox1.SelectedValue)
            setGv()
        Catch ex As Exception
        End Try
    End Sub

    Sub setGv()
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.19
        DataGridView1.Columns(1).Width = temp * 0.3
        DataGridView1.Columns(2).Width = temp * 0.1
        DataGridView1.Columns(3).Width = temp * 0.1
        DataGridView1.Columns(4).Width = temp * 0.1
        DataGridView1.Columns(5).Width = temp * 0.1
        DataGridView1.Columns(6).Width = temp * 0.1
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.Columns(5).ReadOnly = True
        DataGridView1.Columns(6).ReadOnly = True
        DataGridView1.Columns(0).HeaderText = "Kode Barang"
        DataGridView1.Columns(1).HeaderText = "Nama Barang"
        DataGridView1.Columns(2).HeaderText = "Satuan"
        DataGridView1.Columns(3).HeaderText = "Harga"
        DataGridView1.Columns(4).HeaderText = "Jumlah"
        DataGridView1.Columns(5).HeaderText = "Diskon"
        DataGridView1.Columns(6).HeaderText = "Subtotal"
    End Sub

    Sub clear()
        Try
            TextBox1.Text = getNotaReturJual()
            DateTimePicker1.Value = Now
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New ReturJualCariNota
        If f.ShowDialog = DialogResult.OK Then
            ComboBox1.SelectedValue = f.pilihanNota
        End If
    End Sub
End Class