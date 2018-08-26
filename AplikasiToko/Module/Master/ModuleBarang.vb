Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleBarang
    Dim cmd As SqlCommand
    Function getKodeSatuan(ByVal s As String)
        Dim x As Double = 0
        constring.Open()
        cmd = New SqlCommand("Select KodeSatuan from TbSatuan where NamaSatuan=@ns", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@ns", s))
        End With
        x = cmd.ExecuteScalar
        constring.Close()
        Return x
    End Function

    Sub insertBarang(ByVal KDBarang As String, ByVal NMBarang As String, ByVal Stok As Double, ByVal KDSatuan As String, ByVal HNormal As Double, ByVal HToko As Double, ByVal HSales As Double, ByVal Spengingat As Double)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into TbBarang([KodeBarang] ,[NamaBarang] ,[Stok] ,[SatuanBarang] ,[HargaNormal] ,[HargaToko] ,[HargaSales] ,[StokPengingat] ,[date_i] ,[user_i]) values(@aa,@ab,@ac,@ad,@ae,@af,@ag,@ah,@ai,@aj)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@aa", KDBarang))
                .Add(New SqlParameter("@ab", NMBarang))
                .Add(New SqlParameter("@ac", Stok))
                .Add(New SqlParameter("@ad", KDSatuan))
                .Add(New SqlParameter("@ae", HNormal))
                .Add(New SqlParameter("@af", HToko))
                .Add(New SqlParameter("@ag", HSales))
                .Add(New SqlParameter("@ah", Spengingat))
                .Add(New SqlParameter("@ai", DateTime.Now))
                .Add(New SqlParameter("@aj", userLogin))
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            constring.Close()
        Catch ex As Exception
            MsgBox("Barang sudah teregistrasi")
            constring.Close()
        End Try
    End Sub

    Sub updateBarang(ByVal KDBarang As String, ByVal NMBarang As String, ByVal KDSatuan As String, ByVal HNormal As Double, ByVal HToko As Double, ByVal HSales As Double, ByVal Spengingat As Double)
        constring.Open()
        cmd = New SqlCommand("update TbBarang set NamaBarang=@a2, SatuanBarang=@a4, HargaNormal=@a5, HargaToko=@a6, HargaSales=@a7, StokPengingat=@a8, Date_u=@a9, User_u=@a10 where KodeBarang=@a1", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@a1", KDBarang))
            .Add(New SqlParameter("@a2", NMBarang))
            .Add(New SqlParameter("@a4", KDSatuan))
            .Add(New SqlParameter("@a5", HNormal))
            .Add(New SqlParameter("@a6", HToko))
            .Add(New SqlParameter("@a7", HSales))
            .Add(New SqlParameter("@a8", Spengingat))
            .Add(New SqlParameter("@a9", DateTime.Now))
            .Add(New SqlParameter("@a10", userLogin))
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        constring.Close()
    End Sub

    Sub deleteBarang(ByVal KDBarang As String)
        constring.Open()
        cmd = New SqlCommand("delete TbBarang where KodeBarang=@a1", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@a1", KDBarang))
        End With
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        constring.Close()
    End Sub

    Sub updateStok(stok As Double, KDBarang As String)
        Try
            constring.Open()
            cmd = New SqlCommand("update TbBarang set stok=stok+@a, Date_u=@b, User_u=@c where KodeBarang=@d", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", stok))
                .Add(New SqlParameter("@b", DateTime.Now))
                .Add(New SqlParameter("@c", userLogin))
                .Add(New SqlParameter("@d", KDBarang))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Function getDetailbarang(kdBarang As String)
        Dim result = New Dictionary(Of String, String)
        constring.Open()
        Try
            cmd = New SqlCommand("SELECT KodeBarang, NamaBarang, Stok, NamaSatuan, HargaNormal, HargaToko, HargaSales, StokPengingat FROM TbBarang tb INNER JOIN TbSatuan ts ON tb.SatuanBarang=ts.KodeSatuan WHERE tb.KodeBarang=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", kdBarang))
            End With
            Dim reader As SqlDataReader = cmd.ExecuteReader
            reader.Read()
            result.Add("KodeBarang", reader.GetValue(0))
            result.Add("NamaBarang", reader.GetValue(1))
            result.Add("Stok", reader.GetValue(2))
            result.Add("SatuanBarang", reader.GetValue(3))
            result.Add("HargaNormal", reader.GetValue(4))
            result.Add("HargaToko", reader.GetValue(5))
            result.Add("HargaSales", reader.GetValue(6))
        Catch ex As Exception

        End Try
        constring.Close()
        Return result
    End Function

    Function getCurrentStok(KDBarang As String)
        Dim result As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("Select stok from TbBarang where KodeBarang=@kb", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@kb", KDBarang))
            End With
            result = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        constring.Close()
        Return result
    End Function
End Module