Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class UpdateVersi
    Dim VSekarang As String

    Public Sub New(ByVal vs As String)
        InitializeComponent()
        VSekarang = vs
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bool As Boolean = False
        If VSekarang = "1.1" Then
            constring.Open()
            cmd = New SqlCommand("select NamaSatuan from TbSatuan where NamaSatuan='Lusin'", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                bool = True
            End If
            constring.Close()

            If bool = False Then
                constring.Open()
                cmd = New SqlCommand("insert into TbSatuan values('29','Lusin')", constring)
                cmd.ExecuteNonQuery()
                constring.Close()
                MsgBox("Data Sudah Diperbarui")
            Else
                MsgBox("Data Sudah Paling Baru")
            End If
        End If
    End Sub
End Class