Imports System.IO

Public Class Printer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objWriter As StreamWriter
        Dim path As String = "C:\AplikasiToko\printer.txt"
        Dim fs As FileStream
        System.IO.File.Delete(path)
        fs = File.Create(path)
        fs.Dispose()
        objWriter = New StreamWriter(path)
        objWriter.WriteLine(TextBox1.Text)
        objWriter.Close()
        objWriter.Dispose()
        MsgBox("Setting Printer Berhasil Dirubah")
        Me.Close()
    End Sub
End Class