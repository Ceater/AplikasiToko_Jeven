﻿Module QueryModule
    'Digunakan untuk mendapatkan detail info barang dan nota barang yang masih bisa diretur dan jumlah barang yang sudah diretur.
    Public qstring1 As String = "select HJx.NoNotaJual,DJx.IDBarang, DJx.Jumlah, ISNULL((select DRJ.Jumlah From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0) as SudahDiretur From HJual HJx, DJual DJx Where HJx.NoNotaJual=DJx.NoNotaJual and DJx.Jumlah <> ISNULL((select DRJ.Jumlah From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0)"

    'Digunakan untuk mendapatkan list nota yang masih bisa melakukan retur.
    Public qstring2 As String = "select HJx.NoNotaJual From HJual HJx, DJual DJx Where HJx.NoNotaJual=DJx.NoNotaJual and DJx.Jumlah <> ISNULL((select DRJ.Jumlah From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0) group by HJx.NoNotaJual"

    'Digunakan untuk mendapatkan detail barang yang masih bisa diretur.
    Public qstring3 As String = "select DJx.IDBarang, DJx.NamaBarang, DJx.Satuan, DJx.HargaSatuan, DJx.Jumlah - ISNULL((select DRJ.Jumlah From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0) as Jumlah, DJx.Diskon, ((DJx.Jumlah - ISNULL((select DRJ.Jumlah From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0))*(DJx.HargaSatuan-Diskon)) as Subtotal From HJual HJx, DJual DJx Where HJx.NoNotaJual=DJx.NoNotaJual and DJx.Jumlah <> ISNULL((select DRJ.Jumlah From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0)"

    'Digunakan untuk mendapatkan list nota dan nama toko yang masih bisa melakukan retur.
    Public qstring4 As String = "select HJx.NoNotaJual, HJx.NamaPelanggan From HJual HJx, DJual DJx Where HJx.NoNotaJual=DJx.NoNotaJual and DJx.Jumlah <> ISNULL((select DRJ.Jumlah From HJual HJ, DJual DJ, HReturJual HRJ, DReturJual DRJ where HJ.NoNotaJual=DJ.NoNotaJual and HRJ.NoNotaReturJual=DRJ.NoNotaReturJual and HJ.NoNotaJual=HRJ.NoNotaJual and DJ.IDBarang=DRJ.IDBarang and DJ.IDBarang = DJx.IDBarang and HJ.NoNotaJual=HJx.NoNotaJual),0) group by HJx.NoNotaJual, HJx.NamaPelanggan"
End Module