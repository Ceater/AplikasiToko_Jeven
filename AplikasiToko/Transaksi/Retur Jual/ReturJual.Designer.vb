﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReturJual
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lb_totalretur = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lb_FullRetur = New System.Windows.Forms.Label()
        Me.lb_TotalUangyangSudahDiretur = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lb_Kekurangan = New System.Windows.Forms.Label()
        Me.lb_PembayaranDiterima = New System.Windows.Forms.Label()
        Me.lb_TotalTagihan = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lb_TotalUangYangDikembalikan = New System.Windows.Forms.Label()
        Me.lb_TotalJumlahBarang = New System.Windows.Forms.Label()
        Me.lb_BanyakJenisBarang = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tanggal Retur"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd - MM - yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(117, 111)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(305, 22)
        Me.DateTimePicker1.TabIndex = 15
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(177, 79)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(245, 22)
        Me.TextBox1.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Nomer Nota Retur Jual: "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 411)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(403, 30)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Proses"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv)
        Me.GroupBox1.Location = New System.Drawing.Point(432, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(771, 433)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail Barang"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToOrderColumns = True
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgv.Location = New System.Drawing.Point(4, 19)
        Me.dgv.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(763, 410)
        Me.dgv.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Nomer Nota: "
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(117, 15)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(248, 24)
        Me.ComboBox1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 54)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 54)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Nama Pembeli"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(369, 12)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 28)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Cari"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lb_totalretur)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.lb_FullRetur)
        Me.GroupBox2.Controls.Add(Me.lb_TotalUangyangSudahDiretur)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lb_Kekurangan)
        Me.GroupBox2.Controls.Add(Me.lb_PembayaranDiterima)
        Me.GroupBox2.Controls.Add(Me.lb_TotalTagihan)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 143)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(411, 154)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Catatan Pembayaran"
        '
        'lb_totalretur
        '
        Me.lb_totalretur.AutoSize = True
        Me.lb_totalretur.Location = New System.Drawing.Point(280, 120)
        Me.lb_totalretur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_totalretur.Name = "lb_totalretur"
        Me.lb_totalretur.Size = New System.Drawing.Size(16, 17)
        Me.lb_totalretur.TabIndex = 11
        Me.lb_totalretur.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(240, 120)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 17)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Rp."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(235, 17)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Pengurangan Piutang Karena Retur"
        '
        'lb_FullRetur
        '
        Me.lb_FullRetur.Location = New System.Drawing.Point(352, 58)
        Me.lb_FullRetur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_FullRetur.Name = "lb_FullRetur"
        Me.lb_FullRetur.Size = New System.Drawing.Size(51, 41)
        Me.lb_FullRetur.TabIndex = 8
        Me.lb_FullRetur.Text = "Full Retur"
        Me.lb_FullRetur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lb_FullRetur.Visible = False
        '
        'lb_TotalUangyangSudahDiretur
        '
        Me.lb_TotalUangyangSudahDiretur.AutoSize = True
        Me.lb_TotalUangyangSudahDiretur.Location = New System.Drawing.Point(280, 95)
        Me.lb_TotalUangyangSudahDiretur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_TotalUangyangSudahDiretur.Name = "lb_TotalUangyangSudahDiretur"
        Me.lb_TotalUangyangSudahDiretur.Size = New System.Drawing.Size(16, 17)
        Me.lb_TotalUangyangSudahDiretur.TabIndex = 7
        Me.lb_TotalUangyangSudahDiretur.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(240, 95)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 17)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Rp."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 95)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(203, 17)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Total Uang yang sudah Diretur"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 70)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(145, 17)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Kekurangan / Piutang"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 45)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 17)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Pembayaran Diterima"
        '
        'lb_Kekurangan
        '
        Me.lb_Kekurangan.AutoSize = True
        Me.lb_Kekurangan.Location = New System.Drawing.Point(280, 70)
        Me.lb_Kekurangan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_Kekurangan.Name = "lb_Kekurangan"
        Me.lb_Kekurangan.Size = New System.Drawing.Size(16, 17)
        Me.lb_Kekurangan.TabIndex = 2
        Me.lb_Kekurangan.Text = "0"
        '
        'lb_PembayaranDiterima
        '
        Me.lb_PembayaranDiterima.AutoSize = True
        Me.lb_PembayaranDiterima.Location = New System.Drawing.Point(280, 45)
        Me.lb_PembayaranDiterima.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_PembayaranDiterima.Name = "lb_PembayaranDiterima"
        Me.lb_PembayaranDiterima.Size = New System.Drawing.Size(16, 17)
        Me.lb_PembayaranDiterima.TabIndex = 2
        Me.lb_PembayaranDiterima.Text = "0"
        '
        'lb_TotalTagihan
        '
        Me.lb_TotalTagihan.AutoSize = True
        Me.lb_TotalTagihan.Location = New System.Drawing.Point(280, 20)
        Me.lb_TotalTagihan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_TotalTagihan.Name = "lb_TotalTagihan"
        Me.lb_TotalTagihan.Size = New System.Drawing.Size(16, 17)
        Me.lb_TotalTagihan.TabIndex = 2
        Me.lb_TotalTagihan.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(240, 70)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 17)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Rp."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(240, 45)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 17)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Rp."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(240, 20)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 17)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Rp."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total Tagihan"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.lb_TotalUangYangDikembalikan)
        Me.GroupBox3.Controls.Add(Me.lb_TotalJumlahBarang)
        Me.GroupBox3.Controls.Add(Me.lb_BanyakJenisBarang)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 305)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(403, 98)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ringkasan Pengembalian Barang"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 69)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(201, 17)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Total Uang yang Dikembalikan"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 44)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(139, 17)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Total Jumlah Barang"
        '
        'lb_TotalUangYangDikembalikan
        '
        Me.lb_TotalUangYangDikembalikan.AutoSize = True
        Me.lb_TotalUangYangDikembalikan.Location = New System.Drawing.Point(251, 69)
        Me.lb_TotalUangYangDikembalikan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_TotalUangYangDikembalikan.Name = "lb_TotalUangYangDikembalikan"
        Me.lb_TotalUangYangDikembalikan.Size = New System.Drawing.Size(16, 17)
        Me.lb_TotalUangYangDikembalikan.TabIndex = 2
        Me.lb_TotalUangYangDikembalikan.Text = "0"
        '
        'lb_TotalJumlahBarang
        '
        Me.lb_TotalJumlahBarang.AutoSize = True
        Me.lb_TotalJumlahBarang.Location = New System.Drawing.Point(251, 44)
        Me.lb_TotalJumlahBarang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_TotalJumlahBarang.Name = "lb_TotalJumlahBarang"
        Me.lb_TotalJumlahBarang.Size = New System.Drawing.Size(16, 17)
        Me.lb_TotalJumlahBarang.TabIndex = 2
        Me.lb_TotalJumlahBarang.Text = "0"
        '
        'lb_BanyakJenisBarang
        '
        Me.lb_BanyakJenisBarang.AutoSize = True
        Me.lb_BanyakJenisBarang.Location = New System.Drawing.Point(251, 20)
        Me.lb_BanyakJenisBarang.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_BanyakJenisBarang.Name = "lb_BanyakJenisBarang"
        Me.lb_BanyakJenisBarang.Size = New System.Drawing.Size(16, 17)
        Me.lb_BanyakJenisBarang.TabIndex = 2
        Me.lb_BanyakJenisBarang.Text = "0"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(211, 69)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 17)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Rp."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 20)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(142, 17)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Banyak Jenis Barang"
        '
        'ReturJual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1219, 458)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReturJual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retur Penjualan"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lb_Kekurangan As Label
    Friend WithEvents lb_PembayaranDiterima As Label
    Friend WithEvents lb_TotalTagihan As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lb_TotalUangYangDikembalikan As Label
    Friend WithEvents lb_TotalJumlahBarang As Label
    Friend WithEvents lb_BanyakJenisBarang As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lb_TotalUangyangSudahDiretur As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lb_FullRetur As Label
    Friend WithEvents lb_totalretur As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label11 As Label
End Class
