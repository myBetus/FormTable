USE [master]
GO
/****** Object:  Database [FormTableDB]    Script Date: 27/04/2023 22:29:41 ******/
CREATE DATABASE [FormTableDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FormTableDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FormTableDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FormTableDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FormTableDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FormTableDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FormTableDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FormTableDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FormTableDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FormTableDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FormTableDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FormTableDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FormTableDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FormTableDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FormTableDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FormTableDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FormTableDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FormTableDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FormTableDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FormTableDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FormTableDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FormTableDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FormTableDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FormTableDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FormTableDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FormTableDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FormTableDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FormTableDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FormTableDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FormTableDB] SET RECOVERY FULL 
GO
ALTER DATABASE [FormTableDB] SET  MULTI_USER 
GO
ALTER DATABASE [FormTableDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FormTableDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FormTableDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FormTableDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FormTableDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FormTableDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FormTableDB', N'ON'
GO
ALTER DATABASE [FormTableDB] SET QUERY_STORE = OFF
GO
USE [FormTableDB]
GO
/****** Object:  Table [dbo].[DersDT]    Script Date: 27/04/2023 22:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DersDT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DersAdi] [nvarchar](50) NOT NULL,
	[OlusturulmaTarihi] [datetime] NOT NULL,
	[OlusturanKisiID] [uniqueidentifier] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
	[GuncelleyenKisiID] [uniqueidentifier] NULL,
	[SilinmeTarihi] [datetime] NULL,
	[SilenKisiID] [uniqueidentifier] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_S] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormDT]    Script Date: 27/04/2023 22:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormDT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SinifNoID] [int] NOT NULL,
	[DersID] [int] NOT NULL,
	[Ad] [nvarchar](50) NULL,
	[SoyAd] [nvarchar](50) NULL,
	[SinifNo] [nvarchar](50) NULL,
	[DersAdi] [nvarchar](50) NULL,
	[Konu] [nvarchar](150) NULL,
	[Mesaj] [nvarchar](max) NULL,
	[Resim] [nvarchar](max) NULL,
	[OlusturulmaTarihi] [datetime] NOT NULL,
	[OlusturanKisiID] [uniqueidentifier] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
	[GuncelleyenKisiID] [uniqueidentifier] NULL,
	[SilinmeTarihi] [datetime] NULL,
	[SilenKisiID] [uniqueidentifier] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_FF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IzinsizGirisDT]    Script Date: 27/04/2023 22:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IzinsizGirisDT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GirenKisi] [uniqueidentifier] NOT NULL,
	[GirmeTarihi] [datetime] NOT NULL,
	[GirdigiSayfa] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_IzinsizGirisDT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KullanicilarDT]    Script Date: 27/04/2023 22:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullanicilarDT](
	[ID] [uniqueidentifier] NOT NULL,
	[AdSoyad] [nvarchar](200) NULL,
	[Email] [nvarchar](500) NULL,
	[KullaniciAdi] [nvarchar](100) NOT NULL,
	[Sifre] [nvarchar](100) NOT NULL,
	[Resim] [nvarchar](max) NULL,
	[OlusturulmaTarihi] [datetime] NOT NULL,
	[OlusturanKisiID] [uniqueidentifier] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
	[GuncelleyenKisiID] [uniqueidentifier] NULL,
	[SilinmeTarihi] [datetime] NULL,
	[SilenKisiID] [uniqueidentifier] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_KullanicilarDT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinifNoDT]    Script Date: 27/04/2023 22:29:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinifNoDT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SinifNo] [nvarchar](50) NOT NULL,
	[OlusturulmaTarihi] [datetime] NOT NULL,
	[OlusturanKisiID] [uniqueidentifier] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
	[GuncelleyenKisiID] [uniqueidentifier] NULL,
	[SilinmeTarihi] [datetime] NULL,
	[SilenKisiID] [uniqueidentifier] NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Sinifdt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DersDT] ON 

INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (1, N'Biyoloji', CAST(N'2023-04-25T12:06:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (2, N'Matematik', CAST(N'2023-04-25T12:07:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (3, N'Fizik', CAST(N'2023-04-25T12:08:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (4, N'Kimya', CAST(N'2023-04-25T12:08:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (5, N'Edebiyat', CAST(N'2023-04-25T12:09:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (6, N'İngilizce', CAST(N'2023-04-25T12:09:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (7, N'Tarih', CAST(N'2023-04-25T12:09:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (8, N'Coğrafya', CAST(N'2023-04-25T12:09:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[DersDT] ([ID], [DersAdi], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (12, N'Diğer', CAST(N'2023-04-25T12:08:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[DersDT] OFF
GO
SET IDENTITY_INSERT [dbo].[FormDT] ON 

INSERT [dbo].[FormDT] ([ID], [SinifNoID], [DersID], [Ad], [SoyAd], [SinifNo], [DersAdi], [Konu], [Mesaj], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (1, 1, 1, N'betül', N'avcı', NULL, NULL, N'genetik', N'cevap??', N'/Resim/Soru/ii3ojzvbi2x.jpg', CAST(N'2023-04-27T18:10:02.237' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[FormDT] ([ID], [SinifNoID], [DersID], [Ad], [SoyAd], [SinifNo], [DersAdi], [Konu], [Mesaj], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (2, 3, 2, N'test', N'deneme', NULL, NULL, N'trigonometri', N'2.Sorunun cevabı nedir?', N'/Resim/Soru/zq3xytrsdwq.jpg', CAST(N'2023-04-27T18:51:01.863' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[FormDT] ([ID], [SinifNoID], [DersID], [Ad], [SoyAd], [SinifNo], [DersAdi], [Konu], [Mesaj], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (3, 4, 8, N'deneme', N'deneme', NULL, NULL, N'yer şekilleri', N'Yardımcı olur musunuz?', N'/Resim/Soru/axqyopm4w4q.jpg', CAST(N'2023-04-27T19:07:36.157' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[FormDT] ([ID], [SinifNoID], [DersID], [Ad], [SoyAd], [SinifNo], [DersAdi], [Konu], [Mesaj], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (4, 1, 3, N'Lorem', N'Ipsum', NULL, NULL, N'Basınç', N'Açıklar mısınız?', N'/Resim/Soru/c1ty3gwrw11.jpg', CAST(N'2023-04-27T21:57:46.107' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[FormDT] OFF
GO
INSERT [dbo].[KullanicilarDT] ([ID], [AdSoyad], [Email], [KullaniciAdi], [Sifre], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (N'7ccd6589-99bc-415a-ae33-217fdec981d6', N'Betül Avcı', N'betulavci41@hotmail.com', N'betul', N'betul', NULL, CAST(N'2023-04-26T09:45:15.147' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[KullanicilarDT] ([ID], [AdSoyad], [Email], [KullaniciAdi], [Sifre], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (N'b32ddfb6-28eb-4d78-92f3-52946738b2c4', N'deneme', NULL, N'test', N'test', NULL, CAST(N'2023-04-27T12:01:45.857' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[KullanicilarDT] ([ID], [AdSoyad], [Email], [KullaniciAdi], [Sifre], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (N'6edf8757-b73e-4a72-97cb-5a4ebb2e84e9', N'Test Kullanıcısı', N'lorem@hotmail.com', N'ipsum', N'lorem', N'/Resim/Kullanici/m2gkjqwpvw1.jpg', CAST(N'2023-04-27T13:36:50.743' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[KullanicilarDT] ([ID], [AdSoyad], [Email], [KullaniciAdi], [Sifre], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (N'4d7abc10-2a97-4eff-b06b-65c7092387c9', N'deneme', NULL, N'test', N'deneme', N'/Resim/Kullanici/bahegf0zabu.jpg', CAST(N'2023-04-27T13:31:20.673' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[KullanicilarDT] ([ID], [AdSoyad], [Email], [KullaniciAdi], [Sifre], [Resim], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (N'fb6e50fb-9b3b-4dfe-b9a1-c9a2478f403c', N'Betül Avcı', N'betul', N'betul', N'betul', N'/Resim/Kullanici/2xxm4tcxbcq.jpg', CAST(N'2023-04-27T13:33:56.793' AS DateTime), N'7ccd6589-99bc-415a-ae33-217fdec981d6', NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[SinifNoDT] ON 

INSERT [dbo].[SinifNoDT] ([ID], [SinifNo], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (1, N'9', CAST(N'2023-04-25T12:06:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[SinifNoDT] ([ID], [SinifNo], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (2, N'10', CAST(N'2023-04-25T12:07:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[SinifNoDT] ([ID], [SinifNo], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (3, N'11', CAST(N'2023-04-25T12:08:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[SinifNoDT] ([ID], [SinifNo], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (4, N'12', CAST(N'2023-04-25T12:08:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[SinifNoDT] ([ID], [SinifNo], [OlusturulmaTarihi], [OlusturanKisiID], [GuncellenmeTarihi], [GuncelleyenKisiID], [SilinmeTarihi], [SilenKisiID], [AktifMi]) VALUES (5, N'Diğer', CAST(N'2023-04-25T12:09:26.310' AS DateTime), N'45dfbae5-8fd4-4360-b345-b4809e93d149', NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[SinifNoDT] OFF
GO
ALTER TABLE [dbo].[IzinsizGirisDT] ADD  CONSTRAINT [DF_IzinsizGirisDT_GirmeTarihi]  DEFAULT (getdate()) FOR [GirmeTarihi]
GO
ALTER TABLE [dbo].[FormDT]  WITH CHECK ADD  CONSTRAINT [FK_FormDT_DersDT] FOREIGN KEY([DersID])
REFERENCES [dbo].[DersDT] ([ID])
GO
ALTER TABLE [dbo].[FormDT] CHECK CONSTRAINT [FK_FormDT_DersDT]
GO
ALTER TABLE [dbo].[FormDT]  WITH CHECK ADD  CONSTRAINT [FK_FormDT_SinifNoDT] FOREIGN KEY([SinifNoID])
REFERENCES [dbo].[SinifNoDT] ([ID])
GO
ALTER TABLE [dbo].[FormDT] CHECK CONSTRAINT [FK_FormDT_SinifNoDT]
GO
USE [master]
GO
ALTER DATABASE [FormTableDB] SET  READ_WRITE 
GO
