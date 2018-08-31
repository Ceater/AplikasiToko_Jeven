Imports System.Data.SqlClient

Public Class BackupDatabase
    Dim psn As String = ""
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
        Dim s As String = Now.Day.ToString().PadLeft(2, "0") & Now.Month.ToString().PadLeft(2, "0") & Now.Year
        Timer1.Enabled = True
        query("backup database " & ComboBox2.Text & " to disk='C:\AplikasiToko\Backup " & s & ".bak'")
        psn = "Backup sukses" & vbCrLf & "File: C:\AplikasiToko\Backup " & s & ".bak'"
    End Sub

    Sub query(ByVal que As String)
        constring.Open()
        cmd = New SqlCommand(que, constring)
        cmd.ExecuteNonQuery()
        constring.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            MsgBox(psn)
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer = MessageBox.Show("Data akan dihapus dan digantikan data baru, data lama yang hilang tidak dapat dikembalikan, pastikan sudah backup terlebih dahulu!", "Pemulihan Database", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            OpenFileDialog1.ShowDialog()
            Timer1.Enabled = True
            query("RESTORE DATABASE " & ComboBox2.Text & " FROM disk='" & OpenFileDialog1.FileName & "'")
            'error karena ketika restore database yang sekarang sedang digunakan untuk melakukan constring open dan close.
        End If
    End Sub
End Class