Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class GrafikLaporan
    Dim bln = 0, thn As Integer = 0
    Dim periode As String = ""
    Dim formReady As Boolean = False

    Private Sub GrafikLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Penjualan")
        ComboBox2.Items.Add("Tahunan")
        ComboBox2.Items.Add("Bulanan")
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
    End Sub

    Private Sub GrafikLaporan_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        formReady = True
        refreshReport()
    End Sub

    Private Sub refreshOnChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged, ComboBox3.SelectedIndexChanged, ComboBox4.SelectedIndexChanged
        If formReady Then
            refreshReport()
        End If
    End Sub

    Sub refreshReport()
        Dim con As SqlConnection
        Dim adapt As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim cmd As New SqlCommand
        Dim rep As New ReportDocument

        bln = ComboBox3.SelectedIndex + 1
        thn = ComboBox4.SelectedIndex + 2018
        periode = ComboBox3.SelectedItem & " " & ComboBox4.SelectedItem
        Try
            con = constring
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Clear()
            adapt.SelectCommand = cmd
            dataset.Clear()
            cmd.CommandText = "SELECT H.NoNotaJual, DAY(H.TglNota) as 'TglNota', (H.GrandTotal/1000) as 'GrandTotal', H.NamaPelanggan, H.IDStaff, D.IDBarang, D.NamaBarang, D.Satuan, D.HargaSatuan, D.Jumlah, D.Diskon, D.Subtotal from HJual H, DJual D where H.NoNotaJual=D.NoNotaJual AND MONTH(tglNota) = @a AND YEAR(tglnota) = @b"
            cmd.Parameters.AddWithValue("@a", bln)
            cmd.Parameters.AddWithValue("@b", thn)
            adapt.Fill(dataset, "Penjualan")
            rep = New LaporanGrafik
            rep.SetDataSource(dataset)
            rep.SetParameterValue("Periode", periode)
            con.Close()
            crv.ReportSource = rep
            crv.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class