Public Class ReturJual
    Dim staff As String = ""
    Public Sub New(ByVal id As String)
        InitializeComponent()
        staff = id
    End Sub

    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ComboBox1.DataSource = DSet.Tables("DataNotaPenjualan")
        ComboBox1.ValueMember = "NoNotaJual"
        ComboBox1.SelectedIndex = 1
        ComboBox1.SelectedIndex = 0
        DateTimePicker1.MaxDate = Now
        TextBox1.Text = getNotaReturJual()
        clear()
    End Sub
End Class