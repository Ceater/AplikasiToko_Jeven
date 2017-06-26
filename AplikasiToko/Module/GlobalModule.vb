Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System
Imports System.IO

Module GlobalModule
    Public constring As New SqlConnection("")
    Public DSet As New DataSet
    Public cmd As SqlCommand
    Public SqlAdapter As SqlDataAdapter

    Sub LoadSetting()
        Dim filepath As String = Directory.GetCurrentDirectory & "\setting.txt"
        Dim x1, x2, x3, x4 As String
        Try
            Dim sr As StreamReader = New StreamReader(filepath)
            x1 = sr.ReadLine()
            x2 = sr.ReadLine()
            x3 = sr.ReadLine()
            x4 = sr.ReadLine()
            Dim con As String = "Server=" & x1 & "\" & x2 & ";Database=DatabaseToko;User Id=" & x3 & ";Password=" & x4 & ";"
            constring = New SqlConnection(con)
        Catch ex As Exception
            MsgBox("Database tidak ditemukan")
        End Try

        Try
            constring.Open()
            constring.Close()
        Catch ex As Exception
            MsgBox("Pengaturan Salah")
        End Try
    End Sub

    Sub LoadDataSet()
        DSet.Clear()
        Try
            constring.Open()
            SqlAdapter = New SqlDataAdapter("select tb.KodeBarang, NamaBarang, Stok, NamaSatuan, HargaSatuan,  StokPengingat from TbBarang tb, TbSatuan ts where tb.SatuanBarang = ts.KodeSatuan", constring)
            SqlAdapter.Fill(DSet, "DataBarang")
            SqlAdapter = New SqlDataAdapter("select * from TbSupplier", constring)
            SqlAdapter.Fill(DSet, "DataSupplier")
            SqlAdapter = New SqlDataAdapter("select IDKontakSupplier, NamaSupplier, NamaSales, TlpSales from TbKontakSupplier tk, TbSupplier ts where tk.IDSupplier = ts.IDSupplier", constring)
            SqlAdapter.Fill(DSet, "DataKontakSupplier")
            SqlAdapter = New SqlDataAdapter("select * from TbSatuan", constring)
            SqlAdapter.Fill(DSet, "DataSatuan")
            SqlAdapter = New SqlDataAdapter("select * from TbStaff", constring)
            SqlAdapter.Fill(DSet, "DataStaff")
            SqlAdapter = New SqlDataAdapter("select * from TbPelanggan", constring)
            SqlAdapter.Fill(DSet, "DataPelanggan")
            SqlAdapter = New SqlDataAdapter("select NoNotaJual from HJual", constring)
            SqlAdapter.Fill(DSet, "DataNotaPenjualan")
            SqlAdapter = New SqlDataAdapter("select tb.KodeBarang, NamaBarang, Stok, NamaSatuan, HargaSatuan,  StokPengingat from TbBarang tb, TbSatuan ts where tb.SatuanBarang = ts.KodeSatuan and Stok<=StokPengingat", constring)
            SqlAdapter.Fill(DSet, "DataStokMinim")
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub
End Module
