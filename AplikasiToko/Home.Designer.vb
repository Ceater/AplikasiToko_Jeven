<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.T1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.T2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.T3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.T4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.T5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.T6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.T7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.T8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.L1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.L9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetPersediaanAwalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateVersiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormResetDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 514)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(829, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(78, 17)
        Me.ToolStripStatusLabel1.Text = "Aplikasi Toko"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(63, 17)
        Me.ToolStripStatusLabel2.Text = "User Login"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(473, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel7.Text = "Versi 1.1.3.1"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(50, 17)
        Me.ToolStripStatusLabel4.Text = "Tanggal"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel5.Text = "|"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(41, 17)
        Me.ToolStripStatusLabel6.Text = "Waktu"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasterToolStripMenuItem, Me.TransaksiToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.LogoutToolStripMenuItem, Me.SettingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(829, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterToolStripMenuItem
        '
        Me.MasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M1, Me.M2, Me.M3})
        Me.MasterToolStripMenuItem.Name = "MasterToolStripMenuItem"
        Me.MasterToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.MasterToolStripMenuItem.Text = "Master"
        '
        'M1
        '
        Me.M1.Name = "M1"
        Me.M1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.M1.Size = New System.Drawing.Size(172, 22)
        Me.M1.Text = "Barang"
        '
        'M2
        '
        Me.M2.Name = "M2"
        Me.M2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.M2.Size = New System.Drawing.Size(172, 22)
        Me.M2.Text = "Staff"
        '
        'M3
        '
        Me.M3.Name = "M3"
        Me.M3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.M3.Size = New System.Drawing.Size(172, 22)
        Me.M3.Text = "Pelanggan"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.T1, Me.T2, Me.T3, Me.T4, Me.T5, Me.T6, Me.T7, Me.T8})
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.TransaksiToolStripMenuItem.Text = "Transaksi"
        '
        'T1
        '
        Me.T1.Name = "T1"
        Me.T1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.T1.Size = New System.Drawing.Size(202, 22)
        Me.T1.Text = "Penjualan"
        '
        'T2
        '
        Me.T2.Name = "T2"
        Me.T2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.T2.Size = New System.Drawing.Size(202, 22)
        Me.T2.Text = "Terima Barang"
        '
        'T3
        '
        Me.T3.Name = "T3"
        Me.T3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D3), System.Windows.Forms.Keys)
        Me.T3.Size = New System.Drawing.Size(202, 22)
        Me.T3.Text = "Pembayaran"
        '
        'T4
        '
        Me.T4.Name = "T4"
        Me.T4.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D4), System.Windows.Forms.Keys)
        Me.T4.Size = New System.Drawing.Size(202, 22)
        Me.T4.Text = "Stok Opname"
        '
        'T5
        '
        Me.T5.Name = "T5"
        Me.T5.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D5), System.Windows.Forms.Keys)
        Me.T5.Size = New System.Drawing.Size(202, 22)
        Me.T5.Text = "Print Ulang Nota"
        '
        'T6
        '
        Me.T6.Name = "T6"
        Me.T6.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D6), System.Windows.Forms.Keys)
        Me.T6.Size = New System.Drawing.Size(202, 22)
        Me.T6.Text = "Retur Terima"
        '
        'T7
        '
        Me.T7.Name = "T7"
        Me.T7.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D7), System.Windows.Forms.Keys)
        Me.T7.Size = New System.Drawing.Size(202, 22)
        Me.T7.Text = "Retur Jual"
        '
        'T8
        '
        Me.T8.Name = "T8"
        Me.T8.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D8), System.Windows.Forms.Keys)
        Me.T8.Size = New System.Drawing.Size(202, 22)
        Me.T8.Text = "Pembelian"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.L1, Me.L2, Me.L3, Me.L4, Me.L5, Me.L6, Me.L7, Me.L8, Me.L9})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'L1
        '
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(149, 22)
        Me.L1.Text = "Penjualan"
        '
        'L2
        '
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(149, 22)
        Me.L2.Text = "Barang Masuk"
        '
        'L3
        '
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(149, 22)
        Me.L3.Text = "Pembayaran"
        '
        'L4
        '
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(149, 22)
        Me.L4.Text = "Retur Terima"
        '
        'L5
        '
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(149, 22)
        Me.L5.Text = "Retur Jual"
        '
        'L6
        '
        Me.L6.Name = "L6"
        Me.L6.Size = New System.Drawing.Size(149, 22)
        Me.L6.Text = "Stok Barang"
        '
        'L7
        '
        Me.L7.Name = "L7"
        Me.L7.Size = New System.Drawing.Size(149, 22)
        Me.L7.Text = "Pembelian"
        '
        'L8
        '
        Me.L8.Name = "L8"
        Me.L8.Size = New System.Drawing.Size(149, 22)
        Me.L8.Text = "Laba Rugi"
        '
        'L9
        '
        Me.L9.Name = "L9"
        Me.L9.Size = New System.Drawing.Size(149, 22)
        Me.L9.Text = "Pendapatan"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrinterToolStripMenuItem, Me.SetPersediaanAwalToolStripMenuItem, Me.UpdateVersiToolStripMenuItem, Me.BackupDatabaseToolStripMenuItem, Me.FormResetDataToolStripMenuItem})
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'PrinterToolStripMenuItem
        '
        Me.PrinterToolStripMenuItem.Name = "PrinterToolStripMenuItem"
        Me.PrinterToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.PrinterToolStripMenuItem.Text = "Printer"
        '
        'SetPersediaanAwalToolStripMenuItem
        '
        Me.SetPersediaanAwalToolStripMenuItem.Enabled = False
        Me.SetPersediaanAwalToolStripMenuItem.Name = "SetPersediaanAwalToolStripMenuItem"
        Me.SetPersediaanAwalToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SetPersediaanAwalToolStripMenuItem.Text = "Set Persediaan Awal"
        '
        'UpdateVersiToolStripMenuItem
        '
        Me.UpdateVersiToolStripMenuItem.Name = "UpdateVersiToolStripMenuItem"
        Me.UpdateVersiToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.UpdateVersiToolStripMenuItem.Text = "Update Versi"
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.BackupDatabaseToolStripMenuItem.Text = "Backup Database"
        '
        'FormResetDataToolStripMenuItem
        '
        Me.FormResetDataToolStripMenuItem.Name = "FormResetDataToolStripMenuItem"
        Me.FormResetDataToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.FormResetDataToolStripMenuItem.Text = "Form Reset Data"
        '
        'Timer1
        '
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(602, 24)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(227, 490)
        Me.ListBox1.TabIndex = 4
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 536)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents T2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents L1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents L2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3 As ToolStripMenuItem
    Friend WithEvents T3 As ToolStripMenuItem
    Friend WithEvents T4 As ToolStripMenuItem
    Friend WithEvents T5 As ToolStripMenuItem
    Friend WithEvents L3 As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents T6 As ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrinterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents L4 As ToolStripMenuItem
    Friend WithEvents L6 As ToolStripMenuItem
    Friend WithEvents L5 As ToolStripMenuItem
    Friend WithEvents T7 As ToolStripMenuItem
    Friend WithEvents T8 As ToolStripMenuItem
    Friend WithEvents L7 As ToolStripMenuItem
    Friend WithEvents L8 As ToolStripMenuItem
    Friend WithEvents L9 As ToolStripMenuItem
    Friend WithEvents SetPersediaanAwalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents UpdateVersiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackupDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FormResetDataToolStripMenuItem As ToolStripMenuItem
End Class
