Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleReturBeli

    Function getDetailBarangRetur(ByVal NoNota As String) As DataTable
        Dim result As New DataSet
        'Dim cmd As String = "select DT.IDBarang, DT.NamaBarang, DT.Satuan, ISNULL((select sum(DRT.Jumlah) from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and HRT.NoNotaTerima = HT.NoNotaTerima and DRT.IDBarang = DT.IDBarang),0) as 'Kembali', (DT.Jumlah - ISNULL((select sum(DRT.Jumlah) from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and HRT.NoNotaTerima = HT.NoNotaTerima and DRT.IDBarang = DT.IDBarang),0)) as 'Sisa' from HTerima HT, DTerima DT where HT.NoNotaTerima = DT.NoNotaTerima and HT.NoNotaTerima = '" & NoNota & "'"
        'Dim cmd As String = "select DT.IDBarang, DT.NamaBarang, DT.Satuan from HTerima HT, DTerima DT where HT.NoNotaTerima = DT.NoNotaTerima and HT.NoNotaTerima = 'T001' EXCEPT select DRT.IDBarang, DRT.NamaBarang, DRT.Satuan from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and HRT.NoNotaTerima = 'T001'"
        constring.Open()
        Dim cmd As String = "select DT.IDBarang, DT.NamaBarang, DT.Satuan, DT.Jumlah from HTerima HT, DTerima DT where HT.NoNotaTerima = DT.NoNotaTerima and HT.NoNotaTerima = '" & NoNota & "' EXCEPT select DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.Jumlah  from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and HRT.NoNotaTerima = '" & NoNota & "'"
        SqlAdapter = New SqlDataAdapter(cmd, constring)
        SqlAdapter.Fill(result, "Hasil")
        constring.Close()
        Return result.Tables("Hasil")
    End Function

    Sub insertHReturTerima(NoReturTerima As String, NoNotaTerima As String, Tgl As String, id As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into HReturTerima values(@a,@b,@c,@d)", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", NoReturTerima))
                cmd.Parameters.Add(New SqlParameter("@b", NoNotaTerima))
                cmd.Parameters.Add(New SqlParameter("@c", Tgl))
                cmd.Parameters.Add(New SqlParameter("@d", id))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertDReturTerima(NoReturTerima As String, idbarang As String, nama As String, satuan As String, jumlah As Integer)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into DReturTerima values(@a,@b,@c,@d,@e)", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", NoReturTerima))
                cmd.Parameters.Add(New SqlParameter("@b", idbarang))
                cmd.Parameters.Add(New SqlParameter("@c", nama))
                cmd.Parameters.Add(New SqlParameter("@d", satuan))
                cmd.Parameters.Add(New SqlParameter("@e", jumlah))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Function cekNotaRetur(nota As String) As Boolean
        Dim result As Boolean = False
        Try
            constring.Open()
            cmd = New SqlCommand("select NoNotaReturTerima from HReturTerima where NoNotaReturTerima = @a", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", nota))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                result = True
            Else
                result = False
            End If
            constring.Close()
        Catch ex As Exception
            result = False
            constring.Close()
        End Try
        Return result
    End Function
End Module