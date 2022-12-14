USE [master]
GO
/****** Object:  Database [ShippingDb]    Script Date: 12/11/2022 1:48:23 AM ******/
CREATE DATABASE [ShippingDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShippingDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShippingDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShippingDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShippingDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShippingDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShippingDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShippingDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShippingDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShippingDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShippingDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShippingDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShippingDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShippingDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShippingDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShippingDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShippingDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShippingDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShippingDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShippingDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShippingDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShippingDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShippingDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShippingDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShippingDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShippingDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShippingDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShippingDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShippingDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShippingDb] SET RECOVERY FULL 
GO
ALTER DATABASE [ShippingDb] SET  MULTI_USER 
GO
ALTER DATABASE [ShippingDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShippingDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShippingDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShippingDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShippingDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShippingDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShippingDb', N'ON'
GO
ALTER DATABASE [ShippingDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShippingDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShippingDb]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 12/11/2022 1:48:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[ProviderId] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceProvider]    Script Date: 12/11/2022 1:48:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceProvider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ServiceProvider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipment]    Script Date: 12/11/2022 1:48:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Length] [int] NULL,
	[Weight] [int] NULL,
	[ServiceId] [int] NOT NULL,
	[MeasurementType] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Shipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [Name], [ProviderId]) VALUES (1, N'fedexAIR', 1)
INSERT [dbo].[Service] ([Id], [Name], [ProviderId]) VALUES (2, N'fedexGroud', 1)
INSERT [dbo].[Service] ([Id], [Name], [ProviderId]) VALUES (3, N'UPSExpress', 2)
INSERT [dbo].[Service] ([Id], [Name], [ProviderId]) VALUES (4, N'UPS2DAY', 2)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceProvider] ON 

INSERT [dbo].[ServiceProvider] ([Id], [Name]) VALUES (1, N'fedex')
INSERT [dbo].[ServiceProvider] ([Id], [Name]) VALUES (2, N'ups')
SET IDENTITY_INSERT [dbo].[ServiceProvider] OFF
GO
SET IDENTITY_INSERT [dbo].[Shipment] ON 

INSERT [dbo].[Shipment] ([Id], [CreatedBy], [Width], [Height], [Length], [Weight], [ServiceId], [MeasurementType], [CreatedAt]) VALUES (2, N'test name', 500, 500, 500, 500, 1, 0, CAST(N'2022-12-07T22:48:57.497' AS DateTime))
INSERT [dbo].[Shipment] ([Id], [CreatedBy], [Width], [Height], [Length], [Weight], [ServiceId], [MeasurementType], [CreatedAt]) VALUES (4, N'test', 0, 0, 0, 0, 1, 0, CAST(N'2022-12-07T23:29:53.920' AS DateTime))
INSERT [dbo].[Shipment] ([Id], [CreatedBy], [Width], [Height], [Length], [Weight], [ServiceId], [MeasurementType], [CreatedAt]) VALUES (5, N'test', 0, 0, 0, 0, 1, 0, CAST(N'2022-12-07T23:30:37.143' AS DateTime))
INSERT [dbo].[Shipment] ([Id], [CreatedBy], [Width], [Height], [Length], [Weight], [ServiceId], [MeasurementType], [CreatedAt]) VALUES (6, N'User 1', 550, 500, 500, 500, 2, 1, CAST(N'2022-12-10T19:24:17.180' AS DateTime))
INSERT [dbo].[Shipment] ([Id], [CreatedBy], [Width], [Height], [Length], [Weight], [ServiceId], [MeasurementType], [CreatedAt]) VALUES (7, N'User 1', 550, 500, 500, 500, 2, 1, CAST(N'2022-12-10T19:25:09.180' AS DateTime))
INSERT [dbo].[Shipment] ([Id], [CreatedBy], [Width], [Height], [Length], [Weight], [ServiceId], [MeasurementType], [CreatedAt]) VALUES (8, N'User 1', 550, 500, 500, 500, 2, 1, CAST(N'2022-12-10T19:27:29.627' AS DateTime))
SET IDENTITY_INSERT [dbo].[Shipment] OFF
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Service] FOREIGN KEY([Id])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Service]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [FK_Shipment_Service] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [FK_Shipment_Service]
GO
USE [master]
GO
ALTER DATABASE [ShippingDb] SET  READ_WRITE 
GO
