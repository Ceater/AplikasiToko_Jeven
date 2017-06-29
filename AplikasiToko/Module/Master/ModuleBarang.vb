Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleBarang
    Dim cmd As SqlCommand
    Function getKodeSatuan(ByVal s As String)
        Dim x As Integer = 0
        constring.Open()
        cmd = New SqlCommand("Select KodeSatuan from TbSatuan where NamaSatuan=@ns", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@ns", s))
        End With
        x = cmd.ExecuteScalar
        constring.Close()
        Return x
    End Function

    Sub insertBarang(ByVal KDBarang As String, ByVal NMBarang As String, ByVal Stok As Integer, ByVal KDSatuan As String, ByVal HNormal As Integer, ByVal HToko As Integer, ByVal HSales As Integer, ByVal Spengingat As Integer)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into TbBarang values(@aa,@ab,@ac,@ad,@ae,@af,@ag,@ah)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@aa", KDBarang))
                .Add(New SqlParameter("@ab", NMBarang))
                .Add(New SqlParameter("@ac", Stok))
                .Add(New SqlParameter("@ad", KDSatuan))
                .Add(New SqlParameter("@ae", HNormal))
                .Add(New SqlParameter("@af", HToko))
                .Add(New SqlParameter("@ag", HSales))
                .Add(New SqlParameter("@ah", Spengingat))
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            constring.Close()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("Barang sudah teregistrasi")
            constring.Close()
        End Try
    End Sub

    Sub updateBarang(ByVal KDBarang As String, ByVal NMBarang As String, ByVal Stok As Integer, ByVal KDSatuan As String, ByVal HNormal As Integer, ByVal HToko As Integer, ByVal HSales As Integer, ByVal Spengingat As Integer)
        constring.Open()
        cmd = New SqlCommand("update TbBarang set NamaBarang=@a2, Stok=@a3, SatuanBarang=@a4, HargaNormal=@a5, HargaToko=@a6, HargaSales=@a7, StokPengingat=@a8 where KodeBarang=@a1", constring)
        With cmd.Parameters
            .Add(New SqlParameter("@a1", KDBarang))
            .Add(New SqlParameter("@a2", NMBarang))
            .Add(New SqlParameter("@a3", Stok))
            .Add(New SqlParameter("@a4", KDSatuan))
            .Add(New SqlParameter("@a5", HNormal))
            .Add(New SqlParameter("@a6", HToko))
            .Add(New SqlParameter("@a7", HSales))
            .Add(New SqlParameter("@a8", Spengingat))
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

    Sub updateStok(stok As Integer, KDBarang As String)
        Try
            constring.Open()
            cmd = New SqlCommand("update TbBarang set stok=stok+@a where KodeBarang=@b", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", stok))
                .Add(New SqlParameter("@b", KDBarang))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
        LoadDataSet()
    End Sub
End Module
