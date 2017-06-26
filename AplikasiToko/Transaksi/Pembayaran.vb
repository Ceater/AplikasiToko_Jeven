Public Class Pembayaran
    Dim Pembayaran As Integer
    Dim lblArr(8) As Label
    Dim staff As String = ""

    Private Sub Pembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblArr(0) = NNota
        lblArr(1) = NToko
        lblArr(2) = TotTag1
        lblArr(3) = Kekurangan1
        lblArr(4) = TotTag2
        lblArr(5) = Kekurangan2
        lblArr(6) = Bayar
        lblArr(7) = HAkhir
        lblArr(8) = NNotaPembayaran
        clear()
        loadTagihan()
        loadListBox()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim temp() As String = Split(loadTagihan.Item(sender.selectedindex), "-")
            lblArr(0).Text = temp(0)
            lblArr(1).Text = temp(2)
            lblArr(2).Text = FormatCurrency(temp(3))
            lblArr(3).Text = FormatCurrency(temp(4))
            lblArr(4).Text = FormatCurrency(temp(3))
            lblArr(5).Text = FormatCurrency(temp(4))
            lblArr(6).Text = "0"
            lblArr(7).Text = FormatCurrency(lblArr(6).Text - temp(4))
            HitungUang()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        HitungUang()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode >= 48 And e.KeyCode <= 57 Or e.KeyCode >= 96 And e.KeyCode <= 105 Or e.KeyCode = 8 Or e.KeyCode = 46 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If sender.text = "" Then
            sender.text = "0"
            HitungUang()
        Else
            HitungUang()
            If CInt(sender.text) <> 0 Then
                sender.text = FormatCurrency(sender.text)
            Else
                sender.text = CInt(sender.text)
            End If
        End If
        sender.select(sender.text.length, 0)
    End Sub

    Private Sub Proses_Click(sender As Object, e As EventArgs) Handles Proses.Click
        Dim tgl As String = DateTimePicker1.Value.Year & "-" & DateTimePicker1.Value.Month & "-" & DateTimePicker1.Value.Day
        Dim result As Integer = MessageBox.Show("Apakah data sudah benar?", "Peringatan", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            insertPembayaran(lblArr(0).Text, tgl, CInt(lblArr(6).Text))
            MsgBox("Pembayaran berhasil")
            Dim f As New FormLaporan("NotaPembayaran")
            f.LaporanNoNota = lblArr(0).Text
            f.Show()
            clear()
            loadListBox()
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    Sub HitungUang()
        Try
            If RadioButton1.Checked Then
                Pembayaran = lblArr(5).Text
            Else
                Pembayaran = TextBox1.Text
            End If
            lblArr(6).Text = FormatCurrency(Pembayaran)
            lblArr(7).Text = FormatCurrency(Pembayaran - lblArr(5).Text)
        Catch ex As Exception

        End Try
    End Sub

    Sub clear()
        TextBox1.Text = "0"
        lblArr(0).Text = ""
        lblArr(1).Text = ""
        lblArr(2).Text = "0"
        lblArr(3).Text = "0"
        lblArr(4).Text = "0"
        lblArr(5).Text = "0"
        lblArr(6).Text = "0"
        lblArr(7).Text = "0"
        lblArr(8).Text = cekNotaPembayaran()
        RadioButton1.Checked = True
    End Sub

    Sub loadListBox()
        If loadTagihan.Count <> 0 Then
            ListBox1.Items.Clear()
            For i = 0 To loadTagihan.Count - 1
                Dim temp() As String
                temp = Split(loadTagihan.Item(i), "-")
                ListBox1.Items.Add(temp(0))
            Next
            ListBox1.SelectedIndex = 0
        Else
            MsgBox("Tidak ada tagihan yang belum lunas")
        End If
    End Sub

    Sub setStaff(x As String)
        staff = x
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