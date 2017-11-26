delete DJual
delete HJual
delete HTerima
delete DTerima
delete TbPembayaran
delete HReturTerima
delete DReturTerima
delete HReturJual
delete DReturJual
delete HPembelian
delete DPembelian
DBCC CHECKIDENT ('DReturTerima', RESEED, 0);
DBCC CHECKIDENT ('DReturJual', RESEED, 0);
DBCC CHECKIDENT ('DJual', RESEED, 0);
DBCC CHECKIDENT ('DTerima', RESEED, 0);
DBCC CHECKIDENT ('TbPelanggan', RESEED, 0);
DBCC CHECKIDENT ('TbPembayaran', RESEED, 0);
DBCC CHECKIDENT ('DPembelian', RESEED, 0);
/****** ======================================================================================== ******/
insert into HTerima values('T00001','6/1/2017','admin')
insert into DTerima Values('T00001', 'PE001', 'Pepsodent Kecil', 'Buah', 75)
insert into DTerima Values('T00001', 'PE002', 'Pepsodent Sedang', 'Buah', 75)
insert into DTerima Values('T00001', 'PE003', 'Pepsodent Besar', 'Buah', 75)
update TbBarang set stok=stok+75 where KodeBarang='PE001'
update TbBarang set stok=stok+75 where KodeBarang='PE002'
update TbBarang set stok=stok+75 where KodeBarang='PE003'
insert into HTerima values('T00002','6/2/2017','admin')
insert into DTerima Values('T00002', 'SA001', 'Sabun Lifeboy', 'Batang', 100)
insert into DTerima Values('T00002', 'SA002', 'Sabun Lux', 'Batang', 100)
update TbBarang set stok=stok+100 where KodeBarang='SA001'
update TbBarang set stok=stok+100 where KodeBarang='SA002'
insert into HTerima values('T00003','6/3/2017','admin')
insert into DTerima Values('T00003', 'GE001', 'Gery Chocolatos', 'Bungkus', 100)
insert into DTerima Values('T00003', 'GE002', 'Gery Chocolatos', 'Dus', 100)
update TbBarang set stok=stok+100 where KodeBarang='GE001'
update TbBarang set stok=stok+100 where KodeBarang='GE002'
insert into HTerima values('T00004','6/4/2017','admin')
insert into DTerima Values('T00004', 'AQ001', 'Aqua Gelas', 'Buah', 100)
insert into DTerima Values('T00004', 'AQ002', 'Aqua Sedang', 'Botol', 100)
insert into DTerima Values('T00004', 'AQ003', 'Aqua 1.5L', 'Botol', 100)
update TbBarang set stok=stok+100 where KodeBarang='AQ001'
update TbBarang set stok=stok+100 where KodeBarang='AQ002'
update TbBarang set stok=stok+100 where KodeBarang='AQ003'
insert into HTerima values('T00005','6/5/2017','admin')
insert into DTerima Values('T00005', 'TE001', 'Teh Pucuk Harum', 'Botol', 100)
insert into DTerima Values('T00005', 'YO001', 'You C 1000', 'Botol', 100)
update TbBarang set stok=stok+100 where KodeBarang='TE001'
update TbBarang set stok=stok+100 where KodeBarang='YO001'
insert into HTerima values('T00006','6/6/2017','admin')
insert into DTerima Values('T00006', 'RO001', 'Rokok Inter', 'Bungkus', 100)
insert into DTerima Values('T00006', 'RO002', 'Rokok Surya', 'Bungkus', 100)
insert into DTerima Values('T00006', 'RO003', 'Rokok UMild', 'Bungkus', 100)
update TbBarang set stok=stok+100 where KodeBarang='RO001'
update TbBarang set stok=stok+100 where KodeBarang='RO002'
update TbBarang set stok=stok+100 where KodeBarang='RO003'
insert into HTerima values('T00007','6/7/2017','admin')
insert into DTerima Values('T00007', 'PE001', 'Pepsodent Kecil', 'Buah', 50)
insert into DTerima Values('T00007', 'PE002', 'Pepsodent Sedang', 'Buah', 50)
insert into DTerima Values('T00007', 'PE003', 'Pepsodent Besar', 'Buah', 50)
update TbBarang set stok=stok+50 where KodeBarang='PE001'
update TbBarang set stok=stok+50 where KodeBarang='PE002'
update TbBarang set stok=stok+50 where KodeBarang='PE003'
insert into HTerima values('T00008','6/8/2017','admin')
insert into DTerima Values('T00008', 'PE001', 'Pepsodent Kecil', 'Buah', 10)
insert into DTerima Values('T00008', 'SA001', 'Sabun Lifeboy', 'Batang', 10)
insert into DTerima Values('T00008', 'RO003', 'Rokok UMild', 'Bungkus', 10)
update TbBarang set stok=stok+10 where KodeBarang='PE001'
update TbBarang set stok=stok+10 where KodeBarang='SA001'
update TbBarang set stok=stok+10 where KodeBarang='RO003'
/****** ======================================================================================== ******/
insert into HPembelian values(1, 'T00001', 1125000)
insert into DPembelian values(1, 'PE001', 'Pepsodent Kecil', 'Buah', 5000, 75, 375000)
insert into DPembelian values(1, 'PE002', 'Pepsodent Sedang', 'Buah', 5000, 75, 375000)
insert into DPembelian values(1, 'PE003', 'Pepsodent Kecil', 'Buah', 5000, 75, 375000)
insert into HPembelian values(2, 'T00002', 720000)
insert into DPembelian values(2, 'SA001', 'Sabun Lifeboy', 'Batang', 3500, 100, 350000)
insert into DPembelian values(2, 'SA002', 'Sabun Lux', 'Batang', 3700, 100, 370000)
insert into HPembelian values(3, 'T00005', 720000)
insert into DPembelian values(3, 'TE001', 'Teh Pucuk Harum', 'Botol', 2000, 100, 200000)
insert into DPembelian values(3, 'YO001', 'You C 1000', 'Botol', 6500, 100, 650000)
/****** ======================================================================================== ******/
insert into HReturTerima values('RT00002','T00007','6/25/2017','admin')
insert into DReturTerima values('RT00002','PE001','Pepsodent Kecil', 'Buah', 50)
update TbBarang set stok=stok-50 where KodeBarang='PE001'