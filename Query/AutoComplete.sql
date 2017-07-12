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
insert into TbStaff values('admin','admin','Johan Jusianto','Kupang Panjaan','08175135582','1111111111111111')
insert into TbStaff values('kasir','kasir','Chintya Marcheline','Diponegoro','081081081081','1111111111111111')
/****** ======================================================================================== ******/
insert into TbPelanggan values('Johan Jusianto','Kupang Panjaan','031-5614844')
insert into TbPelanggan values('Willy Budiman','Pandegiling','031-5674380')
insert into TbPelanggan values('Kent Tanuwijaya','Dinoyo','08175135582')
insert into TbPelanggan values('Marissa Clara','Dukuh Pakis','082232130065')
insert into TbPelanggan values('Oktaviani Sherly Diaz','Pakuwon City Regency','083849492993')