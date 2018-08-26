Imports System.Data.Sql
Imports System.Data.SqlClient

Module LabaRugiModule
    Function getBulanTerakhir()
        Dim hsl As String = ""
        constring.Open()
        Try
            cmd = New SqlCommand("select TOP 1 Month(TglPersediaan) from TbLabaRugi order by TglPersediaan Desc", constring)
            Dim int As Integer = cmd.ExecuteScalar
            If int = 1 Then
                hsl = "Januari"
            ElseIf int = 2 Then
                hsl = "Febuary"
            ElseIf int = 3 Then
                hsl = "Maret"
            ElseIf int = 4 Then
                hsl = "April"
            ElseIf int = 5 Then
                hsl = "Mei"
            ElseIf int = 6 Then
                hsl = "Juni"
            ElseIf int = 7 Then
                hsl = "Juli"
            ElseIf int = 8 Then
                hsl = "Agustus"
            ElseIf int = 9 Then
                hsl = "September"
            ElseIf int = 10 Then
                hsl = "Oktober"
            ElseIf int = 11 Then
                hsl = "November"
            ElseIf int = 12 Then
                hsl = "Desember"
            Else
                hsl = "Belum Pernah Dilakukan Setting"
            End If
        Catch ex As Exception
            hsl = "Belum Pernah Dilakukan Setting"
        End Try
        constring.Close()
        Return hsl
    End Function

    Sub setBulanBaru()
        Dim Tgl As Date = "01/" & Now.Month & "/" & Now.Year
        constring.Open()
        Try
            cmd = New SqlCommand("insert into TbLabaRugi values(ISNULL((select SUM(HargaBeli) from HargaBeliSetiapBarang),0),@a)", constring)
            cmd.Parameters.AddWithValue("@a", Tgl.ToString("MM/dd/yyyy") & " 00:00:00")
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        constring.Close()
    End Sub

    Function getPersediaanAwal()
        Dim int As Integer
        constring.Open()
        Try
            cmd = New SqlCommand("select isnull((select TOP 1 PersediaanAwal from TbLabaRugi order by No Desc),0)", constring)
            int = cmd.ExecuteScalar
        Catch ex As Exception
            int = 0
        End Try
        constring.Close()
        Return int
    End Function

    Function getBulanTerakhirNumeric()
        Dim hsl As Integer = 0
        constring.Open()
        Try
            cmd = New SqlCommand("select TOP 1 Month(TglPersediaan) from TbLabaRugi order by TglPersediaan Desc", constring)
            Dim int As Integer = cmd.ExecuteScalar
            hsl = int
        Catch ex As Exception
        End Try
        constring.Close()
        Return hsl
    End Function
End Module
