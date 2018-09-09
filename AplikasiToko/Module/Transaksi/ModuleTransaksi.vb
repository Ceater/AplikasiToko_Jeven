Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleTransaksi
    Dim cmd As SqlCommand
    Sub insertHJual(nota As String, tgl As String, grandtot As Double, pelanggan As String, idstaff As String)
        Try
            constring.Open()
            cmd = New SqlCommand("Insert into HJual values(@a,@b,@c,@d,@e)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", tgl))
                .Add(New SqlParameter("@c", grandtot))
                .Add(New SqlParameter("@d", pelanggan))
                .Add(New SqlParameter("@e", idstaff))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertDJual(nota As String, idbarang As String, namabarang As String, satuan As String, harga As Double, jumlah As Double, diskon As String, subtot As Double)
        Try
            constring.Open()
            cmd = New SqlCommand("Insert into DJual values(@a,@b,@c,@d,@e,@f,@g,@h)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", idbarang))
                .Add(New SqlParameter("@c", namabarang))
                .Add(New SqlParameter("@d", satuan))
                .Add(New SqlParameter("@e", harga))
                .Add(New SqlParameter("@f", jumlah))
                .Add(New SqlParameter("@g", diskon))
                .Add(New SqlParameter("@h", subtot))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertPembayaran(nota As String, tgl As String, uangbayar As Double, idstaff As String)
        Try
            constring.Open()
            cmd = New SqlCommand("
                Insert into TbPembayaran(NoNotaJual ,TglBayar ,UangBayar ,Date_i ,User_i)  values(@a,@b,@c,@d,@e)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
                .Add(New SqlParameter("@b", tgl))
                .Add(New SqlParameter("@c", uangbayar))
                .Add(New SqlParameter("@d", DateTime.Now))
                .Add(New SqlParameter("@e", idstaff))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertPiutang(nota As String, tgl As String, grandtotal As Double, uangbayar As Double, idstaff As String)
        Dim NoNotaPiutang As String = getNotaPiutang()
        Dim sisaPiutang = grandtotal - uangbayar
        Try
            constring.Open()
            cmd = New SqlCommand("
                Insert into TbPiutang(NoNotaPiutang ,NoNotaJual ,GrandTotal ,SisaPiutang ,Date_i , User_i) values(@a,@b,@c,@d,@e,@f)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", NoNotaPiutang))
                .Add(New SqlParameter("@b", nota))
                .Add(New SqlParameter("@c", grandtotal))
                .Add(New SqlParameter("@d", sisaPiutang))
                .Add(New SqlParameter("@e", DateTime.Now))
                .Add(New SqlParameter("@f", idstaff))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub updatePiutang(nota As String, tgl As String, uangbayar As Double, idstaff As String, Optional returbarang As Double = 0)
        constring.Open()
        cmd = New SqlCommand("UPDATE TbPiutang SET SisaPiutang = SisaPiutang - @a, TotalRetur = TotalRetur + @b, Date_u = @c, User_u = @d WHERE NoNotaJual = @e", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@a", uangbayar))
            .Add(New SqlParameter("@b", returbarang))
            .Add(New SqlParameter("@c", tgl))
            .Add(New SqlParameter("@d", idstaff))
            .Add(New SqlParameter("@e", nota))
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        constring.Close()
    End Sub

    Function cekNotaJual(nota As String) As Boolean
        Dim temp As Boolean = False
        Try
            constring.Open()
            cmd = New SqlCommand("select NoNotaJual from HJual where NoNotaJual=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", nota))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                temp = True
            End If
            constring.Close()
        Catch ex As Exception

        End Try
        Return temp
    End Function

    Function getNotaJual() As String
        Dim temp As String = ""
        Dim notaFormat, tglSkr As String
        tglSkr = String.Format("{0:ddMMyy}", DateTime.Now)
        Try
            constring.Open()
            notaFormat = "%" & tglSkr & "%"
            'cmd = New SqlCommand("select TOP 1 NoNotaJual from HJual order by NoNotaJual desc", constring)
            cmd = New SqlCommand("SELECT TOP 1 SUBSTRING(NoNotaJual, 8, 4) as Nota FROM HJual WHERE SUBSTRING(NoNotaJual, 1, 7) LIKE '" & notaFormat & "' ORDER BY NoNotaJual DESC;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                temp = CInt(reader.GetValue(0)) + 1
                If temp.Length = 1 Then
                    temp = "J" & tglSkr & "000" & temp
                ElseIf temp.Length = 2 Then
                    temp = "J" & tglSkr & "00" & temp
                ElseIf temp.Length = 3 Then
                    temp = "J" & tglSkr & "0" & temp
                Else
                    temp = "J" & tglSkr & temp
                End If
            Else
                temp = "J" & tglSkr & "0001"
            End If
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            temp = "J" & tglSkr & "0001"
            constring.Close()
        End Try
        Return temp
    End Function

    Function getNotaPiutang()
        Dim temp As String = ""
        Dim notaFormat, tglSkr As String
        tglSkr = String.Format("{0:ddMMyy}", DateTime.Now)
        Try
            constring.Open()
            notaFormat = "%" & tglSkr & "%"
            cmd = New SqlCommand("Select TOP 1 SUBSTRING(NoNotaPiutang, 9, 4) As Nota From TbPiutang Where SUBSTRING(NoNotaPiutang, 1, 8) Like '" & notaFormat & "' ORDER BY NoNotaPiutang DESC;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                temp = CInt(reader.GetValue(0)) + 1
                If temp.Length = 1 Then
                    temp = "PT" & tglSkr & "000" & temp
                ElseIf temp.Length = 2 Then
                    temp = "PT" & tglSkr & "00" & temp
                ElseIf temp.Length = 3 Then
                    temp = "PT" & tglSkr & "0" & temp
                Else
                    temp = "PT" & tglSkr & temp
                End If
            Else
                temp = "PT" & tglSkr & "0001"
            End If
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            temp = "PT" & tglSkr & "0001"
            constring.Close()
        End Try
        Return temp
    End Function
End Module
