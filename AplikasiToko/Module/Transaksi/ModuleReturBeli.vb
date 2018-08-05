﻿Imports System.Data.Sql
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

    Sub insertDReturTerima(NoReturTerima As String, idbarang As String, nama As String, satuan As String, jumlah As Double)
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

    Function cekNotaReturTerima(nota As String) As Boolean
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

    Function getNotaReturTerima()
        Dim temp As String = ""
        Dim notaFormat, tglSkr As String
        tglSkr = String.Format("{0:ddMMyy}", DateTime.Now)
        Try
            constring.Open()
            notaFormat = "%" & tglSkr & "%"
            'cmd = New SqlCommand("select TOP 1 NoNotaJual from HJual order by NoNotaJual desc", constring)
            cmd = New SqlCommand("SELECT TOP 1 SUBSTRING(NoNotaReturTerima , 8, 4) as Nota FROM HReturTerima WHERE SUBSTRING(NoNotaReturTerima , 1, 7) LIKE '" & notaFormat & "' ORDER BY NoNotaReturTerima DESC;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                temp = CInt(reader.GetValue(0)) + 1
                If temp.Length = 1 Then
                    temp = "RT" & tglSkr & "000" & temp
                ElseIf temp.Length = 2 Then
                    temp = "RT" & tglSkr & "00" & temp
                ElseIf temp.Length = 3 Then
                    temp = "RT" & tglSkr & "0" & temp
                Else
                    temp = "RT" & tglSkr & temp
                End If
            Else
                temp = "RT" & tglSkr & "0001"
            End If
            constring.Close()
        Catch ex As Exception
            temp = "RT" & tglSkr & "0001"
            constring.Close()
        End Try
        Return temp
    End Function
End Module