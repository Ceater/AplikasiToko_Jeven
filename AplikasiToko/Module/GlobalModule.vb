Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System
Imports System.IO

Module GlobalModule
    Public DSet As New DataSet
    Public SqlAdapter As SqlDataAdapter

    Sub LoadSetting(TipeServer As Integer)
        Dim filepath As String = "C:\AplikasiToko\setting.txt"
        Dim x1, x2, x3, x4, x5 As String
        Try
            Dim sr As StreamReader = New StreamReader(filepath)
            x5 = sr.ReadLine()
            x1 = sr.ReadLine()
            x2 = sr.ReadLine()
            x3 = sr.ReadLine()
            x4 = sr.ReadLine()
            setKoneksi(TipeServer, x1, x2, x3, x4)
            sr.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Sub LoadDataSet()
        DSet.Clear()
        Try
            If constring.State = ConnectionState.Open Then
                constring.Close()
            End If
            constring.Open()
            SqlAdapter = New SqlDataAdapter("select tb.KodeBarang, NamaBarang, Stok, NamaSatuan, HargaNormal, HargaToko, Hargasales,  StokPengingat from TbBarang tb, TbSatuan ts where tb.SatuanBarang = ts.KodeSatuan", constring)
            SqlAdapter.Fill(DSet, "DataBarang")
            SqlAdapter = New SqlDataAdapter("select * from TbSatuan", constring)
            SqlAdapter.Fill(DSet, "DataSatuan")
            SqlAdapter = New SqlDataAdapter("select * from TbStaff", constring)
            SqlAdapter.Fill(DSet, "DataStaff")
            SqlAdapter = New SqlDataAdapter("select * from TbPelanggan", constring)
            SqlAdapter.Fill(DSet, "DataPelanggan")
            SqlAdapter = New SqlDataAdapter("select NoNotaJual from HJual", constring)
            SqlAdapter.Fill(DSet, "DataNotaPenjualan")
            SqlAdapter = New SqlDataAdapter("select NoNotaTerima from HTerima except select HT.NoNotaTerima from HTerima HT, HReturTerima HTR where HT.NoNotaTerima = HTR.NoNotaTerima UNION select Dr.NoNotaTerima from (select HT.NoNotaTerima, DT.IDBarang from HTerima HT, DTerima DT, HReturTerima HTR where HT.NoNotaTerima = HTR.NoNotaTerima and HT.NoNotaTerima = DT.NoNOtaTerima Except select HTR.NoNotaTerima, DTR.IdBarang from HReturTerima HTR, DReturTerima DTR where HTR.NoNotaReturTerima = DTR.NoNotaReturTerima) DR group by Dr.NoNotaTerima except select NoNotaTerima from HPembelian", constring)
            SqlAdapter.Fill(DSet, "DataNotaTerima")
            SqlAdapter = New SqlDataAdapter("select tb.KodeBarang, NamaBarang from TbBarang tb, TbSatuan ts where tb.SatuanBarang = ts.KodeSatuan and Stok<=StokPengingat", constring)
            SqlAdapter.Fill(DSet, "DataStokMinim")
            SqlAdapter = New SqlDataAdapter("select NoNotaTerima from HTerima except select HT.NoNotaTerima from HTerima HT, HReturTerima HTR where HT.NoNotaTerima = HTR.NoNotaTerima UNION select Dr.NoNotaTerima from (select HT.NoNotaTerima, DT.IDBarang from HTerima HT, DTerima DT, HReturTerima HTR where HT.NoNotaTerima = HTR.NoNotaTerima and HT.NoNotaTerima = DT.NoNOtaTerima Except select HTR.NoNotaTerima, DTR.IdBarang from HReturTerima HTR, DReturTerima DTR where HTR.NoNotaReturTerima = DTR.NoNotaReturTerima) DR group by Dr.NoNotaTerima except select NoNotaTerima from HPembelian", constring)
            SqlAdapter.Fill(DSet, "DataPembelian")
            SqlAdapter = New SqlDataAdapter("select NoNotaJual, NamaPelanggan  from HJual except select HJ.NoNotaJual, HJ.NamaPelanggan from HJual HJ, HReturJual HTJ where HJ.NoNotaJual = HTJ.NoNotaJual", constring)
            SqlAdapter.Fill(DSet, "DataNotaSiapReturJual")
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub
End Module
