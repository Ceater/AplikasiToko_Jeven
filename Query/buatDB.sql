USE [DatabaseToko]
GO
/****** Object:  Table [dbo].[DBeli]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DBeli](
	[NoDBeli] [varchar](10) NOT NULL,
	[NoNotaBeli] [varchar](10) NOT NULL,
	[IDBarang] [varchar](max) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Subtotal] [int] NOT NULL,
 CONSTRAINT [PK_DBeli] PRIMARY KEY CLUSTERED 
(
	[NoDBeli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DJual]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DJual](
	[NoDJual] [varchar](10) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[IDBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](10) NOT NULL,
	[HargaSatuan] [varchar](10) NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Subtotal] [int] NOT NULL,
 CONSTRAINT [PK_DJual] PRIMARY KEY CLUSTERED 
(
	[NoDJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DReturBeli]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DReturBeli](
	[No] [varchar](10) NOT NULL,
	[IDReturBeli] [varchar](10) NOT NULL,
	[KodeBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](10) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Subtotal] [int] NOT NULL,
 CONSTRAINT [PK_DReturBeli] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DReturJual]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DReturJual](
	[No] [varchar](10) NOT NULL,
	[IDReturJual] [varchar](10) NOT NULL,
	[KodeBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[Jumlah] [int] NOT NULL,
	[Subtotal] [int] NOT NULL,
 CONSTRAINT [PK_DReturJual] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSatuan]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSatuan](
	[NoDSatuan] [int] IDENTITY(1,1) NOT NULL,
	[KodeBarang] [varchar](5) NOT NULL,
	[KodeSatuan] [varchar](5) NOT NULL,
	[JumlahIsiBarang] [varchar](5) NOT NULL,
 CONSTRAINT [PK_DSatuan] PRIMARY KEY CLUSTERED 
(
	[NoDSatuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HBeli]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HBeli](
	[NoNotaBeli] [varchar](10) NOT NULL,
	[TglNota] [date] NOT NULL,
	[GrandTotal] [int] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HBeli] PRIMARY KEY CLUSTERED 
(
	[NoNotaBeli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HJual]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HJual](
	[NoNotaJual] [varchar](10) NOT NULL,
	[TglNota] [date] NOT NULL,
	[GrandTotal] [int] NOT NULL,
	[IDStaff] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HJual] PRIMARY KEY CLUSTERED 
(
	[NoNotaJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HReturBeli]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HReturBeli](
	[IDReturBeli] [varchar](10) NOT NULL,
	[TglReturBeli] [date] NOT NULL,
	[NoNotaBeli] [varchar](10) NOT NULL,
	[TotalpengembalianUang] [int] NOT NULL,
 CONSTRAINT [PK_ReturBeli] PRIMARY KEY CLUSTERED 
(
	[IDReturBeli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HReturJual]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HReturJual](
	[IDReturJual] [varchar](10) NOT NULL,
	[TglReturJual] [date] NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[TotalPengembalianUang] [int] NOT NULL,
 CONSTRAINT [PK_ReturJual] PRIMARY KEY CLUSTERED 
(
	[IDReturJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbBarang]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbBarang](
	[KodeBarang] [varchar](10) NOT NULL,
	[NamaBarang] [varchar](max) NOT NULL,
	[Stok] [int] NOT NULL,
	[SatuanBarang] [varchar](10) NOT NULL,
	[HargaSatuan] [int] NOT NULL,
	[StokPengingat] [int] NOT NULL,
 CONSTRAINT [PK_TbBarang] PRIMARY KEY CLUSTERED 
(
	[KodeBarang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbKontakSupplier]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbKontakSupplier](
	[IDKontakSupplier] [varchar](10) NOT NULL,
	[IDSupplier] [varchar](10) NOT NULL,
	[NamaSales] [varchar](max) NOT NULL,
	[TlpSales] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TbKontakSupplier] PRIMARY KEY CLUSTERED 
(
	[IDKontakSupplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbPelanggan]    Script Date: 6/9/2017 5:48:38 PM ******/
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
/****** Object:  Table [dbo].[TbPembayaran]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbPembayaran](
	[NoNotaPembayaran] [varchar](10) NOT NULL,
	[NoNotaJual] [varchar](10) NOT NULL,
	[UangBayar] [int] NOT NULL,
 CONSTRAINT [PK_TbPembayaran] PRIMARY KEY CLUSTERED 
(
	[NoNotaPembayaran] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbSatuan]    Script Date: 6/9/2017 5:48:38 PM ******/
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
/****** Object:  Table [dbo].[TbStaff]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbStaff](
	[IDstaff] [varchar](10) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[NamaStaff] [varchar](max) NOT NULL,
	[Alamat] [varchar](max) NOT NULL,
	[NoTlp] [varchar](max) NULL,
	[HakAkses] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TbStaff] PRIMARY KEY CLUSTERED 
(
	[IDstaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbSupplier]    Script Date: 6/9/2017 5:48:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbSupplier](
	[IDSupplier] [varchar](10) NOT NULL,
	[NamaSupplier] [varchar](max) NOT NULL,
	[AlamatSupplier] [varchar](max) NOT NULL,
 CONSTRAINT [PK_TbSupplier] PRIMARY KEY CLUSTERED 
(
	[IDSupplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
