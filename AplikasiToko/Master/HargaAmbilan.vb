Public Class HargaAmbilan

    Private Sub HargaAmbilan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As New DataSet
        x = getDataTBDSet("tb.KodeBarang, tb.NamaBarang, CONVERT(VARCHAR, ISNULL(dp.HargaSatuan, 0))", "TbBarang tb LEFT JOIN DPembelian dp ON tb.KodeBarang=dp.IDBarang")
        For Each dr As DataRow In x.Tables("result").Rows
            dr(2) = "Rp. " & FormatCurrency(dr(2))
        Next
        DataGridView1.DataSource = x.Tables("result")
        setGV()
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        Dim x As New DataSet
        Dim temp As String = SqlSafe(TextBox1.Text)
        x = getDataTBDSet("tb.KodeBarang, tb.NamaBarang, CONVERT(VARCHAR, ISNULL(dp.HargaSatuan, 0))", "TbBarang tb LEFT JOIN DPembelian dp ON tb.KodeBarang=dp.IDBarang", "(tb.KodeBarang LIKE '%" & temp & "%' OR tb.NamaBarang LIKE '%" & temp & "%')")
        For Each dr As DataRow In x.Tables("result").Rows
            dr(2) = "Rp. " & FormatCurrency(dr(2))
        Next
        DataGridView1.DataSource = x.Tables("result")
        setGV()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x As New DataSet
        Dim temp As String = SqlSafe(TextBox1.Text)
        x = getDataTBDSet("tb.KodeBarang, tb.NamaBarang, CONVERT(VARCHAR, ISNULL(dp.HargaSatuan, 0))", "TbBarang tb LEFT JOIN DPembelian dp ON tb.KodeBarang=dp.IDBarang", "(tb.KodeBarang LIKE '%" & temp & "%' OR tb.NamaBarang LIKE '%" & temp & "%')")
        For Each dr As DataRow In x.Tables("result").Rows
            dr(2) = "Rp. " & FormatCurrency(dr(2))
        Next
        DataGridView1.DataSource = x.Tables("result")
        setGV()
    End Sub

    Sub setGV()
        DataGridView1.Columns(0).HeaderText = "Kode Barang"
        DataGridView1.Columns(1).HeaderText = "Nama Barang"
        DataGridView1.Columns(2).HeaderText = "Harga Ambilan"
        Dim temp As Double = DataGridView1.Size.Width
        DataGridView1.Columns(0).Width = temp * 0.25
        DataGridView1.Columns(1).Width = temp * 0.48
        DataGridView1.Columns(2).Width = temp * 0.21
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