delete HReturTerima
delete DReturTerima
delete HReturJual
delete DReturJual
DBCC CHECKIDENT ('DReturTerima', RESEED, 0);
DBCC CHECKIDENT ('DReturJual', RESEED, 0);
/****** ============================================== ******/
insert into HReturTerima values('RT00001','T00005','6/20/2017','admin')
insert into DReturTerima values('RT00001','TE001','Teh Pucuk Harum','Botol',100)
insert into DReturTerima values('RT00001','YO001','You C 1000','Botol',100)
update TbBarang set stok=stok-100 where KodeBarang='TE001'
update TbBarang set stok=stok-100 where KodeBarang='YO001'
insert into HReturTerima values('RT00002','T00007','6/25/2017','admin')
insert into DReturTerima values('RT00002','PE001','Pepsodent Kecil', 'Buah', 50)
update TbBarang set stok=stok-50 where KodeBarang='PE001'
/****** ============================================== ******/
insert into HReturJual values('RJ00001','T00007','6/15/2017','admin')
insert into DReturJual values('RJ00001','RO001', 'Rokok Inter', 'Bungkus', 13000, 2, 0, 26000)
update TbBarang set stok=stok+2 where KodeBarang='RO001'