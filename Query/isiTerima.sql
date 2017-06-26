delete HTerima
delete DTerima
insert into HTerima values('T001','6/14/2017','admin')
insert into DTerima Values('T001', 'PE001', 'Pepsodent Kecil', 'Buah', 100)
insert into DTerima Values('T001', 'PE002', 'Pepsodent Sedang', 'Buah', 100)
insert into DTerima Values('T001', 'PE003', 'Pepsodent Besar', 'Buah', 100)
update TbBarang set stok=stok+100 where KodeBarang='PE001'
update TbBarang set stok=stok+100 where KodeBarang='PE002'
update TbBarang set stok=stok+100 where KodeBarang='PE003'
insert into HTerima values('T002','6/17/2017','admin')
insert into DTerima Values('T002', 'SA001', 'Sabun Lifeboy', 'Batang', 100)
insert into DTerima Values('T002', 'SA002', 'Sabun Lux', 'Batang', 100)
update TbBarang set stok=stok+100 where KodeBarang='SA001'
update TbBarang set stok=stok+100 where KodeBarang='SA002'
insert into HTerima values('T003','6/17/2017','admin')
insert into DTerima Values('T003', 'GE001', 'Gery Chocolatos', 'Bungkus', 100)
insert into DTerima Values('T003', 'GE002', 'Gery Chocolatos', 'Dus', 100)
update TbBarang set stok=stok+100 where KodeBarang='GE001'
update TbBarang set stok=stok+100 where KodeBarang='GE002'
insert into HTerima values('T004','6/17/2017','admin')
insert into DTerima Values('T004', 'AQ001', 'Aqua Gelas', 'Buah', 100)
insert into DTerima Values('T004', 'AQ002', 'Aqua Sedang', 'Botol', 100)
insert into DTerima Values('T004', 'AQ003', 'Aqua 1.5L', 'Botol', 100)
update TbBarang set stok=stok+100 where KodeBarang='AQ001'
update TbBarang set stok=stok+100 where KodeBarang='AQ002'
update TbBarang set stok=stok+100 where KodeBarang='AQ003'
insert into HTerima values('T005','6/18/2017','admin')
insert into DTerima Values('T005', 'TE001', 'Teh Pucuk Harum', 'Botol', 100)
insert into DTerima Values('T005', 'YO001', 'You C 1000', 'Botol', 100)
update TbBarang set stok=stok+100 where KodeBarang='TE001'
update TbBarang set stok=stok+100 where KodeBarang='YO001'
insert into HTerima values('T006','6/18/2017','admin')
insert into DTerima Values('T006', 'RO001', 'Rokok Inter', 'Bungkus', 100)
insert into DTerima Values('T006', 'RO002', 'Rokok Surya', 'Bungkus', 100)
insert into DTerima Values('T006', 'RO003', 'Rokok UMild', 'Bungkus', 100)
update TbBarang set stok=stok+100 where KodeBarang='RO001'
update TbBarang set stok=stok+100 where KodeBarang='RO002'
update TbBarang set stok=stok+100 where KodeBarang='RO003'