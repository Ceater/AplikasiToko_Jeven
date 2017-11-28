Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Public Class CekSetting
    Public constring As New SqlConnection("")
    Public cmd As SqlCommand
    Public SqlAdapter As SqlDataAdapter
    Private Sub CekSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        startupSetting()
        loadSetting()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objWriter As StreamWriter
        Dim con As String = "Server=" & TextBox2.Text & "\" & TextBox1.Text & ";Database=DatabaseToko;User Id=" & TextBox3.Text & ";Password=" & TextBox4.Text & ";"
        'Dim con As String = "Data Source=mssql1.gear.host;Initial Catalog=aplikasitoko;Persist Security Info=True;User ID=aplikasitoko;Password=Zs3N?6-Gy4T0"
        Dim path As String = "C:\AplikasiToko\setting.txt"
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
        Dim path As String = "C:\AplikasiToko\setting.txt"
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
        'Dim con As String = "Data Source=mssql1.gear.host;Initial Catalog=aplikasitoko;Persist Security Info=True;User ID=aplikasitoko;Password=Zs3N?6-Gy4T0"
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

    Sub startupSetting()
        Dim path As String = "C:\AplikasiToko\"
        'cek directory
        If Directory.Exists(path) Then
        Else
            Directory.CreateDirectory("C:\AplikasiToko\")
        End If
        'cek setting printer
        If File.Exists(path & "printer.txt") Then
        Else
            createStartupSetting("printer.txt")
        End If
        'cek setting
        If File.Exists(path & "setting.txt") Then
        Else
            createStartupSetting("setting.txt")
        End If

    End Sub

    Sub createStartupSetting(path As String)
        Dim objWriter As StreamWriter
        Dim fs As FileStream
        Dim temp As String = "C:\AplikasiToko\" & path
        If path = "printer.txt" Then
            fs = File.Create(temp)
            fs.Dispose()
            objWriter = New StreamWriter(temp)
            objWriter.WriteLine("HP Deskjet 1010 Series")
            objWriter.Close()
            objWriter.Dispose()
        ElseIf path = "setting.txt" Then
            fs = File.Create(temp)
            fs.Dispose()
            objWriter = New StreamWriter(temp)
            objWriter.WriteLine("DEVELOPER-PC")
            objWriter.WriteLine("SQLEXPRESS")
            objWriter.WriteLine("johan")
            objWriter.WriteLine("1234")
            objWriter.Close()
            objWriter.Dispose()
        End If
    End Sub
End Class