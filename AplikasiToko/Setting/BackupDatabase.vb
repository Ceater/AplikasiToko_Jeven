Imports System.Data.SqlClient

Public Class BackupDatabase
    Private Sub BackupDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        constring.Open()
        cmd = New SqlCommand("SELECT @@servername", constring)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read
            ComboBox1.Items.Add(reader(0))
        End While
        constring.Close()

        constring.Open()
        cmd = New SqlCommand("SELECT * FROM sys.databases", constring)
        reader = cmd.ExecuteReader
        While reader.Read
            ComboBox2.Items.Add(reader(0))
        End While
        constring.Close()

        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox2.SelectedValue = "DatabaseToko"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s As String = Now.Day & Now.Month & Now.Year
        query("backup database " & ComboBox2.Text & " to disk='C:\AplikasiToko\Backup " & s & ".bak'")
    End Sub

    Sub query(ByVal que As String)
        constring.Open()
        cmd = New SqlCommand(que, constring)
        cmd.ExecuteNonQuery()
        constring.Close()
    End Sub
End Class