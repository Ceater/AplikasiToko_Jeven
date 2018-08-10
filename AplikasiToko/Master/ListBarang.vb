Public Class ListBarang
    Private Sub ListBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As New DataSet
        x = getDataTBDSet("KodeBarang, NamaBarang, Stok, NamaSatuan, CONVERT(VARCHAR, HargaNormal), CONVERT(VARCHAR, HargaToko), CONVERT(VARCHAR, HargaSales), StokPengingat", "TbBarang tb INNER JOIN TbSatuan ts ON tb.SatuanBarang=ts.KodeSatuan")
        For Each dr As DataRow In x.Tables("result").Rows
            dr(4) = "Rp. " & FormatCurrency(dr(4))
            dr(5) = "Rp. " & FormatCurrency(dr(5))
            dr(6) = "Rp. " & FormatCurrency(dr(6))
        Next
        DataGridView1.DataSource = x.Tables("result")
        setGV()
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        Dim x As New DataSet
        Dim temp As String = SqlSafe(TextBox1.Text)
        x = getDataTBDSet("KodeBarang, NamaBarang, Stok, NamaSatuan, CONVERT(VARCHAR, HargaNormal), CONVERT(VARCHAR, HargaToko), CONVERT(VARCHAR, HargaSales), StokPengingat", "TbBarang tb INNER JOIN TbSatuan ts ON tb.SatuanBarang=ts.KodeSatuan", "(KodeBarang LIKE '%" & temp & "%' OR NamaBarang LIKE '%" & temp & "%')")
        For Each dr As DataRow In x.Tables("result").Rows
            dr(4) = "Rp. " & FormatCurrency(dr(4))
            dr(5) = "Rp. " & FormatCurrency(dr(5))
            dr(6) = "Rp. " & FormatCurrency(dr(6))
        Next
        DataGridView1.DataSource = x.Tables("result")
        setGV()
    End Sub

    Sub setGV()
        DataGridView1.Columns(0).HeaderText = "Kode"
        DataGridView1.Columns(1).HeaderText = "Nama Barang"
        DataGridView1.Columns(2).HeaderText = "Stok"
        DataGridView1.Columns(3).HeaderText = "Satuan"
        DataGridView1.Columns(4).HeaderText = "Harga Normal"
        DataGridView1.Columns(5).HeaderText = "Harga Toko"
        DataGridView1.Columns(6).HeaderText = "Harga Sales"
        DataGridView1.Columns(7).HeaderText = "Pengingat"
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.1
        DataGridView1.Columns(1).Width = temp * 0.3
        DataGridView1.Columns(2).Width = temp * 0.07
        DataGridView1.Columns(3).Width = temp * 0.1
        DataGridView1.Columns(4).Width = temp * 0.1
        DataGridView1.Columns(5).Width = temp * 0.1
        DataGridView1.Columns(6).Width = temp * 0.1
        DataGridView1.Columns(7).Width = temp * 0.1
        DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
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
End Class