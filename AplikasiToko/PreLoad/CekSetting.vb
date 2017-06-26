Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Public Class CekSetting
    Public constring As New SqlConnection("")
    Public cmd As SqlCommand
    Public SqlAdapter As SqlDataAdapter
    Private Sub CekSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSetting()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objWriter As StreamWriter
        Dim con As String = "Server=" & TextBox2.Text & "\" & TextBox1.Text & ";Database=DatabaseToko;User Id=" & TextBox3.Text & ";Password=" & TextBox4.Text & ";"

        Dim path As String = Directory.GetCurrentDirectory & "\setting.txt"
        Dim fs As FileStream
        System.IO.File.Delete(path)
        fs = File.Create(path)
        fs.Dispose()
        objWriter = New StreamWriter(path)
        objWriter.WriteLine(TextBox2.Text)
        objWriter.WriteLine(TextBox1.Text)
        objWriter.WriteLine(TextBox3.Text)
        objWriter.WriteLine(TextBox4.Text)
        objWriter.Close()
        objWriter.Dispose()
        loadSetting()
    End Sub

    Sub loadSetting()
        Dim path As String = Directory.GetCurrentDirectory & "\setting.txt"
        Dim x1, x2, x3, x4 As String
        Dim sr As StreamReader = New StreamReader(path)
        x1 = sr.ReadLine()
        x2 = sr.ReadLine()
        x3 = sr.ReadLine()
        x4 = sr.ReadLine()
        sr.Dispose()
        TextBox2.Text = x1
        TextBox1.Text = x2
        TextBox3.Text = x3
        TextBox4.Text = x4
        Dim con As String = "Server=" & x1 & "\" & x2 & ";Database=DatabaseToko;User Id=" & x3 & ";Password=" & x4 & ";"
        constring = New SqlConnection(con)
        Try
            constring.Open()
            constring.Close()
            LoginForm.Show()
            Me.Close()
        Catch ex As Exception
            MsgBox("Pengaturan Salah")
        End Try
    End Sub
End Class