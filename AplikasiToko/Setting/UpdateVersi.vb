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
                MsgBox("Pembaharuan Versi Berhasil")
            Else
                MsgBox("Data Sudah Paling Baru")
            End If
        ElseIf VSekarang = "1.1.1" Then
            constring.Open()
            cmd = New SqlCommand("SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TbBarang' AND COLUMN_NAME = 'Stok'", constring)
            Dim reader As String = cmd.ExecuteScalar
            If reader = "float" Then
                bool = True
            End If
            constring.Close()

            If bool = False Then
                constring.Open()
                cmd = New SqlCommand("ALTER TABLE TbBarang ALTER COLUMN Stok float;", constring)
                cmd.ExecuteNonQuery()
                constring.Close()
                MsgBox("Pembaharuan Versi Berhasil")
            Else
                MsgBox("Data Sudah Paling Baru")
            End If
        ElseIf VSekarang = "1.1.2" Then
            constring.Open()
            cmd = New SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE table_catalog = 'DatabaseToko' AND table_name = 'TbPelanggan'", constring)
            Dim reader As Integer = cmd.ExecuteScalar
            If reader = 5 Then
                bool = True
            End If
            constring.Close()

            If bool = False Then
                constring.Open()
                cmd = New SqlCommand("ALTER TABLE dbo.TbPelanggan ADD TipePelanggan VARCHAR(255) NULL;", constring)
                cmd.ExecuteNonQuery()
                constring.Close()
                MsgBox("Pembaharuan Versi Berhasil")
            Else
                MsgBox("Data Sudah Paling Baru")
            End If
        ElseIf VSekarang = "1.1.2.1" Then
            constring.Open()
            cmd = New SqlCommand("SELECT character_maximum_length FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TbBarang' AND COLUMN_NAME = 'KodeBarang'", constring)
            Dim reader As Integer = cmd.ExecuteScalar
            If reader = 100 Then
                bool = True
            End If
            constring.Close()

            If bool = False Then
                constring.Open()
                cmd = New SqlCommand("ALTER TABLE TbBarang DROP CONSTRAINT PK_TbBarang; ALTER TABLE TbBarang ALTER COLUMN KodeBarang varchar(100) NOT NULL; ALTER TABLE TbBarang ADD CONSTRAINT PK_TbBarang PRIMARY KEY CLUSTERED (KodeBarang);", constring)
                cmd.ExecuteNonQuery()
                constring.Close()
                MsgBox("Pembaharuan Versi Berhasil")
            Else
                MsgBox("Data Sudah Paling Baru")
            End If
        ElseIf VSekarang = "1.1.2.2" Then
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
                MsgBox("Pembaharuan Versi Berhasil, Silahkan restart program")
                Me.Close()
            Else
                MsgBox("Data Sudah Paling Baru")
            End If
        End If
    End Sub
End Class