Imports System.Data.Sql
Imports System.Data.SqlClient

Module ConnectionModule
    Public con As String
    Public constring As SqlConnection
    Public cmd As SqlCommand

    Public Sub setKoneksi(TipeKoneksi As String, ServerName As String, ServerInstance As String, UName As String, PWord As String)
        'Dim connectionString AS String = "Server=my_server;Database=name_of_db;User Id=user_name;Password=my_password"
        If TipeKoneksi = "1" Then
            con = "Server=" & ServerName & "\" & ServerInstance & ";Database=DatabaseToko;User Id=" & UName & ";Password=" & PWord & ";"
        ElseIf TipeKoneksi = "2" Then
            con = "Server=" & ServerName & ";Database=DatabaseToko;User Id=" & UName & ";Password=" & PWord & ";"
        ElseIf TipeKoneksi = "3" Then
            con = "Data Source=mssql1.gear.host;Initial Catalog=aplikasitoko;Persist Security Info=True;User ID=aplikasitoko;Password=Zs3N?6-Gy4T0"
        End If
    End Sub

    Public Function cekKoneksi(koneksi As String)
        Dim bool As Boolean = True
        constring = New SqlConnection(koneksi)
        Try
            constring.Open()
            constring.Close()
        Catch ex As Exception
            bool = False
        End Try
        Return bool
    End Function
End Module