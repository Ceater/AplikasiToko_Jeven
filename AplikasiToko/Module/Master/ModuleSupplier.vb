﻿Imports System.Data.Sql
Imports System.Data.SqlClient

Module ModuleSupplier
    Dim cmd As SqlCommand
    Function getKodeSupplier(ByVal s As String)
        Dim x As Double = 0
        Try
            constring.Open()
            cmd = New SqlCommand("Select IDSupplier from TbSupplier where NamaSupplier=@ns", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@ns", s))
            End With
            x = cmd.ExecuteScalar
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
        Return x
    End Function

    Sub insertSupplier(ByVal NSupplier As String, ASupplier As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into TbSupplier(NamaSupplier, AlamatSupplier, Date_i, User_i) Values(@a,@b,@d,@e)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", NSupplier))
                .Add(New SqlParameter("@b", ASupplier))
                .Add(New SqlParameter("@d", DateTime.Now))
                .Add(New SqlParameter("@e", userLogin))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            constring.Close()
        End Try
    End Sub

    Sub insertSales(ByVal NSupplier As String, ByVal NSales As String, TSales As String)
        Try
            constring.Open()
            cmd = New SqlCommand("insert into TbKontakSupplier(IDSupplier, NamaSales, TlpSales, Date_i, User_i) Values(@a,@b,@c,@d,@e)", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", NSupplier))
                .Add(New SqlParameter("@b", NSales))
                .Add(New SqlParameter("@c", TSales))
                .Add(New SqlParameter("@d", DateTime.Now))
                .Add(New SqlParameter("@e", userLogin))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Sub updateSupplier(ByVal KSupplier As String, ByVal NSupplier As String, ASupplier As String)
        Try
            constring.Open()
            cmd = New SqlCommand("update TbSupplier set NamaSupplier=@a, AlamatSupplier=@b, Date_U=@d, User_U=@e where IDSupplier=@f", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", NSupplier))
                .Add(New SqlParameter("@b", ASupplier))
                .Add(New SqlParameter("@d", DateTime.Now))
                .Add(New SqlParameter("@e", userLogin))
                .Add(New SqlParameter("@f", KSupplier))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Sub updateSales(ByVal KSupplier As String, ByVal NSales As String, TSales As String, ByVal id As String)
        Try
            constring.Open()
            cmd = New SqlCommand("update TbKontakSupplier set IDSupplier=@a, NamaSales=@b, TlpSales=@c, date_u=@e, user_u=@f where IDKontakSupplier=@d", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", KSupplier))
                .Add(New SqlParameter("@b", NSales))
                .Add(New SqlParameter("@c", TSales))
                .Add(New SqlParameter("@d", id))
                .Add(New SqlParameter("@e", DateTime.Now))
                .Add(New SqlParameter("@f", userLogin))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Sub deleteSupplier(ByVal KSupplier As String)
        Try
            constring.Open()
            cmd = New SqlCommand("delete TbSupplier where IDSupplier=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", KSupplier))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub

    Sub deleteSales(ByVal id As String)
        Try
            constring.Open()
            cmd = New SqlCommand("delete TbKontakSupplier where IDKontakSupplier=@a", constring)
            With cmd.Parameters
                .Add(New SqlParameter("@a", id))
            End With
            cmd.ExecuteNonQuery()
            constring.Close()
        Catch ex As Exception
            constring.Close()
        End Try
    End Sub
End Module
