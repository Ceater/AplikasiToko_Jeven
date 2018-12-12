Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class AutoUpdate
    Dim username As String = ""
    Dim errorCode As String = ""

    Public Sub New(ByVal x As String)
        InitializeComponent()
        username = x
    End Sub

    Private Sub AutoUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim temp = "", versiDB As String = ""
        Try
            constring.Open()
            'Cek versi saat ini
            cmd = New SqlCommand("Select versi FROM HistoryVersi HV WHERE HV.Versi='" & VersiSekarang & "'", constring)
            temp = cmd.ExecuteScalar
            cmd = New SqlCommand("Select value1 FROM TbConfig TC WHERE TC.keynote = 'Versi'", constring)
            versiDB = cmd.ExecuteScalar
            If temp = Nothing Then
                cmd = New SqlCommand("
                            INSERT INTO HistoryVersi(Versi) VALUES(@a1);
                            UPDATE TbConfig Set value1=@a1 WHERE keynote='Versi'
                        ", constring)
                With cmd.Parameters
                    .Add(New SqlParameter("@a1", VersiSekarang))
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
        Catch ex As Exception
        End Try
        constring.Close()

        If temp = Nothing Then
            updateBWorker.RunWorkerAsync()
        ElseIf temp <> Nothing And versiDB <> VersiSekarang Then
            MsgBox("Anda tidak menggunakan versi terbaru, silahkan update aplikasi")
            Me.Dispose()
        Else
            openHome()
        End If
    End Sub

    Private Sub AutoUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            MsgBox("Tunggu Sampai Update Selesai")
        End If
    End Sub

    Private Sub updateBWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles updateBWorker.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub updateBWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles updateBWorker.RunWorkerCompleted
        MsgBox("Update Selesai")
        openHome()
    End Sub

    Private Sub updateBWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles updateBWorker.DoWork
        Try
            constring.Open()
        Catch ex As Exception
        End Try
        constring.Close()
    End Sub

    Sub openHome()
        Dim f As New Home
        f.ToolStripStatusLabel2.Text = username
        f.hakAkses = getHAkses(username)
        f.Show()
        Me.Dispose()
    End Sub
End Class