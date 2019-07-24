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
            updateStart()
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

    Sub updateStart()
        Try
            updateBWorker.ReportProgress(20)
            cmd = New SqlCommand("
            CREATE TABLE TbSupplier(
	            IDSupplier int NOT NULL IDENTITY (1, 1),
	            NamaSupplier varchar(MAX) NOT NULL,
	            AlamatSupplier varchar(MAX) NOT NULL,
	            Date_i datetime NULL,
	            Date_u datetime NULL,
	            User_i varchar(100) NULL,
	            User_u varchar(100) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
            ALTER TABLE dbo.TbSupplier ADD CONSTRAINT
	            PK_TbSupplier PRIMARY KEY CLUSTERED (IDSupplier) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
            CREATE TABLE TbKontakSupplier(
	            IDKontakSupplier int NOT NULL IDENTITY (1, 1),
	            IDSupplier int NOT NULL,
	            NamaSales varchar(MAX) NOT NULL,
	            TlpSales varchar(MAX) NOT NULL,
	            Date_i datetime NULL,
	            Date_u datetime NULL,
	            User_i varchar(100) NULL,
	            User_u varchar(100) NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
            ALTER TABLE dbo.TbKontakSupplier ADD CONSTRAINT
	            PK_TbKontakSupplier PRIMARY KEY CLUSTERED (IDKontakSupplier) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];

            ALTER TABLE HTerima ADD NoNotaPenjual varchar(25) NULL;
            ALTER TABLE HTerima ADD NamaSupplier varchar(25) NULL;
            ALTER TABLE HPembelian ADD NoNotaPenjual varchar(25) NULL;
            ALTER TABLE HPembelian ADD NamaSupplier varchar(25) NULL;
            ALTER TABLE HReturTerima ADD NoNotaPenjual varchar(25) NULL;
            ALTER TABLE HReturTerima ADD NamaSupplier varchar(25) NULL;
            ALTER TABLE DTerima ADD SuksesRetur float(53) NULL;", constring)
            cmd.ExecuteNonQuery()
            updateBWorker.ReportProgress(40)
            cmd = New SqlCommand("
                UPDATE HTerima SET NoNotaPenjual = 'NoInfo', NamaSupplier = 'NoInfo';
                UPDATE HPembelian SET NoNotaPenjual = 'NoInfo', NamaSupplier = 'NoInfo';
                UPDATE HReturTerima SET NoNotaPenjual = 'NoInfo', NamaSupplier = 'NoInfo';
                Update DTerima Set SuksesRetur = (ISNULL((Select SUM(Jumlah) FROM HReturTerima HRT INNER JOIN DReturTerima DRT On HRT.NoNotaReturTerima = DRT.NoNotaReturTerima WHERE NoNotaTerima = DTerima.NoNotaTerima And DRT.IDBarang = DTerima.IDBarang),0));
                ", constring)
            cmd.ExecuteNonQuery()
            updateBWorker.ReportProgress(100)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class