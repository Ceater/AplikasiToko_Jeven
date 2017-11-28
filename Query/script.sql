USE [master]
GO
/****** Object:  Database [DatabaseToko]    Script Date: 11/28/2017 8:57:39 PM ******/
CREATE DATABASE [DatabaseToko]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DatabaseToko', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DatabaseToko.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DatabaseToko_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DatabaseToko_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DatabaseToko] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DatabaseToko].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DatabaseToko] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DatabaseToko] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DatabaseToko] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DatabaseToko] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DatabaseToko] SET ARITHABORT OFF 
GO
ALTER DATABASE [DatabaseToko] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DatabaseToko] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DatabaseToko] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DatabaseToko] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DatabaseToko] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DatabaseToko] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DatabaseToko] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DatabaseToko] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DatabaseToko] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DatabaseToko] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DatabaseToko] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DatabaseToko] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DatabaseToko] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DatabaseToko] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DatabaseToko] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DatabaseToko] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DatabaseToko] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DatabaseToko] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DatabaseToko] SET  MULTI_USER 
GO
ALTER DATABASE [DatabaseToko] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DatabaseToko] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DatabaseToko] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DatabaseToko] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DatabaseToko] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DatabaseToko]
GO
/****** Object:  Table [dbo].[DJual]    Script Date: 11/28/2017 8:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DJual](
	[NoDJual] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Diskon] [int] NOT NULL,
	[Subtotal] [int] NOT NULL,
 CONSTRAINT [PK_DJual] PRIMARY KEY CLUSTERED 
(
	[NoDJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DPembelian]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DPembelian](
	[NoDPembelian] [int] IDENTITY(1,1) NOT NULL,
	[NoPembelian] [int] NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](255) NOT NULL,
	[Satuan] [varchar](255) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Subtotal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoDPembelian] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DReturJual]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DReturJual](
	[NoDReturJual] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaReturJual] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Diskon] [varchar](10) NOT NULL,
	[Subtotal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoDReturJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DReturTerima]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DReturTerima](
	[NoDReturTerima] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaReturTerima] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[Jumlah] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoDReturTerima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DTerima]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DTerima](
	[NoTerima] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaTerima] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Satuan] [varchar](max) NOT NULL,
	[Jumlah] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoTerima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HJual]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HJual](
	[NoNotaJual] [varchar](10) NOT NULL,
	[TglNota] [date] NOT NULL,
	[GrandTotal] [int] NOT NULL,
	[NamaPelanggan] [varchar](max) NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HJual] PRIMARY KEY CLUSTERED 
(
	[NoNotaJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HPembelian]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HPembelian](
	[NoPembelian] [int] NOT NULL,
	[NoNotaTerima] [varchar](10) NOT NULL,
	[GrandTotal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoPembelian] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HReturJual]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HReturJual](
	[NoNotaReturJual] [varchar](10) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[TglReturJual] [date] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoNotaReturJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HReturTerima]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HReturTerima](
	[NoNotaReturTerima] [varchar](10) NOT NULL,
	[NoNotaTerima] [varchar](10) NOT NULL,
	[TglReturTerima] [date] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoNotaReturTerima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HTerima]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HTerima](
	[NoNotaTerima] [varchar](10) NOT NULL,
	[TglNota] [date] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoNotaTerima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbBarang]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbBarang](
	[KodeBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Stok] [int] NOT NULL,
	[SatuanBarang] [varchar](10) NOT NULL,
	[HargaNormal] [int] NOT NULL,
	[HargaToko] [int] NOT NULL,
	[HargaSales] [int] NOT NULL,
	[StokPengingat] [int] NOT NULL,
 CONSTRAINT [PK_TbBarang] PRIMARY KEY CLUSTERED 
(
	[KodeBarang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPelanggan]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPelanggan](
	[NoPelanggan] [int] IDENTITY(1,1) NOT NULL,
	[NamaPelanggan] [varchar](max) NOT NULL,
	[TlpPelanggan] [varchar](max) NOT NULL,
	[AlamatPelanggan] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TbPelanggan] PRIMARY KEY CLUSTERED 
(
	[NoPelanggan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPembayaran]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPembayaran](
	[NoNotaPembayaran] [int] IDENTITY(1,1) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[TglBayar] [date] NOT NULL,
	[UangBayar] [int] NOT NULL,
 CONSTRAINT [PK_TbPembayaran] PRIMARY KEY CLUSTERED 
(
	[NoNotaPembayaran] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbSatuan]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbSatuan](
	[KodeSatuan] [varchar](10) NOT NULL,
	[NamaSatuan] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TbSatuan] PRIMARY KEY CLUSTERED 
(
	[KodeSatuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbStaff]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AutoComplete]    Script Date: 11/28/2017 8:57:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AutoComplete]
AS
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
insert into TbStaff values('admin','admin','Johan Jusianto','Kupang Panjaan','08175135582','1111111111111111111')
insert into TbStaff values('kasir','kasir','Chintya Marcheline','Diponegoro','081081081081','1111111111111111111')
/****** ======================================================================================== ******/
insert into TbPelanggan values('Johan Jusianto','Kupang Panjaan','031-5614844')
insert into TbPelanggan values('Willy Budiman','Pandegiling','031-5674380')
insert into TbPelanggan values('Kent Tanuwijaya','Dinoyo','08175135582')
insert into TbPelanggan values('Marissa Clara','Dukuh Pakis','082232130065')
insert into TbPelanggan values('Oktaviani Sherly Diaz','Pakuwon City Regency','083849492993')
RETURN 0
GO
USE [master]
GO
ALTER DATABASE [DatabaseToko] SET  READ_WRITE 
GO
