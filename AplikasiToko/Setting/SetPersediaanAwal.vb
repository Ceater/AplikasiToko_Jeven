Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class SetPersediaanAwal
    Private Sub SetPersediaanAwal_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        MsgBox("Form ini digunakan untuk menentukan persediaan awal bulanan, pastikan untuk melakukan setting persediaan awal bulanan agak perhitungan Laba Rugi tidak salah, dan pastikan dalam 1 bulan hanya dilakukan 1x untuk menghindari kesalahan perhitungan. Gunakan form ini setiap tanggal 1 diawal bulan.")
    End Sub

    Private Sub SetPersediaanAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = getBulanTerakhir()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As Integer = MessageBox.Show("Apakah Anda Yakin Ingin Melakukan Setting Untuk Bulan Ini?", "Peringatan", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If getBulanTerakhirNumeric() = Now.Month Then
                MsgBox("Bulan ini Sudah Dilakukan Setting")
            Else
                setBulanBaru()
                MsgBox("Setting Berhasil Dilakukan")
                Label2.Text = getBulanTerakhir()
            End If
        End If
    End Sub

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
        Dim persediaanAwal As Integer = getPersediaanAwal()
        Dim Tgl As Date = "01/" & Now.Month & "/" & Now.Year
        constring.Open()
        Try
            cmd = New SqlCommand("insert into TbLabaRugi values(@a, @b)", constring)
            cmd.Parameters.AddWithValue("@a", persediaanAwal)
            cmd.Parameters.AddWithValue("@b", Tgl.ToString("MM/dd/yyyy") & " 00:00:00")
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        constring.Close()
    End Sub

    Function getPersediaanAwal()
        Dim int As Integer
        constring.Open()
        Try
            cmd = New SqlCommand("select Sum(Stok * HargaSales) From TbBarang", constring)
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
End Class