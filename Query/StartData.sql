delete TbBarang
delete TbSatuan
delete TbStaff
delete TbPelanggan
delete TbPembayaran
delete HReturTerima
delete DReturTerima
delete HReturJual
delete DReturJual
delete HPembelian
delete DPembelian
delete DJual
delete HJual
delete HTerima
delete DTerima
delete TbLabaRugi
DBCC CHECKIDENT ('TbLabaRugi', RESEED, 0);
DBCC CHECKIDENT ('DReturTerima', RESEED, 0);
DBCC CHECKIDENT ('DReturJual', RESEED, 0);
DBCC CHECKIDENT ('DJual', RESEED, 0);
DBCC CHECKIDENT ('DTerima', RESEED, 0);
DBCC CHECKIDENT ('TbPelanggan', RESEED, 0);
DBCC CHECKIDENT ('TbPembayaran', RESEED, 0);
DBCC CHECKIDENT ('DPembelian', RESEED, 0);
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
insert into TbStaff values('admin','admin','-','-','-','11111111111111111111')