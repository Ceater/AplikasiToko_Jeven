Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleReturJual
    Function getDetailBarangJual(ByVal NoNota As String) As DataTable
        Dim result As New DataSet
        constring.Open()
        Dim cmd As String = "select DT.IDBarang, DT.NamaBarang, DT.Satuan, DT.Jumlah from HTerima HT, DTerima DT where HT.NoNotaTerima = DT.NoNotaTerima and HT.NoNotaTerima = '" & NoNota & "' EXCEPT select DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.Jumlah  from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and HRT.NoNotaTerima = '" & NoNota & "'"
        SqlAdapter = New SqlDataAdapter(cmd, constring)
        SqlAdapter.Fill(result, "Hasil")
        constring.Close()
        Return result.Tables("Hasil")
    End Function
End Module
