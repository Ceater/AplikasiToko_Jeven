Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleReturBeli

    Function getDetailBarangRetur(ByVal NoNota As String) As DataTable
        Dim result As New DataSet
        Try
            constring.Open()
            Dim cmd As String = "select DT.IDBarang, DT.NamaBarang, DT.Satuan, DT.Jumlah from HTerima HT, DTerima DT where HT.NoNotaTerima = DT.NoNotaTerima and HT.NoNotaTerima = '" & NoNota & "' EXCEPT select DRT.IDBarang, DRT.NamaBarang, DRT.Satuan, DRT.Jumlah  from HReturTerima HRT, DReturTerima DRT where HRT.NoNotaReturTerima = DRT.NoNotaReturTerima and HRT.NoNotaTerima = '" & NoNota & "'"
            SqlAdapter = New SqlDataAdapter(cmd, constring)
            SqlAdapter.Fill(result, "Hasil")
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
        Return result.Tables("Hasil")
    End Function

    Function getDetailNotaRetur(ByVal NoNota As String) As Array
        Dim result(5) As String
        Try
            constring.Open()
            Dim cmd As New SqlCommand("SELECT NoNotaPenjual, TglNota, NamaSupplier, IDStaff  FROM HTerima WHERE NoNotaTerima = '" & NoNota & "';", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            reader.Read()
            result(0) = reader.GetValue(0)
            result(1) = reader.GetValue(1)
            result(2) = reader.GetValue(2)
            result(3) = reader.GetValue(3)
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
        Return result
    End Function

    Sub insertHReturTerima(NoReturTerima As String, NoNotaTerima As String, Tgl As String, id As String, notapenjual As String, supname As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into HReturTerima(NoNotaReturTerima, NoNotaTerima, TglReturTerima, IDStaff, NoNotaPenjual, NamaSupplier) values(@a,@b,@c,@d,@e,@f)", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", NoReturTerima))
                cmd.Parameters.Add(New SqlParameter("@b", NoNotaTerima))
                cmd.Parameters.Add(New SqlParameter("@c", Tgl))
                cmd.Parameters.Add(New SqlParameter("@d", id))
                cmd.Parameters.Add(New SqlParameter("@e", notapenjual))
                cmd.Parameters.Add(New SqlParameter("@f", supname))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Sub insertDReturTerima(NoReturTerima As String, idbarang As String, nama As String, satuan As String, jumlah As Double)
        Try
            constring.Open()
            cmd = New SqlCommand("INSERT INTO DReturTerima(NoNotaReturTerima, IDBarang, NamaBarang, Satuan, Jumlah) values(@a,@b,@c,@d,@e)", constring)
            With cmd.Parameters
                cmd.Parameters.Add(New SqlParameter("@a", NoReturTerima))
                cmd.Parameters.Add(New SqlParameter("@b", idbarang))
                cmd.Parameters.Add(New SqlParameter("@c", nama))
                cmd.Parameters.Add(New SqlParameter("@d", satuan))
                cmd.Parameters.Add(New SqlParameter("@e", jumlah))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()

            Dim deskripsi As String = "Retur Beli-" & idbarang & "-" & nama
            Dim stok As Double = getCurrentStok(idbarang) - jumlah
            ins_mutasi(NoReturTerima, deskripsi, jumlah, 0, stok, userLogin)
        Catch ex As Exception
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
            cmd = New SqlCommand("SELECT TOP 1 SUBSTRING(NoNotaReturTerima , 9, 4) as Nota FROM HReturTerima WHERE SUBSTRING(NoNotaReturTerima , 1, 8) LIKE '" & notaFormat & "' ORDER BY NoNotaReturTerima DESC;", constring)
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

    Function getListNotaBisaRetur()
        Dim res1 As New DataTable
        Dim str1 As String = ""
        res1 = getDataTB("NoNotaTerima", "DTerima", "Jumlah - SuksesRetur >= 1", "NoTerima DESC", "NoTerima, NoNotaTerima")
        Return res1
    End Function

    Function loadNotaTerima(searchMonth As Integer, searchYear As Integer, Optional keyword As String = "%") As ArrayList
        If keyword = "" Then
            keyword = "%"
        End If
        keyword = "%" & keyword & "%"
        Dim x As New ArrayList
        Try
            constring.Open()
            cmd = New SqlCommand("SELECT HT.NoNotaTerima FROM HTerima HT INNER JOIN DTerima DT ON HT.NoNotaTerima = DT.NoNotaTerima 
	                            WHERE Jumlah-SuksesRetur <> 0 AND MONTH(HT.TglNota) = @a AND YEAR(HT.TglNota) = @b AND HT.NoNotaTerima LIKE @c
	                            GROUP BY HT.NoNotaTerima, HT.date_i 
	                            ORDER BY HT.date_i DESC;", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", searchMonth))
                .Add(New SqlParameter("@b", searchYear))
                .Add(New SqlParameter("@c", keyword))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read
                x.Add(reader.GetValue(0))
            End While
            constring.Close()
        Catch ex As Exception
            If stage = 1 Then
                MsgBox(ex.ToString)
            End If
            constring.Close()
        End Try
        Return x
    End Function
End Module