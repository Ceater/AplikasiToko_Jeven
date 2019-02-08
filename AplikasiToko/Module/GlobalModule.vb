Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System
Imports System.IO

Module GlobalModule
    Public DSet As New DataSet
    Public SqlAdapter As SqlDataAdapter
    Public userLogin As String
    Public VersiSekarang As String = "1.1.5.4"
    Public IntMonth = Month(Now), IntYear As Integer = Year(Now)
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
            SqlAdapter = New SqlDataAdapter("select * from TbPelanggan where TipePelanggan='Toko'", constring)
            SqlAdapter.Fill(DSet, "DataPelangganToko")
            SqlAdapter = New SqlDataAdapter("select * from TbPelanggan where TipePelanggan='Sales'", constring)
            SqlAdapter.Fill(DSet, "DataPelangganSales")
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
            SqlAdapter = New SqlDataAdapter(qstring2, constring)
            SqlAdapter.Fill(DSet, "ReturJualDataNotaJual")
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Sub AutoUpdatePersediaanAwal()
        Dim BulanTerakhir As Integer = getBulanTerakhirNumeric()
        If BulanTerakhir <> Now.Month Then
            setBulanBaru()
        End If
    End Sub

    Function SqlSafe(strInput As String) As String
        SqlSafe = Replace(strInput, "'", "''")
        SqlSafe = Replace(SqlSafe, """", """""")
    End Function

    Function dblConvertToVB(value As String)
        Dim x As String = value
        Dim res As Double = 0
        x = x.Replace(",", ".")
        res = CDbl(Val(x))
        Return x
    End Function

    Function dblConvertToSQL(value As String)
        Dim x As String = value
        x = x.Replace(",", ".")
        Return x
    End Function

    Function getDataTB(FieldName As String, TableName As String, Optional WhereKey As String = "", Optional OrderBy As String = "", Optional GroupBy As String = "")
        Dim query As String = "SELECT " & FieldName & " FROM " & TableName
        If WhereKey <> "" Then
            query &= " WHERE " & WhereKey
        End If
        If OrderBy <> "" Then
            query &= " GROUP By " & GroupBy
        End If
        If OrderBy <> "" Then
            query &= " ORDER By " & OrderBy
        End If
        Dim result As New DataSet
        Try
            constring.Open()
            SqlAdapter = New SqlDataAdapter(query, constring)
            SqlAdapter.Fill(result, "DataBarang")
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
        Return result.Tables("DataBarang")
    End Function

    Function getDataTBDSet(FieldName As String, TableName As String, Optional WhereKey As String = "", Optional OrderBy As String = "", Optional GroupBy As String = "")
        Dim result As New DataSet
        Dim query As String = "SELECT " & FieldName & " FROM " & TableName
        If WhereKey <> "" Then
            query &= " WHERE " & WhereKey
        End If
        If OrderBy <> "" Then
            query &= " OrderBy " & OrderBy
        End If
        SqlAdapter = New SqlDataAdapter(query, constring)
        SqlAdapter.Fill(result, "result")
        Return result
    End Function
End Module