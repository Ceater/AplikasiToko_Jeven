USE [DatabaseToko]
GO
/****** Object:  Table [dbo].[DJual]    Script Date: 7/7/2017 8:48:17 AM ******/
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
	[Diskon] [varchar](10) NOT NULL,
	[Subtotal] [int] NOT NULL,
 CONSTRAINT [PK_DJual] PRIMARY KEY CLUSTERED 
(
	[NoDJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DReturTerima]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[DTerima]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[HJual]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[HReturTerima]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[HTerima]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[TbBarang]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[TbPelanggan]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[TbPembayaran]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[TbSatuan]    Script Date: 7/7/2017 8:48:17 AM ******/
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
/****** Object:  Table [dbo].[TbStaff]    Script Date: 7/7/2017 8:48:17 AM ******/
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
