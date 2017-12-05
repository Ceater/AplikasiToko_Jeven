Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormLaporanLabaRugi
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FormLaporanLabaRugi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rep As New ReportDocument
        rep = New LaporanLabaRugi
        Dim PengeluaranLain As Integer = InputBox("Masukkan Jumlah Pengeluaran Lain", "Pengeluaran Lain-Lain", 0)
        rep.SetParameterValue("PenjualanBersih", getPenjualan)
        rep.SetParameterValue("ReturPenjualan", getReturPenjualan)
        rep.SetParameterValue("PersediaanAwal", getPersediaanAwal)
        rep.SetParameterValue("PersediaanAkhir", getPersediaanAkhir)
        rep.SetParameterValue("Pembelian", getPembelian)
        rep.SetParameterValue("PengeluaranLain", PengeluaranLain)
        crv.ReportSource = rep
        crv.Refresh()
    End Sub

    Function getPersediaanAwal()
        Dim hsl As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select TOP 1 PersediaanAwal from TbLabaRugi order by TglPersediaan Desc", constring)
            hsl = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function

    Function getPersediaanAkhir()
        Dim hsl As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select Sum(Stok * HargaSales) From TbBarang", constring)
            hsl = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function

    Function getPenjualan()
        Dim hsl As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select sum(grandtotal) from HJual where Month(TglNota)=@a and Year(tglNota)=@b", constring)
            cmd.Parameters.AddWithValue("@a", Now.Month)
            cmd.Parameters.AddWithValue("@b", Now.Year)
            hsl = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function

    Function getReturPenjualan()
        Dim hsl As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select sum(subtotal) from HReturJual HRJ, DReturJual DRJ where HRJ.NoNotaReturJual = DRJ.NoNotaReturJual and Month(HRJ.TglReturJual)=@a and Year(HRJ.TglReturJual)=@b", constring)
            cmd.Parameters.AddWithValue("@a", Now.Month)
            cmd.Parameters.AddWithValue("@b", Now.Year)
            hsl = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function

    Function getPembelian()
        Dim hsl As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select sum(GrandTotal) from HPembelian HP, HTerima HT where HP.NoNotaTerima = HT.NoNotaTerima and Month(HT.TglNota)=@a and Year(HT.TglNota)=@b", constring)
            cmd.Parameters.AddWithValue("@a", Now.Month)
            cmd.Parameters.AddWithValue("@b", Now.Year)
            hsl = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function
End Class