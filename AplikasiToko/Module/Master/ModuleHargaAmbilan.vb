Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleHargaAmbilan
    Function getData(keyword As String) As DataSet
        keyword = "%" & keyword & "%"
        Dim result As New DataSet
        Dim adpter As New SqlDataAdapter

        constring.Open()
        Try
            adpter.SelectCommand = New SqlCommand("SELECT tb.KodeBarang, tb.NamaBarang, ISNULL(dp.HargaSatuan, 0) as HargaAmbilan FROM TbBarang tb LEFT JOIN DPembelian dp ON tb.KodeBarang=dp.IDBarang WHERE (tb.KodeBarang LIKE @a) OR (tb.NamaBarang LIKE @b)", constring)
            adpter.SelectCommand.Parameters.Add("@a", SqlDbType.VarChar, 25, "%")
            adpter.SelectCommand.Parameters.Add("@b", SqlDbType.VarChar, 25, "%")
            adpter.Fill(result, "DataAmbilan")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        constring.Close()
        Return result
    End Function
End Module
