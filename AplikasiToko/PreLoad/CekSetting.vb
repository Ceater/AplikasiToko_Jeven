Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Public Class CekSetting
    Dim path As String = "C:\AplikasiToko\setting.txt"
    Private Sub CekSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        startupSetting()
        Dim x1, x2, x3, x4 As String
        Dim x5 As Integer
        Dim sr As StreamReader = New StreamReader(path)
        x5 = sr.ReadLine()
        x1 = sr.ReadLine()
        x2 = sr.ReadLine()
        x3 = sr.ReadLine()
        x4 = sr.ReadLine()
        sr.Dispose()

        If x5 = 1 Then
            RadioButton1.Checked = True
        ElseIf x5 = 2 Then
            RadioButton2.Checked = True
        Else
            RadioButton3.Checked = True
        End If
        TextBox2.Text = x1
        TextBox1.Text = x2
        TextBox3.Text = x3
        TextBox4.Text = x4
        TestKoneksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cekButton()
    End Sub

    Sub TestKoneksi()
        If RadioButton1.Checked Then
            LoadSetting(1)
        ElseIf radiobutton2.checked Then
            LoadSetting(2)
        ElseIf RadioButton3.Checked Then
            LoadSetting(3)
        End If
        If cekKoneksi(con) Then
            LoginForm.Show()
            Me.Close()
        Else
            MsgBox("Koneksi Gagal")
        End If
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
            objWriter.WriteLine("1")
            objWriter.WriteLine("DEVELOPER-PC")
            objWriter.WriteLine("SQLEXPRESS")
            objWriter.WriteLine("admin")
            objWriter.WriteLine("admin")
            objWriter.Close()
            objWriter.Dispose()
        End If
    End Sub

    Private Sub Enter_Pressed(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp, TextBox2.KeyUp, TextBox3.KeyUp, TextBox4.KeyUp
        If e.KeyCode = Keys.Enter Then
            cekButton()
        End If
    End Sub

    Sub cekButton()
        Dim objWriter As StreamWriter
        Dim fs As FileStream
        System.IO.File.Delete(path)
        fs = File.Create(path)
        fs.Dispose()
        objWriter = New StreamWriter(path)
        If RadioButton1.Checked Then
            objWriter.WriteLine("1")
        ElseIf RadioButton2.Checked Then
            objWriter.WriteLine("2")
        ElseIf RadioButton3.Checked Then
            objWriter.WriteLine("3")
        End If
        objWriter.WriteLine(TextBox2.Text)
        objWriter.WriteLine(TextBox1.Text)
        objWriter.WriteLine(TextBox3.Text)
        objWriter.WriteLine(TextBox4.Text)
        objWriter.Close()
        objWriter.Dispose()
        TestKoneksi()
    End Sub
End Class