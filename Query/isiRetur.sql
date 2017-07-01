delete HReturTerima
delete DReturTerima
DBCC CHECKIDENT ('DReturTerima', RESEED, 0);
insert into HReturTerima values('RT00001','T00005','6/20/2017','admin')
insert into DReturTerima values('RT00001','TE001','Teh Pucuk Harum','Botol','100')
insert into DReturTerima values('RT00001','YO001','You C 1000','Botol','100')
update TbBarang set stok=stok-100 where KodeBarang='TE001'
update TbBarang set stok=stok-100 where KodeBarang='YO001'
/****** ============================================== ******/