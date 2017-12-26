Imports System.Data.SqlClient

Public Class ReturJualCariNota
    Friend pilihanNota As String = ""
    Dim Dset As New DataSet

    Private Sub ReturJualCariNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createDSet()
        DataGridView1.DataSource = Dset.Tables("DataNotaSiapReturJual")
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If ComboBox1.SelectedIndex = 0 Then
            searchDSet(1, sender.text)
        Else
            searchDSet(2, sender.text)
        End If
        DataGridView1.DataSource = Dset.Tables("DataNotaSiapReturJual")
        DataGridView1.Refresh()
    End Sub

    Sub createDSet()
        constring.Open()
        SqlAdapter = New SqlDataAdapter("select NoNotaJual, NamaPelanggan  from HJual except select HJ.NoNotaJual, HJ.NamaPelanggan from HJual HJ, HReturJual HTJ where HJ.NoNotaJual = HTJ.NoNotaJual", constring)
        SqlAdapter.Fill(Dset, "DataNotaSiapReturJual")
        constring.Close()
    End Sub

    Sub searchDSet(ByVal pil As Integer, ByVal keyword As String)
        constring.Open()
        Dset.Clear()
        If pil = 2 Then
            SqlAdapter = New SqlDataAdapter("select NoNotaJual, NamaPelanggan from HJual where NoNotaJual Like '%" & keyword & "%' except select HJ.NoNotaJual, HJ.NamaPelanggan from HJual HJ, HReturJual HTJ where HJ.NoNotaJual = HTJ.NoNotaJual", constring)
            SqlAdapter.Fill(Dset, "DataNotaSiapReturJual")
        Else
            SqlAdapter = New SqlDataAdapter("select NoNotaJual, NamaPelanggan from HJual where NamaPelanggan Like '%" & keyword & "%' except select HJ.NoNotaJual, HJ.NamaPelanggan from HJual HJ, HReturJual HTJ where HJ.NoNotaJual = HTJ.NoNotaJual", constring)
            SqlAdapter.Fill(Dset, "DataNotaSiapReturJual")
        End If
        constring.Close()
    End Sub

    Sub setGV()
        DataGridView1.Columns(0).HeaderText = "Nomer Nota"
        DataGridView1.Columns(1).HeaderText = "Nama Pelanggan"
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            pilihanNota = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception

        End Try
    End Sub
End Class