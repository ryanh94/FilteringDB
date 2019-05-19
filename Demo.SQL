USE [master]
GO

/****** Object:  Database [Demo] ******/
CREATE DATABASE [Demo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Demo', FILENAME = N'C:\Dev\Demo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Demo_log', FILENAME = N'C:\Dev\Demo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [Demo] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Demo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Demo] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Demo] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Demo] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Demo] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Demo] SET ARITHABORT OFF 
GO

ALTER DATABASE [Demo] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Demo] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Demo] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Demo] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Demo] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Demo] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Demo] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Demo] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Demo] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Demo] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Demo] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Demo] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Demo] SET  MULTI_USER 
GO

ALTER DATABASE [Demo] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Demo] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Demo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Demo] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Demo] SET QUERY_STORE = OFF
GO

USE [Demo]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [Demo] SET  READ_WRITE 
GO

USE [Demo]
GO

CREATE SCHEMA [Data]
GO

/****** Object:  Table [Data].[Samples1] ******/
CREATE TABLE [Data].[Samples1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](40) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [Data].[Samples2] ******/
CREATE TABLE [Data].[Samples2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](40) NOT NULL
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [Data].[Samples1] ON 
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (1, N'#ef78f8')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (2, N'#709ca4')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (3, N'#a6d21f')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (4, N'#b8bb49')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (5, N'#1b4902')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (6, N'#bf278f')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (7, N'#d2892b')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (8, N'#3f6283')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (9, N'#221924')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (10, N'#0b7e48')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (11, N'#8a8e43')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (12, N'#7857f0')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (13, N'#ae6cdb')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (14, N'#2f71ab')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (15, N'#ea8d42')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (16, N'#6d0d02')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (17, N'#b15d4a')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (18, N'#bfccc3')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (19, N'#d045a8')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (20, N'#87c58f')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (21, N'#c1e42d')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (22, N'#9e9a00')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (23, N'#7cccfb')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (24, N'#32fab0')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (25, N'#50903d')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (26, N'#fd584f')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (27, N'#5acb97')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (28, N'#99a8d9')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (29, N'#ef5840')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (30, N'#9c1826')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (31, N'#039604')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (32, N'#29d8cb')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (33, N'#15641f')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (34, N'#ab8c37')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (35, N'#9b3659')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (36, N'#cbb3d1')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (37, N'#3accaf')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (38, N'#2c10cd')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (39, N'#668e3c')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (40, N'#63543e')
GO
INSERT [Data].[Samples1] ([ID], [Color]) VALUES (41, N'#619b33')
GO
SET IDENTITY_INSERT [Data].[Samples1] OFF
GO

SET IDENTITY_INSERT [Data].[Samples2] ON 
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (1, N'#5acb97')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (2, N'#99a8d9')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (3, N'#ef5840')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (4, N'#9c1826')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (5, N'#039604')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (6, N'#29d8cb')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (7, N'#15641f')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (8, N'#ab8c37')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (9, N'#9b3659')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (10, N'#cbb3d1')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (11, N'#3accaf')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (12, N'#2c10cd')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (13, N'#668e3c')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (14, N'#63543e')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (15, N'#619b33')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (16, N'#ff0c6a')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (17, N'#759049')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (18, N'#0fb822')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (19, N'#3dab22')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (20, N'#5cd735')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (21, N'#a83adb')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (22, N'#9ea888')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (23, N'#3ad8f3')
GO
INSERT [Data].[Samples2] ([ID], [Color]) VALUES (24, N'#280639')
GO
SET IDENTITY_INSERT [Data].[Samples2] OFF
GO
