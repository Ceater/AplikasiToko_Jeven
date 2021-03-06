﻿Public Class Pembelian
    Dim dtable As DataTable
    Dim drow As DataRow
    Dim formReady As Boolean = False

    Private Sub Pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            loadNotaTerima("Nama Supplier")
            loadListBox()
            formReady = True

            ComboBox1.SelectedIndex = 0
            ListBox1.SelectedIndex = -1
        Catch ex As Exception
            If stage = 1 Then
                MsgBox(ex.ToString)
            End If
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            If formReady Then
                'IDBarang, NamaBarang, Satuan, Jumlah
                dtable = getDetailBarangTerima(ListBox1.SelectedItem).Tables("DataPembelian")
                dtable.Columns(0).ColumnName = "Kode Barang"
                dtable.Columns(1).ColumnName = "Nama Barang"
                dtable.Columns(2).ColumnName = "Satuan"
                dtable.Columns(3).ColumnName = "Jumlah"
                dtable.Columns.Add("Harga Satuan")
                dtable.Columns.Add("Subtotal")
                'Max size 600
                DataGridView1.DataSource = dtable
                Dim temp As Double = DataGridView1.Size.Width
                DataGridView1.Columns(0).Width = temp * 0.15
                DataGridView1.Columns(1).Width = temp * 0.29
                DataGridView1.Columns(2).Width = temp * 0.1
                DataGridView1.Columns(3).Width = temp * 0.1
                DataGridView1.Columns(4).Width = temp * 0.15
                DataGridView1.Columns(5).Width = temp * 0.15
                DataGridView1.Columns(0).ReadOnly = True
                DataGridView1.Columns(1).ReadOnly = True
                DataGridView1.Columns(2).ReadOnly = True
                DataGridView1.Columns(3).ReadOnly = True
                DataGridView1.Columns(5).ReadOnly = True
                For Each f In DataGridView1.Rows
                    f.cells(4).value = 0
                Next
                hitungTotalBarang()
                Label7.Text = getTglJatuhTempo(ListBox1.SelectedItem)
            End If
        Catch ex As Exception
            If stage = 1 Then
                MsgBox(ex.ToString)
            End If
        End Try
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If (DataGridView1.CurrentCell.ColumnIndex = 4) Then 'put columnindextovalidate
            RemoveHandler e.Control.KeyPress, AddressOf ValidateKeyPress
            AddHandler e.Control.KeyPress, AddressOf ValidateKeyPress
        End If
    End Sub

    Private Sub ValidateKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        drow = dtable.Rows(DataGridView1.CurrentCell.RowIndex)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim x, x1 As Integer
        x = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        x1 = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        DataGridView1.Rows(e.RowIndex).Cells(5).Value = FormatCurrency(CStr(x * x1))
        hitungTotalBayar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        hitungTotalBayar()
        Dim noPembelian As Integer = getLastNoPembelian()
        Dim tanggalan As String = DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day
        If MsgBox("Apakah Kamu Yakin?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            insertHPembelian(noPembelian, ListBox1.SelectedItem, Label2.Text, tanggalan)
            Dim rows As Integer = 0
            For Each f In DataGridView1.Rows
                insertDPembelian(noPembelian, f.cells(0).Value, f.cells(1).Value, f.cells(2).Value, f.cells(4).Value, f.cells(3).Value, f.cells(5).Value)
                rows += 1
            Next
            LoadDataSet()
            MsgBox("Transaksi Berhasil")
        End If
    End Sub

    Private Sub searchNota(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If formReady Then
            loadListBox()
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        If formReady Then
            loadListBox()
        End If
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

    Sub hitungTotalBayar()
        Try
            Dim tot As Integer
            For Each f In DataGridView1.Rows
                tot = f.cells(5).Value + tot
            Next
            Label2.Text = FormatCurrency(tot)
        Catch ex As Exception

        End Try
    End Sub

    Sub hitungTotalBarang()
        Try
            Dim tot As Integer
            For Each f In DataGridView1.Rows
                tot = f.cells(3).Value + tot
            Next
            Label4.Text = tot
        Catch ex As Exception

        End Try
    End Sub

    Sub loadListBox()
        Dim hasil As ArrayList = loadNotaTerima(ComboBox1.SelectedItem, TextBox2.Text)
        ListBox1.Items.Clear()
        If hasil.Count <> 0 Then
            For i = 0 To hasil.Count - 1
                ListBox1.Items.Add(hasil.Item(i))
            Next
            ListBox1.SelectedIndex = 0
        Else
        End If
    End Sub
End Class