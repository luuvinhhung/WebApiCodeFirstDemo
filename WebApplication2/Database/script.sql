USE [master]
GO
/****** Object:  Database [Sample]    Script Date: 15-05-2018 11:59:27 AM ******/
CREATE DATABASE [Sample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sample', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Sample.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Sample_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Sample_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Sample] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sample] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sample] SET RECOVERY FULL 
GO
ALTER DATABASE [Sample] SET  MULTI_USER 
GO
ALTER DATABASE [Sample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sample', N'ON'
GO
USE [Sample]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 15-05-2018 11:59:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[malop] [nvarchar](max) NULL,
	[tenlop] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinhvien]    Script Date: 15-05-2018 11:59:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinhvien](
	[HoTen] [nvarchar](max) NULL,
	[NTSN] [datetime] NULL,
	[DiaChi] [nvarchar](max) NULL,
	[mssv] [int] IDENTITY(1,1) NOT NULL,
	[lop_id] [int] NOT NULL,
 CONSTRAINT [PK_Sinhvien] PRIMARY KEY CLUSTERED 
(
	[mssv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Sinhvien]  WITH CHECK ADD  CONSTRAINT [FK_Sinhvien_Lop] FOREIGN KEY([lop_id])
REFERENCES [dbo].[Lop] ([id])
GO
ALTER TABLE [dbo].[Sinhvien] CHECK CONSTRAINT [FK_Sinhvien_Lop]
GO
USE [master]
GO
ALTER DATABASE [Sample] SET  READ_WRITE 
GO
