﻿Public Class FormLaporanPembelian
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            Dim f As New FormLaporan("LaporanPembelian")
            f.mode = "1"
            f.Text = "Laporan Pembelian"
            f.Show()
        ElseIf RadioButton2.Checked Then
            Dim f As New FormLaporan("LaporanPembelian")
            f.mode = "2"
            f.Text = "Laporan Pembelian"
            f.tglAwal = DateTimePicker1.Value
            f.tglAkhir = DateTimePicker2.Value
            f.Show()
        ElseIf RadioButton3.Checked Then
            Dim f As New FormLaporan("LaporanPembelian")
            f.mode = "3"
            f.tglAwal = DateTimePicker3.Value
            f.Text = "Laporan Pembelian"
            f.Show()
        End If
        Me.Close()
    End Sub

    Private Sub FormLaporanPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker2.MaxDate = Now
    End Sub
End Class