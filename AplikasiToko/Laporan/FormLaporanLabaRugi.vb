Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FormLaporanLabaRugi
    Public Sub New()
        InitializeComponent()

    End Sub

    Function getPersediaanAwal()
        Dim hsl As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select PersediaanAwal from TbLabaRugi", constring)
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
            cmd = New SqlCommand("select sum(grandtotal) from HJual", constring)
            hsl = cmd.ExecuteScalar
        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function

    Function getRetur()
        Dim hsl As Integer = 0
        constring.Open()
        Try

        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function

    Function getPembelian()
        Dim hsl As Integer = 0
        constring.Open()
        Try

        Catch ex As Exception

        End Try
        constring.Close()
        Return hsl
    End Function
End Class