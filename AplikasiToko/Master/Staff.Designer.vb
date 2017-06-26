<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Staff
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.CheckBox()
        Me.T5 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T4 = New System.Windows.Forms.CheckBox()
        Me.L1 = New System.Windows.Forms.CheckBox()
        Me.T2 = New System.Windows.Forms.CheckBox()
        Me.M4 = New System.Windows.Forms.CheckBox()
        Me.M3 = New System.Windows.Forms.CheckBox()
        Me.L2 = New System.Windows.Forms.CheckBox()
        Me.T3 = New System.Windows.Forms.CheckBox()
        Me.T1 = New System.Windows.Forms.CheckBox()
        Me.M2 = New System.Windows.Forms.CheckBox()
        Me.M1 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Tambah = New System.Windows.Forms.Button()
        Me.Hapus = New System.Windows.Forms.Button()
        Me.Reset = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(543, 468)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Tambah)
        Me.GroupBox1.Controls.Add(Me.Hapus)
        Me.GroupBox1.Controls.Add(Me.Reset)
        Me.GroupBox1.Location = New System.Drawing.Point(561, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 468)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Staff"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.L3)
        Me.GroupBox2.Controls.Add(Me.T5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.T4)
        Me.GroupBox2.Controls.Add(Me.L1)
        Me.GroupBox2.Controls.Add(Me.T2)
        Me.GroupBox2.Controls.Add(Me.M4)
        Me.GroupBox2.Controls.Add(Me.M3)
        Me.GroupBox2.Controls.Add(Me.L2)
        Me.GroupBox2.Controls.Add(Me.T3)
        Me.GroupBox2.Controls.Add(Me.T1)
        Me.GroupBox2.Controls.Add(Me.M2)
        Me.GroupBox2.Controls.Add(Me.M1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 201)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(253, 232)
        Me.GroupBox2.TabIndex = 99
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hak Akses"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Laporan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(143, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Transaksi"
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.Location = New System.Drawing.Point(6, 199)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(85, 17)
        Me.L3.TabIndex = 12
        Me.L3.Text = "Pembayaran"
        Me.L3.UseVisualStyleBackColor = True
        '
        'T5
        '
        Me.T5.AutoSize = True
        Me.T5.Location = New System.Drawing.Point(143, 136)
        Me.T5.Name = "T5"
        Me.T5.Size = New System.Drawing.Size(104, 17)
        Me.T5.TabIndex = 18
        Me.T5.Text = "Print Ulang Nota"
        Me.T5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Master"
        '
        'T4
        '
        Me.T4.AutoSize = True
        Me.T4.Location = New System.Drawing.Point(143, 113)
        Me.T4.Name = "T4"
        Me.T4.Size = New System.Drawing.Size(85, 17)
        Me.T4.TabIndex = 17
        Me.T4.Text = "Pembayaran"
        Me.T4.UseVisualStyleBackColor = True
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.Location = New System.Drawing.Point(6, 153)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(73, 17)
        Me.L1.TabIndex = 10
        Me.L1.Text = "Penjualan"
        Me.L1.UseVisualStyleBackColor = True
        '
        'T2
        '
        Me.T2.AutoSize = True
        Me.T2.Location = New System.Drawing.Point(143, 67)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(95, 17)
        Me.T2.TabIndex = 14
        Me.T2.Text = "Terima Barang"
        Me.T2.UseVisualStyleBackColor = True
        '
        'M4
        '
        Me.M4.AutoSize = True
        Me.M4.Location = New System.Drawing.Point(6, 113)
        Me.M4.Name = "M4"
        Me.M4.Size = New System.Drawing.Size(77, 17)
        Me.M4.TabIndex = 9
        Me.M4.Text = "Pelanggan"
        Me.M4.UseVisualStyleBackColor = True
        '
        'M3
        '
        Me.M3.AutoSize = True
        Me.M3.Location = New System.Drawing.Point(6, 90)
        Me.M3.Name = "M3"
        Me.M3.Size = New System.Drawing.Size(48, 17)
        Me.M3.TabIndex = 8
        Me.M3.Text = "Staff"
        Me.M3.UseVisualStyleBackColor = True
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.Location = New System.Drawing.Point(6, 176)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(95, 17)
        Me.L2.TabIndex = 11
        Me.L2.Text = "Barang Masuk"
        Me.L2.UseVisualStyleBackColor = True
        '
        'T3
        '
        Me.T3.AutoSize = True
        Me.T3.Location = New System.Drawing.Point(143, 90)
        Me.T3.Name = "T3"
        Me.T3.Size = New System.Drawing.Size(91, 17)
        Me.T3.TabIndex = 16
        Me.T3.Text = "Stok Opname"
        Me.T3.UseVisualStyleBackColor = True
        '
        'T1
        '
        Me.T1.AutoSize = True
        Me.T1.Location = New System.Drawing.Point(143, 44)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(73, 17)
        Me.T1.TabIndex = 13
        Me.T1.Text = "Penjualan"
        Me.T1.UseVisualStyleBackColor = True
        '
        'M2
        '
        Me.M2.AutoSize = True
        Me.M2.Location = New System.Drawing.Point(6, 67)
        Me.M2.Name = "M2"
        Me.M2.Size = New System.Drawing.Size(64, 17)
        Me.M2.TabIndex = 7
        Me.M2.Text = "Supplier"
        Me.M2.UseVisualStyleBackColor = True
        '
        'M1
        '
        Me.M1.AutoSize = True
        Me.M1.Location = New System.Drawing.Point(6, 44)
        Me.M1.Name = "M1"
        Me.M1.Size = New System.Drawing.Size(60, 17)
        Me.M1.TabIndex = 6
        Me.M1.Text = "Barang"
        Me.M1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "No. Tlp"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Alamat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(67, 175)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(195, 20)
        Me.TextBox5.TabIndex = 5
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(67, 97)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(195, 72)
        Me.TextBox4.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(67, 45)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(195, 20)
        Me.TextBox2.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Nama"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Username"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(67, 71)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(195, 20)
        Me.TextBox3.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(67, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(195, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Tambah
        '
        Me.Tambah.Location = New System.Drawing.Point(9, 439)
        Me.Tambah.Name = "Tambah"
        Me.Tambah.Size = New System.Drawing.Size(75, 23)
        Me.Tambah.TabIndex = 0
        Me.Tambah.Text = "Tambah"
        Me.Tambah.UseVisualStyleBackColor = True
        '
        'Hapus
        '
        Me.Hapus.Location = New System.Drawing.Point(90, 439)
        Me.Hapus.Name = "Hapus"
        Me.Hapus.Size = New System.Drawing.Size(91, 23)
        Me.Hapus.TabIndex = 0
        Me.Hapus.Text = "Hapus"
        Me.Hapus.UseVisualStyleBackColor = True
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(187, 439)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(75, 23)
        Me.Reset.TabIndex = 0
        Me.Reset.Text = "Reset"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'Staff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 492)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Staff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Staff"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents L3 As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents L2 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents T2 As CheckBox
    Friend WithEvents L1 As CheckBox
    Friend WithEvents M3 As CheckBox
    Friend WithEvents T1 As CheckBox
    Friend WithEvents M2 As CheckBox
    Friend WithEvents M1 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Reset As Button
    Friend WithEvents T5 As CheckBox
    Friend WithEvents T4 As CheckBox
    Friend WithEvents M4 As CheckBox
    Friend WithEvents T3 As CheckBox
    Friend WithEvents Tambah As Button
    Friend WithEvents Hapus As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox3 As TextBox
End Class
