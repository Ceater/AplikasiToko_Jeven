Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleTerima
    Dim cmd As SqlCommand
    Sub insertHTerima(nota As String, tgl As String, idstaff As String, notapenjual As String, toko As String, duedate As String)
        Try
            constring.Open()
            cmd = New SqlCommand("INSERT INTO HTerima(NoNotaTerima, TglNota, IDStaff, NoNotaPenjual, NamaSupplier, TglJatuhTempo, Date_i, User_i) VALUES(@a,@b,@c,@d,@e,@f,@g,@h)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", tgl))
                .Add(New SqlParameter("@c", idstaff))
                .Add(New SqlParameter("@d", notapenjual))
                .Add(New SqlParameter("@e", toko))
                .Add(New SqlParameter("@f", duedate))
                .Add(New SqlParameter("@g", DateTime.Now))
                .Add(New SqlParameter("@h", userLogin))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            If stage = 1 Then
                MsgBox(ex.ToString)
            End If
            constring.Close()
        End Try
    End Sub

    Sub insertDTerima(nota As String, idbarang As String, namabarang As String, satuan As String, jumlah As Double)
        Try
            constring.Open()
            cmd = New SqlCommand("INSERT INTO DTerima(NoNotaTerima, IDBarang, NamaBarang, Satuan, Jumlah, SuksesRetur) VALUES(@a,@b,@c,@d,@e,@f)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", idbarang))
                .Add(New SqlParameter("@c", namabarang))
                .Add(New SqlParameter("@d", satuan))
                .Add(New SqlParameter("@e", jumlah))
                .Add(New SqlParameter("@f", "0"))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()

            Dim deskripsi As String = "Beli-" & idbarang & "-" & namabarang
            Dim stok As Double = getCurrentStok(idbarang) + jumlah
            ins_mutasi(nota, deskripsi, 0, jumlah, stok, userLogin)
        Catch ex As Exception
            If stage = 1 Then
                MsgBox(ex.ToString)
            End If
            constring.Close()
        End Try
    End Sub

    Function cekNotaTerima(nota As String) As Boolean
        Dim temp As Boolean = False
        Try
            constring.Open()
            cmd = New SqlCommand("select NoNotaTerima from HTerima where NoNotaTerima=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                temp = True
            End If
            constring.Close()
        Catch ex As Exception
            If stage = 1 Then
                MsgBox(ex.ToString)
            End If
            constring.Close()
        End Try
        Return temp
    End Function

    Function getNotaTerima() As String
        Dim temp As String = ""
        Dim notaFormat, tglSkr As String
        tglSkr = String.Format("{0:ddMMyy}", DateTime.Now)
        Try
            constring.Open()
            notaFormat = "%" & tglSkr & "%"
            'cmd = New SqlCommand("select TOP 1 NoNotaJual from HJual order by NoNotaJual desc", constring)
            cmd = New SqlCommand("SELECT TOP 1 SUBSTRING(NoNotaTerima, 8, 4) as Nota FROM HTerima WHERE SUBSTRING(NoNotaTerima, 1, 7) LIKE '" & notaFormat & "' ORDER BY NoNotaTerima DESC;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                temp = CInt(reader.GetValue(0)) + 1
                If temp.Length = 1 Then
                    temp = "T" & tglSkr & "000" & temp
                ElseIf temp.Length = 2 Then
                    temp = "T" & tglSkr & "00" & temp
                ElseIf temp.Length = 3 Then
                    temp = "T" & tglSkr & "0" & temp
                Else
                    temp = "T" & tglSkr & temp
                End If
            Else
                temp = "T" & tglSkr & "0001"
            End If
            constring.Close()
        Catch ex As Exception
            temp = "T" & tglSkr & "0001"
            constring.Close()
        End Try
        Return temp
    End Function

    Sub updateSuksesRetur(NoNotaTerima As String, IDBarang As String)
        Try
            constring.Open()
            cmd = New SqlCommand("UPDATE DTerima SET SuksesRetur = SuksesRetur + @a WHERE IDBarang = @b", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", NoNotaTerima))
                .Add(New SqlParameter("@b", IDBarang))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            If stage = 1 Then
                MsgBox(ex.ToString)
            End If
            constring.Close()
        End Try
    End Sub
End Module