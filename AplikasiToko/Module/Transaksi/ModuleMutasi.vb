Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleMutasi
    Public Sub ins_mutasi(NoNota As String, Deskripsi As String, jKeluar As Double, jMasuk As Double, stok As Double, idstaff As String)
        Try
            constring.Open()
            cmd = New SqlCommand("Insert into TbMutasi(NoNota,Deskripsi,Keluar,Masuk,Stok,Date_i,User_i) VALUES(@a,@b,@c,@d,@e,GETDATE(),@f)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", NoNota))
                .Add(New SqlParameter("@b", deskripsi))
                .Add(New SqlParameter("@c", jKeluar))
                .Add(New SqlParameter("@d", jMasuk))
                .Add(New SqlParameter("@e", stok))
                .Add(New SqlParameter("@f", userLogin))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
            MsgBox("Memasukan Mutasi Gagal")
        End Try
    End Sub
End Module
