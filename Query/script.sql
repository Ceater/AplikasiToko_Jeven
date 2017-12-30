USE [DatabaseToko]
GO
/****** Object:  Table [dbo].[HTerima]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HTerima](
	[NoNotaTerima] [varchar](10) NOT NULL,
	[TglNota] [date] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoNotaTerima] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HReturTerima]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HReturTerima](
	[NoNotaReturTerima] [varchar](10) NOT NULL,
	[NoNotaTerima] [varchar](10) NOT NULL,
	[TglReturTerima] [date] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoNotaReturTerima] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HReturJual]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HReturJual](
	[NoNotaReturJual] [varchar](10) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[TglReturJual] [date] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoNotaReturJual] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HPembelian]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HPembelian](
	[NoPembelian] [int] NOT NULL,
	[NoNotaTerima] [varchar](10) NOT NULL,
	[GrandTotal] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoPembelian] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HJual]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HJual](
	[NoNotaJual] [varchar](10) NOT NULL,
	[TglNota] [date] NOT NULL,
	[GrandTotal] [float] NOT NULL,
	[NamaPelanggan] [varchar](max) NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HJual] PRIMARY KEY CLUSTERED 
(
	[NoNotaJual] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DTerima]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DTerima](
	[NoTerima] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaTerima] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[Jumlah] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoTerima] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DReturTerima]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DReturTerima](
	[NoDReturTerima] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaReturTerima] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[Jumlah] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoDReturTerima] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DReturJual]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DReturJual](
	[NoDReturJual] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaReturJual] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [float] NOT NULL,
	[Diskon] [varchar](10) NOT NULL,
	[Subtotal] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoDReturJual] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DPembelian]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DPembelian](
	[NoDPembelian] [int] IDENTITY(1,1) NOT NULL,
	[NoPembelian] [int] NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](255) NOT NULL,
	[Satuan] [varchar](255) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [float] NOT NULL,
	[Subtotal] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoDPembelian] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DJual]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DJual](
	[NoDJual] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [float] NOT NULL,
	[Diskon] [float] NOT NULL,
	[Subtotal] [float] NOT NULL,
 CONSTRAINT [PK_DJual] PRIMARY KEY CLUSTERED 
(
	[NoDJual] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TbStaff]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TbStaff](
	[IDstaff] [varchar](10) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[NamaStaff] [varchar](max) NOT NULL,
	[Alamat] [varchar](max) NOT NULL,
	[NoTlp] [varchar](max) NOT NULL,
	[HakAkses] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TbStaff] PRIMARY KEY CLUSTERED 
(
	[IDstaff] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TbSatuan]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TbSatuan](
	[KodeSatuan] [varchar](10) NOT NULL,
	[NamaSatuan] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TbSatuan] PRIMARY KEY CLUSTERED 
(
	[KodeSatuan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TbPembayaran]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TbPembayaran](
	[NoNotaPembayaran] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[TglBayar] [date] NOT NULL,
	[UangBayar] [int] NOT NULL,
 CONSTRAINT [PK_TbPembayaran] PRIMARY KEY CLUSTERED 
(
	[NoNotaPembayaran] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TbPelanggan]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TbPelanggan](
	[NoPelanggan] [int] IDENTITY(1,1) NOT NULL,
	[NamaPelanggan] [varchar](max) NOT NULL,
	[TlpPelanggan] [varchar](max) NOT NULL,
	[AlamatPelanggan] [varchar](max) NOT NULL,
	[TipePelanggan] [varchar](255) NULL,
 CONSTRAINT [PK_TbPelanggan] PRIMARY KEY CLUSTERED 
(
	[NoPelanggan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TbLabaRugi]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbLabaRugi](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[PersediaanAwal] [float] NOT NULL,
	[TglPersediaan] [date] NOT NULL,
 CONSTRAINT [PK_TbLabaRugi] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbBarang]    Script Date: 12/30/2017 21:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TbBarang](
	[KodeBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Stok] [float] NULL,
	[SatuanBarang] [varchar](10) NOT NULL,
	[HargaNormal] [float] NOT NULL,
	[HargaToko] [float] NOT NULL,
	[HargaSales] [float] NOT NULL,
	[StokPengingat] [float] NOT NULL,
 CONSTRAINT [PK_TbBarang] PRIMARY KEY CLUSTERED 
(
	[KodeBarang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[TotalPendapatan]    Script Date: 12/30/2017 21:49:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[TotalPendapatan] as
select (select count(NoNotaJual) from HJual) as NoNotaJual, (select sum(GrandTotal) from HJual) as GrandTotal, (select sum(UangBayar) from TbPembayaran) as TotalPembayaran
GO
/****** Object:  View [dbo].[Pembelian]    Script Date: 12/30/2017 21:49:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Pembelian]
As
select Ht.NoNotaTerima, DT.IDBarang, DT.NamaBarang, DT.Satuan, DT.Jumlah from HTerima HT, DTerima DT where HT.NoNotaTerima = DT.NoNotaTerima
except
select HT.NoNotaTerima, DT.IDBarang, DT.NamaBarang, DT.Satuan, DT.Jumlah from HTerima HT, DTerima DT, HReturTerima HTR where HT.NoNotaTerima = HTR.NoNotaTerima and HT.NoNotaTerima = DT.NoNotaTerima
UNION
select * from 
(select HT.NoNotaTerima, DT.IDBarang, DT.NamaBarang, DT.Satuan, DT.Jumlah from HTerima HT, DTerima DT, HReturTerima HTR where HT.NoNotaTerima = HTR.NoNotaTerima and HT.NoNotaTerima = DT.NoNOtaTerima
Except
select HTR.NoNotaTerima, DTR.IdBarang, DTR.NamaBarang, DTR.Satuan, DTR.Jumlah from HReturTerima HTR, DReturTerima DTR where HTR.NoNotaReturTerima = DTR.NoNotaReturTerima) DR;
GO
/****** Object:  StoredProcedure [dbo].[StartData]    Script Date: 12/30/2017 21:49:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StartData]
AS
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
GO
