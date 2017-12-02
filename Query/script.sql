USE [master]
GO
/****** Object:  Database [DatabaseToko]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[DJual]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[DPembelian]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[DReturJual]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[DReturTerima]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[DTerima]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[HJual]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[HPembelian]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[HReturJual]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[HReturTerima]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[HTerima]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[TbBarang]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[TbLabaRugi]    Script Date: 12/3/2017 1:41:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbLabaRugi](
	[No] [int] IDENTITY(1,1) NOT NULL,
	[PersediaanAwal] [int] NOT NULL,
	[TglPersediaan] [date] NOT NULL,
 CONSTRAINT [PK_TbLabaRugi] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPelanggan]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[TbPembayaran]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[TbSatuan]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  Table [dbo].[TbStaff]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  View [dbo].[Pembelian]    Script Date: 12/3/2017 1:41:36 AM ******/
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
/****** Object:  View [dbo].[TotalPendapatan]    Script Date: 12/3/2017 1:41:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[TotalPendapatan] as
select (select count(NoNotaJual) from HJual) as NoNotaJual, (select sum(GrandTotal) from HJual) as GrandTotal, (select sum(UangBayar) from TbPembayaran) as TotalPembayaran
GO
/****** Object:  StoredProcedure [dbo].[AutoComplete]    Script Date: 12/3/2017 1:41:36 AM ******/
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
delete TbLabaRugi
DBCC CHECKIDENT ('DReturTerima', RESEED, 0);
DBCC CHECKIDENT ('DReturJual', RESEED, 0);
DBCC CHECKIDENT ('DJual', RESEED, 0);
DBCC CHECKIDENT ('DTerima', RESEED, 0);
DBCC CHECKIDENT ('TbPelanggan', RESEED, 0);
DBCC CHECKIDENT ('TbPembayaran', RESEED, 0);
DBCC CHECKIDENT ('TbLabaRugi', RESEED, 0);
GO
USE [master]
GO
ALTER DATABASE [DatabaseToko] SET  READ_WRITE 
GO
