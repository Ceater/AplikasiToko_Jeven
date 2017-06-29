Public Class ReturTerima
    Dim staff As String = ""
    Public Sub New(ByVal id As String)
        InitializeComponent()
        staff = id
    End Sub

    Private Sub ReturTerima_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ComboBox1.DataSource = DSet.Tables("DataNotaTerima")
        ComboBox1.ValueMember = "NoNotaTerima"
        ComboBox1.SelectedIndex = 1
        ComboBox1.SelectedIndex = 0
        DateTimePicker1.MaxDate = Now
        clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count As Integer = 0
        For Each selectedItem As DataGridViewRow In DataGridView1.SelectedRows
            count += 1
        Next selectedItem
        If cekNotaRetur(TextBox1.Text) Then
            MsgBox("Nomer Nota Sudah Pernah Digunakan")
        Else
            If count <> 0 Then
                Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                insertHReturTerima(TextBox1.Text, ComboBox1.SelectedValue, tgl, staff)
                For Each f As DataGridViewRow In DataGridView1.SelectedRows
                    insertDReturTerima(TextBox1.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, f.Cells(3).Value)
                Next f
                MsgBox("Sukses melakukan retur terima barang")
                clear()
            Else
                MsgBox("Pastikan sudah ada barang yang dipilih")
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            DataGridView1.DataSource = getDetailBarangRetur(ComboBox1.SelectedValue)
            setGv()
        Catch ex As Exception
        End Try
    End Sub

    Sub setGv()
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.18
        DataGridView1.Columns(1).Width = temp * 0.35
        DataGridView1.Columns(2).Width = temp * 0.25
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(0).HeaderText = "Kode Barang"
        DataGridView1.Columns(1).HeaderText = "Nama Barang"
        DataGridView1.Columns(2).HeaderText = "Satuan"
    End Sub

    Sub clear()
        Try
            TextBox1.Text = ""
            DateTimePicker1.Value = Now
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
End Class