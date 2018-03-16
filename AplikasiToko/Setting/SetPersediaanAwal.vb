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
End Class