Imports System.IO
Imports System.Drawing.Printing


Public Class Printer
    Public Sub New()
        InitializeComponent()
        Dim Printers As New System.Drawing.Printing.PrinterSettings()
        Dim sPrinter As String

#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        For Each sPrinter In Printers.InstalledPrinters
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            ComboBox1.Items.Add(sPrinter)
            If Printers.PrinterName = sPrinter Then ComboBox1.SelectedItem = sPrinter
        Next sPrinter
        ComboBox2.Items.Add("A4")
        ComboBox2.Items.Add("A5")
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objWriter As StreamWriter
        Dim path As String = "C:\AplikasiToko\printer.txt"
        Dim fs As FileStream
        System.IO.File.Delete(path)
        fs = File.Create(path)
        fs.Dispose()
        objWriter = New StreamWriter(path)
        objWriter.WriteLine(ComboBox1.SelectedItem)
        objWriter.WriteLine(ComboBox2.SelectedItem)
        objWriter.Close()
        objWriter.Dispose()
        MsgBox("Setting Printer Berhasil Dirubah")
        Me.Close()
    End Sub

    Private Sub Printer_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            Dim path As String = "C:\AplikasiToko\printer.txt"
            Dim sr As StreamReader = New StreamReader(path)
            sr.ReadLine()
            ComboBox2.SelectedItem = sr.ReadLine()
            sr.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class