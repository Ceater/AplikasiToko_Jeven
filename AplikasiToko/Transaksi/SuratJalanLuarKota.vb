﻿Public Class SuratJalanLuarKota
    Private Sub SuratJalanLuarKota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericUpDown1.Focus()
    End Sub

    Private Sub NumericUpDown1_Enter(sender As Object, e As EventArgs) Handles NumericUpDown1.Enter
        NumericUpDown1.Select(0, NumericUpDown1.Text.Length)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class