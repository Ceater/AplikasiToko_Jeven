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
        ElseIf VSekarang = "1.1.2.3" Then
            constring.Open()
            cmd = New SqlCommand("
                ALTER TABLE HJual ALTER COLUMN NoNotaJual VARCHAR(25) NOT NULL;
                ALTER TABLE DJual ALTER COLUMN NoNotaJual VARCHAR(25) NOT NULL;
                ALTER TABLE DJual ALTER COLUMN IDBarang VARCHAR(100) NOT NULL;
                ALTER TABLE HTerima ALTER COLUMN NoNotaTerima VARCHAR(25) NOT NULL;
                ALTER TABLE DTerima ALTER COLUMN NoNotaTerima VARCHAR(25) NOT NULL;
                ALTER TABLE DTerima ALTER COLUMN IDBarang VARCHAR(100) NOT NULL;
                ALTER TABLE HPembelian ALTER COLUMN NoNotaTerima VARCHAR(25) NOT NULL;
                ALTER TABLE DPembelian ALTER COLUMN IDBarang VARCHAR(100) NOT NULL;
                ALTER TABLE HReturJual ALTER COLUMN NoNotaReturJual VARCHAR(25) NOT NULL;
                ALTER TABLE HReturJual ALTER COLUMN NoNotaJual VARCHAR(25) NOT NULL;
                ALTER TABLE DReturJual ALTER COLUMN NoNotaReturJual VARCHAR(25) NOT NULL;
                ALTER TABLE DReturJual ALTER COLUMN IDBarang VARCHAR(100) NOT NULL;
                ALTER TABLE HReturTerima ALTER COLUMN NoNotaReturTerima VARCHAR(25) NOT NULL;
                ALTER TABLE HReturTerima ALTER COLUMN NoNotaTerima VARCHAR(25) NOT NULL;
                ALTER TABLE DReturTerima ALTER COLUMN NoNotaReturTerima VARCHAR(25) NOT NULL;
                ALTER TABLE DReturTerima ALTER COLUMN IDBarang VARCHAR(100) NOT NULL;
                ALTER TABLE TbPembayaran ALTER COLUMN NoNotaJual VARCHAR(25) NOT NULL;
            ", constring)
            cmd.ExecuteNonQuery()
            constring.Close()
            MsgBox("Pembaharuan Versi Berhasil, Silahkan restart program")
            Me.Close()
        ElseIf VSekarang = "1.1.4.4" Then
            constring.Open()
            cmd = New SqlCommand("
                IF EXISTS (SELECT * FROM sys.tables WHERE name = 'TbConfig' AND type = 'U')
                BEGIN
                    DROP TABLE[dbo].[TbConfig];
                END;
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TbConfig' AND type = 'U')
                BEGIN
	                CREATE TABLE [dbo].[TbConfig](
	                [no_urut] [int] IDENTITY(1,1) NOT NULL,
	                [keynote] [varchar](max) NOT NULL,
	                [value1] [varchar](max) NULL,
	                [value2] [varchar](max) NULL,
	                PRIMARY KEY CLUSTERED 
	                (
		                [no_urut] ASC
	                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	                ) ON [PRIMARY]
	                INSERT INTO TbConfig(keynote, value1, value2) VALUES('Versi', '1.1.4.3', '')
	                ALTER TABLE TbBarang ADD Date_i datetime;
	                ALTER TABLE TbBarang ADD Date_u datetime;
	                ALTER TABLE TbBarang ADD User_i varchar(100);
	                ALTER TABLE TbBarang ADD User_u varchar(100);
                    ALTER TABLE TbLabaRugi ADD Date_i datetime;
	                ALTER TABLE TbLabaRugi ADD User_i varchar(100);
                END
            ", constring)
            cmd.ExecuteNonQuery()
            constring.Close()
            MsgBox("Pembaharuan Versi Berhasil, Silahkan restart program")
            Me.Close()
        ElseIf VSekarang = "1.1.4.6" Then
            constring.Open()
            cmd = New SqlCommand("
                ALTER TABLE [TbPembayaran] ADD Date_i datetime;
                ALTER TABLE [TbPembayaran] ADD Date_u datetime;
                ALTER TABLE [TbPembayaran] ADD User_i varchar(100);
                ALTER TABLE [TbPembayaran] ADD User_u varchar(100);
                CREATE TABLE [dbo].[TbPiutang](
	                [NotaPiutang] [varchar](25) NOT NULL,
	                [NoNotaJual] [varchar](25) NULL,
	                [GrandTotal] [float] NULL,
	                [SisaPiutang] [float] NULL,
	                [Date_i] [datetime] NULL,
	                [Date_u] [datetime] NULL,
	                [User_i] [varchar](100) NULL,
	                [User_u] [varchar](100) NULL,
                 CONSTRAINT [PK_TbPiutang] PRIMARY KEY CLUSTERED 
                (
	                [NotaPiutang] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                UPDATE TbConfig Set value1=@a1 WHERE keynote='Versi';
            ", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a1", VSekarang))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
            MsgBox("Pembaharuan Versi Berhasil, Silahkan restart program")
            Me.Close()
        End If
    End Sub
End Class