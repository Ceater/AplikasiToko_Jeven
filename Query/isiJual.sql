delete HJual
delete DJual
delete TbPembayaran
DBCC CHECKIDENT ('TbPembayaran', RESEED, 0);
insert into HJual Values('J00001', '6/10/2017', 10000, 'Toko Maju Jaya','admin')
insert into DJUal Values('J00001', 'PE001', 'Pepsodent Kecil', 'Buah', 2500, 2, 0, 5000)
insert into DJUal Values('J00001', 'PE002', 'Pepsodent Sedang', 'Buah', 5000, 1, 0, 5000)
insert into TbPembayaran Values('J00001', '6/10/2017', 10000)
update TbBarang set stok=stok-2 where KodeBarang='PE001'
insert into HJual Values('J00002', '6/11/2017', 15000, 'Toko Maju Mundur', 'admin')
update TbBarang set stok=stok-1 where KodeBarang='PE002'
insert into DJUal Values('J00002', 'PE001', 'Pepsodent Kecil', 'Buah', 2500, 2, 0, 5000)
insert into DJUal Values('J00002', 'GE002', 'Gery Chocolatos', 'Dus', 10000, 1, 0, 10000)
insert into TbPembayaran Values('J00002', '6/11/2017', 10000)
update TbBarang set stok=stok-2 where KodeBarang='PE001'
update TbBarang set stok=stok-1 where KodeBarang='GE002'
insert into HJual Values('J00003', '6/11/2017', 20000, 'Toko Kiri Kanan', 'admin')
insert into DJUal Values('J00003', 'PE001', 'Pepsodent Kecil', 'Buah', 2500, 2, 0, 5000)
insert into DJUal Values('J00003', 'GE002', 'Gery Chocolatos', 'Dus', 10000, 1, 0, 10000)
insert into DJUal Values('J00003', 'AQ003', 'Aqua 1.5L', 'Botol', 5000, 1, 0, 5000)
insert into TbPembayaran Values('J00003', '6/13/2017', 10000)
insert into TbPembayaran Values('J00003', '6/14/2017', 5000)
update TbBarang set stok=stok-2 where KodeBarang='PE001'
update TbBarang set stok=stok-1 where KodeBarang='GE002'
update TbBarang set stok=stok-1 where KodeBarang='AQ003'
insert into HJual Values('J00004', '6/12/2017', 25000, 'Toko Sayonara', 'admin')
insert into DJUal Values('J00004', 'RO003', 'Rokok UMild', 'Bungkus', 15000, 1, 0, 15000)
insert into DJUal Values('J00004', 'GE002', 'Gery Chocolatos', 'Dus', 10000, 1, 0, 10000)
insert into TbPembayaran Values('J00004', '6/14/2017', 1000)
insert into TbPembayaran Values('J00004', '6/15/2017', 12500)
insert into TbPembayaran Values('J00004', '6/16/2017', 2500)
update TbBarang set stok=stok-1 where KodeBarang='RO003'
update TbBarang set stok=stok-1 where KodeBarang='GE002'
insert into HJual Values('J00005', '6/13/2017', 39000, 'Toko Permata', 'admin')
insert into DJUal Values('J00005', 'RO001', 'Rokok Inter', 'Bungkus', 13000, 2, 0, 26000)
insert into DJUal Values('J00005', 'RO002', 'Rokok Surya', 'Dus', 13000, 1, 0, 13000)
insert into TbPembayaran Values('J00005', '6/14/2017', 25000)
update TbBarang set stok=stok-2 where KodeBarang='RO001'
update TbBarang set stok=stok-1 where KodeBarang='RO002'