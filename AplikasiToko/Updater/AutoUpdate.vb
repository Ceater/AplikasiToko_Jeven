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
            'cek tabel HistoryExist
            cmd = New SqlCommand("
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HistoryVersi' AND type = 'U')
            BEGIN
	             CREATE TABLE [dbo].[HistoryVersi](
	                [No] [int] IDENTITY(1,1) NOT NULL,
	                [Versi] [varchar](max) NOT NULL,
                 CONSTRAINT [PK_HistoryVersi] PRIMARY KEY CLUSTERED 
                (
	                [No] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY];
                INSERT INTO HistoryVersi(Versi) VALUES('1.1.5.0');
            END
            ", constring)
            cmd.ExecuteNonQuery()
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
            constring.Close()
            If temp = Nothing Then
                updateBWorker.RunWorkerAsync()
            ElseIf temp <> Nothing And versiDB <> VersiSekarang Then
                MsgBox("Anda tidak menggunakan versi terbaru, silahkan update aplikasi")
                Me.Dispose()
            Else
                openHome()
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan pada autoupdate, error: " & errorCode)
        End Try
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
        constring.Open()
        cmd = New SqlCommand("
            DROP TABLE[dbo].[TbMutasi];
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
        updateBWorker.ReportProgress(10)
        'Step 1
        errorCode = "101"
        Dim stokAwal As New Dictionary(Of String, Double)
        cmd = New SqlCommand("SELECT 
	            KodeBarang, 
	            NamaBarang, 
	            Stok as 'Stok Sekarang', 
	            ISNULL((SELECT TOP 1 dter.Jumlah FROM DTerima dter WHERE dter.IDBarang = tbar.KodeBarang), 0) as 'Stok Awal'
            From TbBarang tbar;", constring)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read
            stokAwal.Add(reader.GetValue(0), 0)
        End While
        reader.Close()
        updateBWorker.ReportProgress(20)
        'Step 2
        errorCode = "102"
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
            sqlBatch.Enqueue("Insert into TbMutasi(NoNota,Deskripsi,Keluar,Masuk,Stok,Date_i,User_i) VALUES('" & nonota & "', '" & deskripsi & "', " & jKeluar & ", " & jMasuk & ", " & stokMut & ",  Convert(DateTime,'" & DateTime.Now.ToString("dd-MM-yy") & "',5), 'System');")
        End While
        reader.Close()
        updateBWorker.ReportProgress(30)
        'Step 3
        errorCode = "103"
        Dim totalData As Double = sqlBatch.Count
        Dim progresData As Double = 0
        Dim progresPercentage As Double = 70 / totalData
        Dim counter As Integer = 0
        Dim batch As String = ""
        For Each r As String In sqlBatch
            counter += 1
            progresData += 1
            If counter = 50 Then
                updateBWorker.ReportProgress(30 + CInt((progresPercentage * progresData)))
                counter = 0
                cmd = New SqlCommand(batch, constring)
                cmd.ExecuteNonQuery()
                batch = ""
            Else
                batch &= r
            End If
        Next
        constring.Close()
        'step end
        errorCode = "104"
        updateBWorker.ReportProgress(100)
    End Sub

    Sub openHome()
        Dim f As New Home
        f.ToolStripStatusLabel2.Text = username
        f.hakAkses = getHAkses(username)
        f.Show()
        Me.Dispose()
    End Sub
End Class