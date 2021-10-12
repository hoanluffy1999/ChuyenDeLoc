﻿USE [master]
GO
/****** Object:  Database [QLCayCanh]    Script Date: 10/5/2021 12:32:36 AM ******/
CREATE DATABASE [QLCayCanh]

ALTER DATABASE [QLCayCanh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLCayCanh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLCayCanh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLCayCanh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLCayCanh] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLCayCanh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLCayCanh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLCayCanh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLCayCanh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLCayCanh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLCayCanh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLCayCanh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLCayCanh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLCayCanh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLCayCanh] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLCayCanh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLCayCanh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLCayCanh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLCayCanh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLCayCanh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLCayCanh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLCayCanh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLCayCanh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLCayCanh] SET  MULTI_USER 
GO
ALTER DATABASE [QLCayCanh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLCayCanh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLCayCanh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLCayCanh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLCayCanh] SET DELAYED_DURABILITY = DISABLED 
GO
GO
ALTER DATABASE [QLCayCanh] SET QUERY_STORE = OFF
GO
USE [QLCayCanh]
GO
/****** Object:  Table [dbo].[ChiTiepPhieuNhap]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiepPhieuNhap](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuNhap] [int] NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [bigint] NULL,
 CONSTRAINT [PK_ChiTiepPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTiepPhieuXuat]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTiepPhieuXuat](
	[Ma] [int] NOT NULL,
	[MaSP] [int] NULL,
	[GiaXuat] [bigint] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTiepPhieuXuat] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nchar](10) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](250) NULL,
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[NgaySinh] [date] NOT NULL,
	[SDT] [nchar](10) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanLoai]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanLoai](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](250) NULL,
	[MoTa] [nvarchar](500) NULL,
 CONSTRAINT [PK_PhanLoai] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[NgayNhap] [date] NULL,
	[MaNCC] [int] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuat](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[MaSP] [int] NULL,
	[MaNV] [int] NULL,
	[NgayXuat] [date] NULL,
 CONSTRAINT [PK_PhieuXuat] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 10/5/2021 12:32:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[Ma] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](250) NULL,
	[MoTa] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[MaPhanLoai] [int] NOT NULL,
	[HinhAnh] [nvarchar](200) NULL,
	[ChieuCao] [int] NULL,
	[ChieuRong] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTiepPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiepPhieuNhap_PhieuNhap] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([Ma])
GO
ALTER TABLE [dbo].[ChiTiepPhieuNhap] CHECK CONSTRAINT [FK_ChiTiepPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTiepPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTiepPhieuNhap_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([Ma])
GO
ALTER TABLE [dbo].[ChiTiepPhieuNhap] CHECK CONSTRAINT [FK_ChiTiepPhieuNhap_SanPham]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap1] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([Ma])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap1]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([Ma])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_PhanLoai] FOREIGN KEY([MaPhanLoai])
REFERENCES [dbo].[PhanLoai] ([Ma])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_PhanLoai]
GO
USE [master]
GO
ALTER DATABASE [QLCayCanh] SET  READ_WRITE 
GO
