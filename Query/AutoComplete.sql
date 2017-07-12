delete DJual
delete HJual
delete HTerima
delete DTerima
delete TbBarang
delete TbSatuan
delete TbStaff
delete TbPelanggan
delete TbPembayaran
delete HReturTerima
delete DReturTerima
delete HReturJual
delete DReturJual
DBCC CHECKIDENT ('DReturTerima', RESEED, 0);
DBCC CHECKIDENT ('DReturJual', RESEED, 0);
DBCC CHECKIDENT ('DJual', RESEED, 0);
DBCC CHECKIDENT ('DTerima', RESEED, 0);
DBCC CHECKIDENT ('TbPelanggan', RESEED, 0);
DBCC CHECKIDENT ('TbPembayaran', RESEED, 0);
/****** ======================================================================================== ******/
insert into TbBarang values('PE001','Pepsodent Kecil',0,2,2500,2000,1500,5)
insert into TbBarang values('PE002','Pepsodent Sedang',0,2,5000,4500,4000,5)
insert into TbBarang values('PE003','Pepsodent Besar',0,2,7500,7000,6500,5)
insert into TbBarang values('SA001','Sabun Lifeboy',0,6,3500,3000,2500,5)
insert into TbBarang values('SA002','Sabun Lux',0,6,3500,3000,2500,5)
insert into TbBarang values('GE001','Gery Chocolatos',0,7,500,500,500,0)
insert into TbBarang values('GE002','Gery Chocolatos',0,14,10000,9500,9000,5)
insert into TbBarang values('AQ001','Aqua Gelas',0,2,500,500,500,10)
insert into TbBarang values('AQ002','Aqua Sedang',0,11,3000,2500,2000,10)
insert into TbBarang values('AQ003','Aqua 1.5L',0,11,5000,4500,4000,10)
insert into TbBarang values('TE001','Teh Pucuk Harum',0,11,5000,4500,4000,10)
insert into TbBarang values('YO001','You C 1000',0,11,8000,6500,7000,10)
insert into TbBarang values('RO001','Rokok Inter',0,7,13000,12500,12000,5)
insert into TbBarang values('RO002','Rokok Surya',0,7,13000,12500,12000,5)
insert into TbBarang values('RO003','Rokok UMild',0,7,15000,14500,14000,5)
/****** ======================================================================================== ******/
insert into TbSatuan values('1','Unit')
insert into TbSatuan values('2','Buah')
insert into TbSatuan values('3','Pasang')
insert into TbSatuan values('4','Lembar')
insert into TbSatuan values('5','Keping')
insert into TbSatuan values('6','Batang')
insert into TbSatuan values('7','Bungkus')
insert into TbSatuan values('8','Potong')
insert into TbSatuan values('9','Tablet')
insert into TbSatuan values('10','Rim')
insert into TbSatuan values('11','Botol')
insert into TbSatuan values('12','Butir')
insert into TbSatuan values('13','Roll')
insert into TbSatuan values('14','Dus')
insert into TbSatuan values('15','Karung')
insert into TbSatuan values('16','Koli')
insert into TbSatuan values('17','Sak')
insert into TbSatuan values('18','Bal')
insert into TbSatuan values('19','Kaleng')
insert into TbSatuan values('20','Set')
insert into TbSatuan values('21','Slop')
insert into TbSatuan values('22','Gulung')
insert into TbSatuan values('23','Ton')
insert into TbSatuan values('24','Kilogram')
insert into TbSatuan values('25','Gram')
insert into TbSatuan values('26','Miligram')
insert into TbSatuan values('27','Meter')
insert into TbSatuan values('28','Liter')
/****** ======================================================================================== ******/
insert into TbStaff values('admin','admin','Johan Jusianto','Kupang Panjaan','08175135582','111111111111111')
insert into TbStaff values('kasir','kasir','Chintya Marcheline','Diponegoro','081081081081','111111111111111')
/****** ======================================================================================== ******/
insert into TbPelanggan values('Johan Jusianto','Kupang Panjaan','031-5614844')
insert into TbPelanggan values('Willy Budiman','Pandegiling','031-5674380')
insert into TbPelanggan values('Kent Tanuwijaya','Dinoyo','08175135582')
insert into TbPelanggan values('Marissa Clara','Dukuh Pakis','082232130065')
insert into TbPelanggan values('Oktaviani Sherly Diaz','Pakuwon City Regency','083849492993')
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
/****** ======================================================================================== ******/
insert into HJual Values('J00001', '6/9/2017', 10000, 'Toko Maju Jaya','admin')
insert into DJUal Values('J00001', 'PE001', 'Pepsodent Kecil', 'Buah', 2500, 2, 0, 5000)
insert into DJUal Values('J00001', 'PE002', 'Pepsodent Sedang', 'Buah', 5000, 1, 0, 5000)
insert into TbPembayaran Values('J00001', '6/9/2017', 10000)
update TbBarang set stok=stok-2 where KodeBarang='PE001'
update TbBarang set stok=stok-1 where KodeBarang='PE002'
insert into HJual Values('J00002', '6/10/2017', 15000, 'Toko Maju Mundur', 'admin')
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
/****** ======================================================================================== ******/
insert into HReturTerima values('RT00001','T00005','6/20/2017','admin')
insert into DReturTerima values('RT00001','TE001','Teh Pucuk Harum','Botol',100)
insert into DReturTerima values('RT00001','YO001','You C 1000','Botol',100)
update TbBarang set stok=stok-100 where KodeBarang='TE001'
update TbBarang set stok=stok-100 where KodeBarang='YO001'
insert into HReturTerima values('RT00002','T00007','6/25/2017','admin')
insert into DReturTerima values('RT00002','PE001','Pepsodent Kecil', 'Buah', 50)
update TbBarang set stok=stok-50 where KodeBarang='PE001'
/****** ======================================================================================== ******/
insert into HReturJual values('RJ00001','T00007','6/15/2017','admin')
insert into DReturJual values('RJ00001','RO001', 'Rokok Inter', 'Bungkus', 13000, 2, 0, 26000)
update TbBarang set stok=stok+2 where KodeBarang='RO001'
/****** ======================================================================================== ******/