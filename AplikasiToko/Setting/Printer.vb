Imports System.IO
Imports System.Drawing.Printing

Public Class Printer
    Public Sub New()
        InitializeComponent()
        Dim Printers As New System.Drawing.Printing.PrinterSettings()
        Dim sPrinter As String

        For Each sPrinter In Printers.InstalledPrinters
            ComboBox1.Items.Add(sPrinter)
            If Printers.PrinterName = sPrinter Then ComboBox1.SelectedItem = sPrinter
        Next sPrinter
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(ComboBox1.SelectedItem)
        Dim objWriter As StreamWriter
        Dim path As String = "C:\AplikasiToko\printer.txt"
        Dim fs As FileStream
        System.IO.File.Delete(path)
        fs = File.Create(path)
        fs.Dispose()
        objWriter = New StreamWriter(path)
        objWriter.WriteLine(ComboBox1.SelectedItem)
        objWriter.Close()
        objWriter.Dispose()
        MsgBox("Setting Printer Berhasil Dirubah")
        Me.Close()
    End Sub
End Class