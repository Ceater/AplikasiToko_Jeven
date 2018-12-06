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
            'Jika database belum terupdate ke versi terbaru
            cmd = New SqlCommand("
                ALTER TABLE [TbPembayaran] ADD Date_i datetime;
                ALTER TABLE [TbPembayaran] ADD Date_u datetime;
                ALTER TABLE [TbPembayaran] ADD User_i varchar(100);
                ALTER TABLE [TbPembayaran] ADD User_u varchar(100);
                CREATE TABLE [dbo].[TbPiutang](
	                [NoNotaPiutang] [varchar](25) NOT NULL,
	                [NoNotaJual] [varchar](25) NULL,
	                [GrandTotal] [float] NULL,
	                [SisaPiutang] [float] NOT NULL,
	                [TotalRetur] [float] NOT NULL,
	                [Date_i] [datetime] NULL,
	                [Date_u] [datetime] NULL,
	                [User_i] [varchar](100) NULL,
	                [User_u] [varchar](100) NULL,
                 CONSTRAINT [PK_TbPiutang] PRIMARY KEY CLUSTERED 
                (
	                [NoNotaPiutang] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY]
                ALTER TABLE [dbo].[TbPiutang] ADD  CONSTRAINT [DF_TbPiutang_SisaPiutang]  DEFAULT ((0)) FOR [SisaPiutang];
                ALTER TABLE [dbo].[TbPiutang] ADD  CONSTRAINT [DF_TbPiutang_TotalRetur]  DEFAULT ((0)) FOR [TotalRetur];
                UPDATE TbConfig Set value1=@a1 WHERE keynote='Versi';
                ", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a1", VersiSekarang))
            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Dim counter As Integer = 0
            Dim temp As String = ""
            Dim sqlBatch As String = ""
            cmd = New SqlCommand("SELECT HJ.TglNota, HJ.NoNotaJual, HJ.GrandTotal, SUM(TP.UangBayar) as UangBayar, (HJ.GrandTotal - SUM(TP.UangBayar)) as 'Kekurangan'
            FROM HJual HJ RIGHT JOIN TbPembayaran TP ON HJ.NoNotaJual=TP.NoNotaJual
            GROUP BY HJ.TglNota, HJ.NoNotaJual, HJ.GrandTotal ORDER BY HJ.TglNota DESC;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                While reader.Read
                    Dim NoNotaPiutang As String = String.Format("{0:ddMMyy}", DateTime.Now)
                    temp = CInt(counter) + 1
                    If temp.Length = 1 Then
                        temp = "PT" & NoNotaPiutang & "000" & temp
                    ElseIf temp.Length = 2 Then
                        temp = "PT" & NoNotaPiutang & "00" & temp
                    ElseIf temp.Length = 3 Then
                        temp = "PT" & NoNotaPiutang & "0" & temp
                    Else
                        temp = "PT" & NoNotaPiutang & temp
                    End If
                    Dim NoNotaJual = "", User_i = "", User_u As String = ""
                    Dim GrandTotal = 0, SisaPiutang As Integer = 0

                    temp = SqlSafe(temp)
                    NoNotaJual = SqlSafe(reader.GetValue(1))
                    GrandTotal = reader.GetValue(2)
                    SisaPiutang = reader.GetValue(4)
                    User_i = "System"

                    sqlBatch &= "INSERT INTO TbPiutang(NoNotaPiutang, NoNotaJual, GrandTotal, SisaPiutang, Date_i, User_i) VALUES('" & temp & "', '" & NoNotaJual & "', " & GrandTotal & ", " & SisaPiutang & ", '" & DateTime.Now & "', '" & User_i & "');"
                    counter += 1
                End While
                reader.Close()
                cmd = New SqlCommand(sqlBatch, constring)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("UPDATE TbPiutang SET TotalRetur = ISNULL((SELECT SUM(Subtotal) as GrandTotal FROM HReturJual HJ INNER JOIN DReturJual DJ ON HJ.NoNotaReturJual = DJ.NoNotaReturJual WHERE NoNotaJual = TbPiutang.NoNotaJual),0);", constring)
                cmd.ExecuteNonQuery()
            End If
        ElseIf VSekarang = "1.1.5.0" Then
            constring.Open()
            cmd = New SqlCommand("
            CREATE TABLE DatabaseToko.dbo.TbMutasi(
	            NoMutasi int NOT NULL IDENTITY (1, 1),
	            NoNota varchar(50) NULL,
	            Deskripsi text NULL,
	            Keluar float(53) NULL,
	            Masuk float(53) NULL,
	            Stok float(53) NULL,
	            Date_i datetime NULL,
	            User_i varchar(MAX) NULL
	            )  ON [PRIMARY]
	             TEXTIMAGE_ON [PRIMARY]
            ALTER TABLE DatabaseToko.dbo.TbMutasi ADD CONSTRAINT
	            PK_TbMutasi PRIMARY KEY CLUSTERED(
	            NoMutasi) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
            ALTER TABLE DatabaseToko.dbo.TbMutasi SET (LOCK_ESCALATION = TABLE)
            DELETE FROM HTerima WHERE NoNotaTerima = 'T2408180001';
            DELETE FROM DTerima WHERE NoNotaTerima = 'T2408180001';", constring)
            cmd.ExecuteNonQuery()
            Dim stokAwal As New Dictionary(Of String, Double)
            cmd = New SqlCommand("SELECT 
	            KodeBarang, 
	            NamaBarang, 
	            Stok as 'Stok Sekarang', 
	            ISNULL((SELECT TOP 1 dter.Jumlah FROM DTerima dter WHERE dter.IDBarang = tbar.KodeBarang), 0) as 'Stok Awal'
            From TbBarang tbar;", constring)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read
                'stokAwal.Add(reader.GetValue(0), dblConvertToVB(reader.GetValue(3)))
                stokAwal.Add(reader.GetValue(0), 0)
            End While
            reader.Close()
            cmd = New SqlCommand("SELECT H.TglNota, H.NoNotaJual AS 'Nomer Nota', D.IDBarang, D.NamaBarang, D.Jumlah 
        FROM HJual AS H INNER JOIN DJual AS D ON H.NoNotaJual = D.NoNotaJual
        UNION 
        SELECT HT.TglNota, HT.NoNotaTerima AS 'Nomer Nota', DT.IDBarang, DT.NamaBarang, DT.Jumlah 
        FROM HTerima AS HT INNER JOIN DTerima AS DT ON HT.NoNotaTerima = DT.NoNotaTerima 
        UNION 
        SELECT HRT.TglReturTerima, HRT.NoNotaReturTerima AS 'Nomer Nota', DRT.IDBarang, DRT.NamaBarang, DRT.Jumlah 
        FROM HReturTerima AS HRT INNER JOIN DReturTerima AS DRT ON HRT.NoNotaReturTerima = DRT.NoNotaReturTerima
        UNION
        SELECT HRT.TglReturJual, HRT.NoNotaReturJual AS 'Nomer Nota', DRT.IDBarang, DRT.NamaBarang, DRT.Jumlah 
        FROM HReturJual AS HRT INNER JOIN DReturJual AS DRT ON HRT.NoNotaReturJual = DRT.NoNotaReturJual", constring)
            reader = cmd.ExecuteReader
            Dim sqlBatch As New Queue
            While reader.Read
                Dim nonota = "", deskripsi As String = ""
                Dim jKeluar = "0", jMasuk = "0", stokMut As String = "0"
                If stokAwal.ContainsKey(reader.GetValue(2)) Then
                Else
                    stokAwal.Add(reader.GetValue(2), 0)
                End If
                If (reader.GetValue(1).indexOf("J") >= 0) Then
                    deskripsi = "Jual-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                    jKeluar = reader.GetValue(4)
                    stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) - dblConvertToVB(jKeluar)
                    stokMut = stokAwal.Item(reader.GetValue(2))
                ElseIf (reader.GetValue(1).indexOf("T") >= 0) Then
                    deskripsi = "Beli-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                    jMasuk = reader.GetValue(4)
                    stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) + dblConvertToVB(jMasuk)
                    stokMut = stokAwal.Item(reader.GetValue(2))
                ElseIf (reader.GetValue(1).indexOf("RJ") >= 0) Then
                    deskripsi = "Retur Jual-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                    jMasuk = reader.GetValue(4)
                    stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) + dblConvertToVB(jMasuk)
                    stokMut = stokAwal.Item(reader.GetValue(2))
                ElseIf (reader.GetValue(1).indexOf("RT") >= 0) Then
                    deskripsi = "Retur Beli-" & reader.GetValue(2) & "-" & reader.GetValue(3)
                    jKeluar = reader.GetValue(4)
                    stokAwal(reader.GetValue(2)) = stokAwal(reader.GetValue(2)) - dblConvertToVB(jKeluar)
                    stokMut = stokAwal.Item(reader.GetValue(2))
                End If
                nonota = SqlSafe(reader.GetValue(1))
                deskripsi = SqlSafe(deskripsi)
                jKeluar = jKeluar.Replace(",", ".")
                jMasuk = jMasuk.Replace(",", ".")
                stokMut = stokMut.Replace(",", ".")
                sqlBatch.Enqueue("Insert into TbMutasi(NoNota,Deskripsi,Keluar,Masuk,Stok,Date_i,User_i) VALUES('" & nonota & "', '" & deskripsi & "', " & jKeluar & ", " & jMasuk & ", " & stokMut & ",  Convert(DateTime,'" & DateTime.Now.ToString("dd-mmm-yy") & "',3), 'System');")
            End While
            reader.Close()
            Dim counter As Integer = 0
            Dim batch As String = ""
            For Each r As String In sqlBatch
                counter += 1
                Try
                    If counter = 50 Then
                        counter = 0
                        cmd = New SqlCommand(batch, constring)
                        cmd.ExecuteNonQuery()
                        batch = ""
                    Else
                        batch &= r
                    End If
                Catch ex As Exception
                    MsgBox(r)
                    MsgBox(ex.ToString)
                End Try
            Next
            constring.Close()
        End If
    End Sub
End Class