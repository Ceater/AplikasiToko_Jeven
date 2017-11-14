Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModulePembelian
    Function getDetailBarangTerima(Nota As String) As DataSet
        Dim output As New DataSet
        SqlAdapter = New SqlDataAdapter("select IDBarang, NamaBarang, Satuan, Jumlah from Pembelian where NoNotaTerima = '" & Nota & "'", constring)
        SqlAdapter.Fill(output, "DataPembelian")
        Return output
    End Function
End Module