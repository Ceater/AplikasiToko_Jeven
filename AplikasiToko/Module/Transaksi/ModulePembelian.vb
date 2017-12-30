Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModulePembelian
    Function getDetailBarangTerima(Nota As String) As DataSet
        Dim output As New DataSet
        SqlAdapter = New SqlDataAdapter("select IDBarang, NamaBarang, Satuan, Jumlah from Pembelian where NoNotaTerima = '" & Nota & "'", constring)
        SqlAdapter.Fill(output, "DataPembelian")
        Return output
    End Function

    Sub insertHPembelian(NoPembelian As String, NotaTerima As String, GrandTotal As Double)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into HPembelian values(" & NoPembelian & ",'" & NotaTerima & "'," & GrandTotal & ")", constring)
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Sub insertDPembelian(NoPembelian As String, KodeBarang As String, NamaBarang As String, Satuan As String, HargaSatuan As Double, Jumlah As Double, SubTotal As Double)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into DPembelian Values(" & NoPembelian & ", '" & KodeBarang & "', '" & NamaBarang & "', '" & Satuan & "', " & HargaSatuan & "," & Jumlah & ", " & SubTotal & ")", constring)
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Function getLastNoPembelian() As Double
        Dim hsl As Double = 0
        Try
            constring.Open()
            cmd = New SqlCommand("select NoPembelian from HPembelian order by NoPembelian desc", constring)
            hsl = cmd.ExecuteScalar + 1
            constring.Close()
        Catch ex As Exception
            hsl = 1
            constring.Close()
        End Try
        Return hsl
    End Function
End Module