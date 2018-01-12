Public Class PenerimaanTambahBarang

    Private Sub PenjualanTambahBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ComboBox1.DataSource = DSet.Tables("DataSatuan")
            ComboBox1.DisplayMember = "NamaSatuan"
            ComboBox1.ValueMember = "KodeSatuan"
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Data Satuan Barang Belum Di isi")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Or TextBox2.Text <> "" Or TextBox3.Text <> "" Or TextBox4.Text <> "" Or TextBox5.Text <> "" Then
            Dim dr As DialogResult
            dr = MsgBox("Apakah data sudah benar?", MsgBoxStyle.YesNo)
            If dr = DialogResult.Yes Then
                insertBarang(TextBox1.Text, TextBox2.Text, 0, ComboBox1.SelectedValue, TextBox3.Text, TextBox4.Text, TextBox5.Text, 5)
                MsgBox("Data berhasil ditambahkan")
                LoadDataSet()
                Me.Close()
            End If
        Else
            MsgBox("Jangan ada yang dikosongkan")
        End If
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown, TextBox4.KeyDown, TextBox5.KeyDown
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Or e.KeyCode = 8 Or e.KeyCode = 46 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Txt_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp, TextBox4.KeyUp, TextBox5.KeyUp
        If sender.text = "" Then
            sender.text = "0"
        Else
            If CInt(sender.text) <> 0 Then
                sender.text = FormatCurrency(sender.text)
            Else
                sender.text = CInt(sender.text)
            End If
        End If
        sender.select(sender.text.length, 0)
    End Sub

    Function FormatCurrency(xx As Integer)
        Dim s As String
        If xx <> 0 Then
            s = xx.ToString("###,###")
        Else
            s = xx
        End If
        Return s
    End Function
End Class