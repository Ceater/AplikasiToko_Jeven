Imports System.Data.SqlClient

Public Class ResetData
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dr As DialogResult = MsgBox("Apakah anda yakin?", MsgBoxStyle.YesNo)
        If dr = DialogResult.Yes Then
            constring.Open()
            cmd = New SqlCommand("exec StartData", constring)
            cmd.ExecuteNonQuery()
            constring.Close()
            LoadDataSet()
            MsgBox("Reset berhasil")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dr As DialogResult = MsgBox("Apakah anda yakin?", MsgBoxStyle.YesNo)
        If dr = DialogResult.Yes Then
            constring.Open()
            cmd = New SqlCommand("exec TestData", constring)
            cmd.ExecuteNonQuery()
            constring.Close()
            LoadDataSet()
            MsgBox("Reset berhasil")
        End If
    End Sub
End Class