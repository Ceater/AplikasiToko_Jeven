delete HReturTerima
delete DReturTerima
DBCC CHECKIDENT ('DReturTerima', RESEED, 0);
insert into HReturTerima values('RT001','T001','6/20/2017','admin')
insert into DReturTerima values('RT001','PE001','Pepsodent Kecil','Buah','100')
insert into DReturTerima values('RT001','PE002','Pepsodent Sedang','Buah','100')
update TbBarang set stok=stok-100 where KodeBarang='PE001'
update TbBarang set stok=stok-100 where KodeBarang='PE002'
/****** ============================================== ******/