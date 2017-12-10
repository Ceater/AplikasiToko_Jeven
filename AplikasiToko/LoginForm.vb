Imports System.Threading
Imports System.Globalization

Public Class LoginForm
    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo("id-ID")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("id-ID")
        LoadSetting()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login()
    End Sub

    Private Sub TextBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Enter
        sender.selectall()
    End Sub

    Private Sub EnterPressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub

    Sub Login()
        If cekLogin(TextBox1.Text, TextBox2.Text) Then
            Dim f As New Home
            f.ToolStripStatusLabel2.Text = TextBox1.Text
            f.hakAkses = getHAkses(TextBox1.Text)
            f.Show()
            Me.Close()
        Else
            MsgBox("ID atau Password salah")
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Enter_Textbox(sender As Object, e As EventArgs) Handles TextBox1.Enter, TextBox2.Enter
        sender.selectall
    End Sub
End Class