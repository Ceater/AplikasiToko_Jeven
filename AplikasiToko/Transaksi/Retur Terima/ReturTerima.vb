Public Class ReturTerima
    Dim staff As String = ""
    Dim DataBarang(99) As Integer
    Dim nomorNotaTerima As String = ""

    Public Sub New(ByVal id As String)
        InitializeComponent()
        staff = id
    End Sub

    Private Sub ReturTerima_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            DateTimePicker1.MaxDate = Now
            TextBox1.Text = getNotaReturTerima()
            ComboBox1.DataSource = getListNotaBisaRetur()
            ComboBox1.ValueMember = "NoNotaTerima"
            ComboBox1.SelectedIndex = 1
            ComboBox1.SelectedIndex = 0
            clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count = 0, idx As Integer = 0
        Dim result As Integer = MessageBox.Show("Apakah semua barang sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
        Dim msg = "", errmsg As String = ""
        Dim QtyOk As Boolean = True

        TextBox1.Text = getNotaReturTerima()
        If result = DialogResult.Yes Then
            For Each selectedItem As DataGridViewRow In DataGridView1.SelectedRows
                count += 1
            Next selectedItem
            If cekNotaReturTerima(TextBox1.Text) Then
                MsgBox("Nomer Nota Sudah Pernah Digunakan")
            Else
                If count <> 0 Then
                    msg = "Berikut Adalah Barang Diretur" & vbCrLf & "================================" & vbCrLf
                    For Each f As DataGridViewRow In Me.DataGridView1.Rows
                        If f.Cells(3).Value >= 1 Then
                            If (DataBarang(idx) < f.Cells(3).Value) Then
                                QtyOk = False
                                errmsg = "Error, Cek Max Retur Barang Berikut" & vbCrLf & "================================" & vbCrLf
                                errmsg &= "Kode: " & f.Cells(0).Value & " |  Nama: " & f.Cells(1).Value & " | Jumlah: " & f.Cells(3).Value & " | Max Retur: " & DataBarang(idx) & vbCrLf
                            Else
                                msg &= "Kode: " & f.Cells(0).Value & " |  Nama: " & f.Cells(1).Value & " | Jumlah: " & f.Cells(3).Value & vbCrLf
                            End If
                            idx += 1
                        End If
                    Next
                    msg &= "================================" & vbCrLf & "Apakah Barang Diatas Sudah Benar?"
                    result = DialogResult.No
                    If (QtyOk) Then
                        result = MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo)
                    Else
                        MsgBox(errmsg)
                    End If
                    If result = DialogResult.Yes Then
                        Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
                        insertHReturTerima(TextBox1.Text, ComboBox1.SelectedValue, tgl, staff, Label6.Text, Label7.Text)
                        For Each f As DataGridViewRow In Me.DataGridView1.Rows
                            If f.Cells(3).Value >= 1 Then
                                insertDReturTerima(TextBox1.Text, f.Cells(0).Value, f.Cells(1).Value, f.Cells(2).Value, f.Cells(3).Value)
                                updateSuksesRetur(nomorNotaTerima, f.Cells(0).Value)
                                updateStok(-f.Cells(3).Value, f.Cells(0).Value)
                            End If
                        Next
                        LoadDataSet()
                        MsgBox("Sukses melakukan retur terima barang")
                        clear()
                    End If
                Else
                    MsgBox("Pastikan sudah ada barang yang dipilih")
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim counter As Integer = 0
            Dim DT As DataTable = getDetailBarangRetur(ComboBox1.SelectedValue)
            Dim DetailNota As Array = getDetailNotaRetur(ComboBox1.SelectedValue)

            Label6.Text = DetailNota(0)
            Label11.Text = DetailNota(1)
            Label7.Text = DetailNota(2)
            Label10.Text = DetailNota(3)

            nomorNotaTerima = DetailNota(0)
            DataGridView1.DataSource = DT
            setGv()
            For Each f As DataRow In DT.Rows
                DataBarang(counter) = f("jumlah")
                counter += 1
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub setGv()
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.2
        DataGridView1.Columns(1).Width = temp * 0.45
        DataGridView1.Columns(2).Width = temp * 0.15
        DataGridView1.Columns(3).Width = temp * 0.15
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(0).HeaderText = "Kode Barang"
        DataGridView1.Columns(1).HeaderText = "Nama Barang"
        DataGridView1.Columns(2).HeaderText = "Satuan"
        DataGridView1.Columns(3).HeaderText = "Jumlah"
    End Sub

    Sub clear()
        Try
            TextBox1.Text = getNotaReturTerima()
            DateTimePicker1.Value = Now
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
End Class