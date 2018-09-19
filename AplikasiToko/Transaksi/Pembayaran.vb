Public Class Pembayaran
    Dim Pembayaran As Integer
    Dim lblArr(11) As Label
    Dim staff As String = ""
    Dim formReady As Boolean = False

    Private Sub Awalan(sender As Object, e As EventArgs) Handles MyBase.Shown
        lblArr(0) = NNota
        lblArr(1) = NToko
        lblArr(2) = TotTag1
        lblArr(3) = SPiutang
        lblArr(4) = TotTag2
        lblArr(5) = Kekurangan2
        lblArr(6) = Bayar
        lblArr(7) = HAkhir
        lblArr(8) = NNotaPembayaran
        lblArr(9) = TotTerbayar
        lblArr(10) = SPiutang
        lblArr(11) = PHutang
        clear()
        loadTagihan(1, 2018)
        loadListBox()
        formReady = True
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ListBox1.SelectedIndex = -1
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If formReady Then
            Dim bln = 1, thn As Integer = 2018
            Try
                bln = ComboBox1.SelectedIndex + 1
                thn = ComboBox2.SelectedIndex + 2018
            Catch ex As Exception

            End Try
            Try
                Dim temp2 As String = getDetailTagihan(ListBox1.SelectedItem)
                Dim temp() As String = Split(temp2, "-")
                lblArr(0).Text = temp(0)
                lblArr(1).Text = temp(2)
                lblArr(2).Text = FormatCurrency(temp(3))
                lblArr(3).Text = FormatCurrency(temp(7))
                lblArr(4).Text = FormatCurrency(temp(3))
                lblArr(5).Text = FormatCurrency(temp(5))
                lblArr(6).Text = "0"
                lblArr(7).Text = FormatCurrency(lblArr(6).Text - temp(4))
                lblArr(9).Text = FormatCurrency(temp(4))
                lblArr(10).Text = FormatCurrency(temp(5))
                lblArr(11).Text = FormatCurrency(temp(6))
                HitungUang()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        If formReady Then
            HitungUang()
        End If
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
            lblArr(8).Text = cekNotaPembayaran()
            insertPembayaran(lblArr(0).Text, tgl, CInt(lblArr(6).Text), staff)
            updatePiutang(lblArr(0).Text, tgl, CInt(lblArr(6).Text), staff)
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
        lblArr(9).Text = "0"
        lblArr(10).Text = "0"
        lblArr(11).Text = "0"
        RadioButton1.Checked = True
    End Sub

    Sub loadListBox()
        Dim bln = 0, thn As Integer = 0
        bln = ComboBox1.SelectedIndex + 1
        thn = ComboBox2.SelectedIndex + 2018
        Dim hasil As ArrayList = loadTagihan(bln, thn)
        ListBox1.Items.Clear()
        If hasil.Count <> 0 Then
            For i = 0 To hasil.Count - 1
                Dim temp() As String
                temp = Split(hasil.Item(i), "-")
                ListBox1.Items.Add(temp(0))
            Next
            ListBox1.SelectedIndex = 0
        Else

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

    Private Sub searchNota(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged
        If formReady Then
            loadListBox()
        End If
    End Sub
End Class