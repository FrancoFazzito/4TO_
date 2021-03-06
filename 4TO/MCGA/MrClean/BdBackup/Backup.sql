USE [master]
GO
/****** Object:  Database [MrCleanBD]    Script Date: 31/10/2021 01:34:20 ******/
CREATE DATABASE [MrCleanBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MrCleanBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MrCleanBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MrCleanBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MrCleanBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MrCleanBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MrCleanBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MrCleanBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MrCleanBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MrCleanBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MrCleanBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MrCleanBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [MrCleanBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MrCleanBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MrCleanBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MrCleanBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MrCleanBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MrCleanBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MrCleanBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MrCleanBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MrCleanBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MrCleanBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MrCleanBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MrCleanBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MrCleanBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MrCleanBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MrCleanBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MrCleanBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MrCleanBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MrCleanBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MrCleanBD] SET  MULTI_USER 
GO
ALTER DATABASE [MrCleanBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MrCleanBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MrCleanBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MrCleanBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MrCleanBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MrCleanBD] SET QUERY_STORE = OFF
GO
USE [MrCleanBD]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Mensaje] [varchar](max) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Total] [decimal](18, 2) NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Entregado] [bit] NOT NULL,
	[Usuario] [int] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompraProducto]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraProducto](
	[IdCompra] [int] NULL,
	[IdProducto] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitoVertical]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVertical](
	[NombreTabla] [varchar](20) NOT NULL,
	[DigitoVerificadorVertical] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Digito_Horizontal] PRIMARY KEY CLUSTERED 
(
	[NombreTabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[RutaImagen] [varchar](50) NOT NULL,
	[DigitoVerificadorHorizontal] [varchar](max) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Permiso]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Permiso](
	[IdRol] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 31/10/2021 01:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Pass] [varchar](max) NOT NULL,
	[Salt] [varchar](max) NOT NULL,
	[Rol] [int] NOT NULL,
	[DigitoVerificadorHorizontal] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (39, CAST(N'2021-10-29T21:01:50.943' AS DateTime), N'Se ha logueado con exito: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (40, CAST(N'2021-10-29T21:15:44.533' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (41, CAST(N'2021-10-29T21:15:46.230' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (42, CAST(N'2021-10-29T21:15:48.163' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (43, CAST(N'2021-10-29T21:15:48.167' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (44, CAST(N'2021-10-29T21:15:49.070' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (45, CAST(N'2021-10-29T21:15:49.073' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (46, CAST(N'2021-10-29T21:15:50.250' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (47, CAST(N'2021-10-29T21:15:50.253' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (48, CAST(N'2021-10-29T21:18:07.890' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (49, CAST(N'2021-10-29T21:18:07.890' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (50, CAST(N'2021-10-29T21:18:08.257' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (51, CAST(N'2021-10-29T21:18:08.263' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (52, CAST(N'2021-10-29T21:18:08.710' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (53, CAST(N'2021-10-29T21:18:08.717' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (54, CAST(N'2021-10-29T21:18:09.200' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (55, CAST(N'2021-10-29T21:18:09.207' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (56, CAST(N'2021-10-29T21:20:23.233' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (57, CAST(N'2021-10-29T21:20:23.260' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (58, CAST(N'2021-10-29T21:20:23.720' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (59, CAST(N'2021-10-29T21:20:23.727' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (60, CAST(N'2021-10-29T21:20:24.220' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (61, CAST(N'2021-10-29T21:20:24.227' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (62, CAST(N'2021-10-29T21:20:24.697' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (63, CAST(N'2021-10-29T21:20:24.703' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (64, CAST(N'2021-10-29T21:20:25.083' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (65, CAST(N'2021-10-29T21:20:25.123' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (66, CAST(N'2021-10-29T21:20:25.130' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (67, CAST(N'2021-10-29T21:20:25.130' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (68, CAST(N'2021-10-29T21:20:25.133' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (69, CAST(N'2021-10-30T00:26:22.920' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (70, CAST(N'2021-10-30T00:26:22.923' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (71, CAST(N'2021-10-30T00:26:23.300' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (72, CAST(N'2021-10-30T00:26:23.300' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (73, CAST(N'2021-10-30T00:26:23.673' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (74, CAST(N'2021-10-30T00:26:23.673' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (75, CAST(N'2021-10-30T00:26:24.073' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (76, CAST(N'2021-10-30T00:26:24.080' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (77, CAST(N'2021-10-30T00:26:24.450' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (78, CAST(N'2021-10-30T00:27:21.460' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (79, CAST(N'2021-10-30T00:27:21.463' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (80, CAST(N'2021-10-30T00:27:21.783' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (81, CAST(N'2021-10-30T00:27:21.787' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (82, CAST(N'2021-10-30T00:27:22.137' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (83, CAST(N'2021-10-30T00:27:22.140' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (84, CAST(N'2021-10-30T00:27:22.473' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (85, CAST(N'2021-10-30T00:27:22.477' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (86, CAST(N'2021-10-30T00:27:22.830' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (87, CAST(N'2021-10-30T00:27:22.840' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (88, CAST(N'2021-10-30T00:27:22.843' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (89, CAST(N'2021-10-30T00:27:22.850' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (90, CAST(N'2021-10-30T00:27:22.853' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (91, CAST(N'2021-10-30T00:38:34.973' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (92, CAST(N'2021-10-30T00:38:34.973' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (93, CAST(N'2021-10-30T00:45:09.317' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (94, CAST(N'2021-10-30T00:45:09.317' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (95, CAST(N'2021-10-30T00:45:09.603' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (96, CAST(N'2021-10-30T00:45:09.607' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (97, CAST(N'2021-10-30T00:45:09.937' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (98, CAST(N'2021-10-30T00:45:09.940' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (99, CAST(N'2021-10-30T00:45:10.263' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (100, CAST(N'2021-10-30T00:45:10.267' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (101, CAST(N'2021-10-30T00:45:10.583' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (102, CAST(N'2021-10-30T00:45:10.583' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (103, CAST(N'2021-10-30T00:45:10.870' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (104, CAST(N'2021-10-30T00:45:10.880' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (105, CAST(N'2021-10-30T00:45:10.883' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (106, CAST(N'2021-10-30T00:45:10.887' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (107, CAST(N'2021-10-30T00:45:10.900' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (108, CAST(N'2021-10-30T00:55:24.487' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (109, CAST(N'2021-10-30T00:55:27.657' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (110, CAST(N'2021-10-30T00:55:38.183' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (111, CAST(N'2021-10-30T00:55:38.183' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (112, CAST(N'2021-10-30T00:55:38.453' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (113, CAST(N'2021-10-30T00:55:38.457' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (114, CAST(N'2021-10-30T00:55:38.733' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (115, CAST(N'2021-10-30T00:55:38.737' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (116, CAST(N'2021-10-30T00:55:39.040' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (117, CAST(N'2021-10-30T00:55:39.040' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (118, CAST(N'2021-10-30T00:55:39.317' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (119, CAST(N'2021-10-30T00:55:39.327' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (120, CAST(N'2021-10-30T00:55:39.333' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (121, CAST(N'2021-10-30T00:55:39.337' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (122, CAST(N'2021-10-30T00:55:39.350' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (123, CAST(N'2021-10-30T01:22:45.827' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (124, CAST(N'2021-10-30T01:22:45.830' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (125, CAST(N'2021-10-30T01:22:46.193' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (126, CAST(N'2021-10-30T01:22:46.197' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (127, CAST(N'2021-10-30T01:22:46.610' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (128, CAST(N'2021-10-30T01:22:46.613' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (129, CAST(N'2021-10-30T01:22:46.980' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (130, CAST(N'2021-10-30T01:22:46.983' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (131, CAST(N'2021-10-30T01:22:47.340' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (132, CAST(N'2021-10-30T01:22:47.340' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (133, CAST(N'2021-10-30T01:22:47.677' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (134, CAST(N'2021-10-30T01:22:47.690' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (135, CAST(N'2021-10-30T01:22:47.697' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (136, CAST(N'2021-10-30T01:22:47.707' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (137, CAST(N'2021-10-30T01:22:47.730' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
GO
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (138, CAST(N'2021-10-30T01:26:03.893' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (139, CAST(N'2021-10-30T01:26:03.893' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (140, CAST(N'2021-10-30T01:26:04.427' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (141, CAST(N'2021-10-30T01:26:04.427' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (142, CAST(N'2021-10-30T01:26:05.267' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (143, CAST(N'2021-10-30T01:26:05.270' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (144, CAST(N'2021-10-30T01:26:06.517' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (145, CAST(N'2021-10-30T01:26:06.520' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (146, CAST(N'2021-10-30T01:26:07.717' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (147, CAST(N'2021-10-30T01:26:07.720' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (148, CAST(N'2021-10-30T01:26:08.880' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (149, CAST(N'2021-10-30T01:27:51.543' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (150, CAST(N'2021-10-30T01:35:36.413' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (151, CAST(N'2021-10-30T01:35:36.417' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (152, CAST(N'2021-10-30T01:35:36.787' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (153, CAST(N'2021-10-30T01:36:00.263' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (154, CAST(N'2021-10-30T01:38:05.713' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (155, CAST(N'2021-10-30T01:38:05.717' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (156, CAST(N'2021-10-30T01:38:06.073' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (157, CAST(N'2021-10-30T01:38:44.960' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (158, CAST(N'2021-10-30T01:40:00.377' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (159, CAST(N'2021-10-30T01:40:00.383' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (160, CAST(N'2021-10-30T01:40:00.770' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (161, CAST(N'2021-10-30T01:40:14.737' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (162, CAST(N'2021-10-30T01:40:14.740' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (163, CAST(N'2021-10-30T01:40:15.023' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (164, CAST(N'2021-10-30T01:40:15.033' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (165, CAST(N'2021-10-30T01:40:56.670' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (166, CAST(N'2021-10-30T01:40:56.673' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (167, CAST(N'2021-10-30T01:40:57.033' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (168, CAST(N'2021-10-30T01:42:31.857' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (169, CAST(N'2021-10-30T01:42:31.860' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (170, CAST(N'2021-10-30T01:42:32.203' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (171, CAST(N'2021-10-30T01:42:32.217' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (172, CAST(N'2021-10-30T01:42:57.847' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (173, CAST(N'2021-10-30T01:42:57.850' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (174, CAST(N'2021-10-30T01:42:58.227' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (175, CAST(N'2021-10-30T01:42:58.240' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (176, CAST(N'2021-10-30T01:43:20.803' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (177, CAST(N'2021-10-30T01:43:20.807' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (178, CAST(N'2021-10-30T01:43:21.203' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (179, CAST(N'2021-10-30T01:43:29.790' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (180, CAST(N'2021-10-30T01:43:29.790' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (181, CAST(N'2021-10-30T01:43:30.077' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (182, CAST(N'2021-10-30T01:43:30.087' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (183, CAST(N'2021-10-30T01:44:12.990' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (184, CAST(N'2021-10-30T01:44:12.990' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (185, CAST(N'2021-10-30T01:44:13.323' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (186, CAST(N'2021-10-30T01:44:13.340' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (187, CAST(N'2021-10-30T01:48:27.267' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (188, CAST(N'2021-10-30T01:48:27.290' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (189, CAST(N'2021-10-30T01:48:27.737' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (190, CAST(N'2021-10-30T01:48:45.017' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (191, CAST(N'2021-10-30T01:48:45.020' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (192, CAST(N'2021-10-30T01:48:45.360' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (193, CAST(N'2021-10-30T01:48:57.947' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (194, CAST(N'2021-10-30T01:48:57.950' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (195, CAST(N'2021-10-30T01:48:58.283' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (196, CAST(N'2021-10-30T01:49:46.133' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (197, CAST(N'2021-10-30T01:49:46.140' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (198, CAST(N'2021-10-30T01:49:46.507' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (199, CAST(N'2021-10-30T01:53:05.593' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (200, CAST(N'2021-10-30T01:53:05.597' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (201, CAST(N'2021-10-30T01:53:05.983' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (202, CAST(N'2021-10-30T01:53:12.933' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (203, CAST(N'2021-10-30T01:54:47.983' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (204, CAST(N'2021-10-30T01:54:47.987' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (205, CAST(N'2021-10-30T01:54:48.353' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (206, CAST(N'2021-10-30T01:54:48.353' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (207, CAST(N'2021-10-30T01:54:48.803' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (208, CAST(N'2021-10-30T01:54:48.807' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (209, CAST(N'2021-10-30T01:54:49.193' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (210, CAST(N'2021-10-30T01:54:49.213' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (211, CAST(N'2021-10-30T01:54:49.650' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (212, CAST(N'2021-10-30T01:54:49.650' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (213, CAST(N'2021-10-30T01:54:49.933' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (214, CAST(N'2021-10-30T01:54:49.947' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (215, CAST(N'2021-10-30T01:54:49.950' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (216, CAST(N'2021-10-30T01:54:49.953' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (217, CAST(N'2021-10-30T01:54:49.967' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (218, CAST(N'2021-10-30T19:28:16.023' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (219, CAST(N'2021-10-30T19:28:16.027' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (220, CAST(N'2021-10-30T19:28:16.437' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (221, CAST(N'2021-10-30T19:28:16.443' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (222, CAST(N'2021-10-30T19:28:16.827' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (223, CAST(N'2021-10-30T19:28:16.833' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (224, CAST(N'2021-10-30T19:28:17.193' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (225, CAST(N'2021-10-30T19:28:17.197' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (226, CAST(N'2021-10-30T19:28:17.543' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (227, CAST(N'2021-10-30T19:28:17.550' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (228, CAST(N'2021-10-30T19:28:17.943' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (229, CAST(N'2021-10-30T20:33:32.707' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (230, CAST(N'2021-10-30T20:33:32.710' AS DateTime), N'Se ha dado de alta al usuario: franco@gmail.com con rol [Cliente]', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (231, CAST(N'2021-10-30T20:33:33.063' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (232, CAST(N'2021-10-30T20:33:33.067' AS DateTime), N'Se ha dado de alta al usuario: vilu@gmail.com con rol [Cliente]', N'2', N'vilu@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (233, CAST(N'2021-10-30T20:33:33.380' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (234, CAST(N'2021-10-30T20:33:33.380' AS DateTime), N'Se ha dado de alta al usuario: katia@gmail.com con rol [Cliente]', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (235, CAST(N'2021-10-30T20:33:33.717' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (236, CAST(N'2021-10-30T20:33:33.717' AS DateTime), N'Se ha dado de alta al usuario: tomas@gmail.com con rol [Cliente]', N'2', N'tomas@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (237, CAST(N'2021-10-30T20:33:34.037' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'nelson@gmail.com')
GO
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (238, CAST(N'2021-10-30T20:33:34.037' AS DateTime), N'Se ha dado de alta al usuario: nelson@gmail.com con rol [Cliente]', N'2', N'nelson@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (239, CAST(N'2021-10-30T20:33:39.287' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (240, CAST(N'2021-10-30T20:33:39.303' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (241, CAST(N'2021-10-30T20:33:39.310' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (242, CAST(N'2021-10-30T20:33:39.313' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (243, CAST(N'2021-10-30T20:33:39.317' AS DateTime), N'Se ha actualizado el digito verificador vertical para los productos', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (244, CAST(N'2021-10-30T20:34:32.377' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (245, CAST(N'2021-10-30T20:35:52.903' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (246, CAST(N'2021-10-30T20:36:48.790' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (247, CAST(N'2021-10-30T20:39:35.653' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (248, CAST(N'2021-10-30T20:47:36.597' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (249, CAST(N'2021-10-30T21:50:17.647' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (250, CAST(N'2021-10-30T21:52:41.817' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (251, CAST(N'2021-10-30T21:54:51.397' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (252, CAST(N'2021-10-30T21:58:11.237' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (253, CAST(N'2021-10-30T22:00:38.400' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (254, CAST(N'2021-10-30T22:04:24.023' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (255, CAST(N'2021-10-31T00:06:49.647' AS DateTime), N'Se ha logueado con exito el usuario: franco@gmail.com', N'2', N'franco@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (256, CAST(N'2021-10-31T01:04:49.163' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (257, CAST(N'2021-10-31T01:07:29.163' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (258, CAST(N'2021-10-31T01:10:39.820' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (259, CAST(N'2021-10-31T01:23:56.340' AS DateTime), N'Se ha actualizado el digito verificador vertical para los usuarios', N'2', N'test@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (260, CAST(N'2021-10-31T01:23:56.963' AS DateTime), N'Se ha dado de alta al usuario: test@gmail.com con rol [Cliente]', N'2', N'test@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (261, CAST(N'2021-10-31T01:24:15.107' AS DateTime), N'Se ha logueado con exito el usuario: test@gmail.com', N'2', N'test@gmail.com')
INSERT [dbo].[Bitacora] ([Id], [Fecha], [Mensaje], [Tipo], [Usuario]) VALUES (262, CAST(N'2021-10-31T01:30:34.257' AS DateTime), N'Se ha logueado con exito el usuario: katia@gmail.com', N'2', N'katia@gmail.com')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
INSERT [dbo].[DigitoVertical] ([NombreTabla], [DigitoVerificadorVertical]) VALUES (N'Producto', N'8c3f0ffcc9356b53bf9189241a5af693370834b4661fb88ad844380c27ac0ec0')
INSERT [dbo].[DigitoVertical] ([NombreTabla], [DigitoVerificadorVertical]) VALUES (N'Usuario', N'a8d9c4be8d6ddc8c5b33a214e28ca1b157528c9f4ad466260dfc2182cee8dc98')
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (1, N'crear')
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (2, N'eliminar')
INSERT [dbo].[Permiso] ([Id], [Nombre]) VALUES (3, N'modificar')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [RutaImagen], [DigitoVerificadorHorizontal]) VALUES (48, N'Trapo de piso', CAST(50.00 AS Decimal(18, 2)), N'Imagenes/trapo.jpg', N'48aef07101639924c02ec6b763b820a4143ddb984ea9a295c6ebd31f7f9e3b49')
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [RutaImagen], [DigitoVerificadorHorizontal]) VALUES (49, N'jabon', CAST(100.00 AS Decimal(18, 2)), N'Imagenes/jabon.jpg', N'41845ad59ecdbf8d6ece85f1fc720ed20cd1a682ea887c70bc0667a8e166444e')
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [RutaImagen], [DigitoVerificadorHorizontal]) VALUES (50, N'Detergente', CAST(150.00 AS Decimal(18, 2)), N'Imagenes/detergente.jpg', N'0f234c2f990fa5ea7319c81eb440c9026f0b10ffc39adbc3504200855fb6c11f')
INSERT [dbo].[Producto] ([Id], [Nombre], [Precio], [RutaImagen], [DigitoVerificadorHorizontal]) VALUES (51, N'shampoo', CAST(200.00 AS Decimal(18, 2)), N'Imagenes/shampoo.jpg', N'b49d3ce35071c36d554f8803dda29b8f969551bdf25c3731e0cbce908654cb4b')
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (1, N'master')
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (2, N'cliente')
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (3, N'operador')
INSERT [dbo].[Rol] ([Id], [Nombre]) VALUES (4, N'gerente')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
INSERT [dbo].[Rol_Permiso] ([IdRol], [IdPermiso]) VALUES (1, 1)
INSERT [dbo].[Rol_Permiso] ([IdRol], [IdPermiso]) VALUES (1, 2)
INSERT [dbo].[Rol_Permiso] ([IdRol], [IdPermiso]) VALUES (1, 3)
INSERT [dbo].[Rol_Permiso] ([IdRol], [IdPermiso]) VALUES (2, 1)
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Email], [Pass], [Salt], [Rol], [DigitoVerificadorHorizontal], [Activo]) VALUES (132, N'franco@gmail.com', N'BHpDGB6i2GEB82XCPxPB0Ta1W1r+Kk5AXckO5AIUa+XHWsHrZ2z/mEoN+YLRsx1A3YbI9qfxscR3/CKn8OTDFOX9oVFhOsuikLkHLd9A9mCbJPQLcAeKgC68bwxJudy4f2TSlCgt5iTlSvdMYeXYS228Jkfcd0nGZ4M4GFaIYmcJrYqdKQwzag+4i9qmlsJm0OsA97lxREPfb2KhvfOVmdm/ZFjeTRUn5b8qcBCPfZuIo9QdAhQlCf8cqkaVo6kifpdegpN3awPjCXOMGcFWmshDdg9jBIrLV3sxjOSf6m6KGzKUqCeIGWAU+2EGhc1nh/8nwotHnBFGd+4DLBowpA==', N'FUfi5JJon+LoSrkW8CxF9sDuP04UmPv9DayxaYqBP1fe1lCr/8pC45Gt/2rbfDaPyqI4F4+DPwRVi0+NhtFqtA==', 2, N'e0787c7ea01c06836e967ff64c1e3032a9a27c1ea3b323b0cac6aa09025b04a8', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [Pass], [Salt], [Rol], [DigitoVerificadorHorizontal], [Activo]) VALUES (133, N'vilu@gmail.com', N'XAg18EINnn37n6f1kk+hVeJi9fmjSVw/MsxtVoyHPIZJw2dSmS87ffvMDa8QWdbBd1NkrG0mam9lwLf4Fgit44cMI/c6k3iIyuXYsAe1Yw7bc/O3QZXBD+mIE0Cj9qD6OJUiTswGKg3E/FG7rUeXHB6LF0CVtK06ObzEHFNd/Xl5WBk6rdZuEnTUHDaPUEZEtvUXOD1/QnX8bCGBU9XPP768/7+kCG/qfUPYNBpn/RNXlSMorDf3Nz1Rd71+gMdtjZNDE/PdgD0GtllIWAoGXVSJd3WXg5Y1XpvS8C826nP9Hjk9vQcvOlthxAVHakLPQfMKsGRW/zBeag6ayKqkNQ==', N'7+Xk66d6u3WACvVe7Q9fI2ydInIa+FxdlxqfzFrzZ5KYFPUNWla9wDEQbINjVuBHzLsUF8URLT2bml0m4Hcmfw==', 2, N'2ca4f2884a6f858eeb7fa527efe91728cc7bc3d1444923c2f376a9db6fc5ca05', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [Pass], [Salt], [Rol], [DigitoVerificadorHorizontal], [Activo]) VALUES (134, N'katia@gmail.com', N'/TA/oI5ZOUW3kPzQvkiPpQIeFteKDh7BIuMDpq2adUZYEh7+nvGAe7mdPYMH3sKC+bgvhErkR9GP0kg6H1GpGvXdSZhTV/TtniBswpGrMw9zEloeb2S9ev0AU8wsHxepsnU13+sB5NhojW3sdqtuUy3h4Ekpyiv+nfDfi5tF9ctOMUagcfXvckEq4A5tMl4jM8gKOM1EGi16O3byZR+/9/218WXtyTfE28Hda55YTt2QTTt2B3oaS9Zg9w/Dawpl/Ja+qFcDlKnjlqGxsAJO95IbWrhJZRTcAWpJF71iOsj5o0ZnptZ6/r8SUeg+T6LXOZAykMVRj3Lu2r6OWOYklw==', N'Zq6fXLJDSCJ2x7VyXgLH4C2Np1JaVtCTD9USjQkxlJ421x0HU7G/4Xh7RC/YlGxSj9Su3q63s5hmYPSskrQ0qA==', 1, N'2f485115287d662d124392ef92eda38cb9114fdeed2fd6284d53f40cc7172421', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [Pass], [Salt], [Rol], [DigitoVerificadorHorizontal], [Activo]) VALUES (135, N'tomas@gmail.com', N'6u3/lGh5hn62FxLL6LPut19b5uE9W3f2y8Szie2SL1IpkvoHSqR38GKT9yAl3njFs8a4UfPZ2ahc5hCeb6DJWPUQYzeAcSIK6hMGuccYkrUfB+L7FR2MMYrc9SyrTaqF5tidKW5s48NIIh5QdJMNdNEckRw48jYR+1/fjGwcOVUNByTlZVYmuNCqrezbN+Yvvx9F2v+2DzQaNJywKhvXM0ea0zaPgBm0U1ZK4qL1kRVgr09RRU2fG+pGM4vKqsGoRlss/54coV3QJdi6NK6LWTZtHTFtafAl3V3X51/JENeyRp05lvgBBpIQlUgk3jXUjwjdTmyI/wZBieMQiFKkkA==', N'wOWJVjKXQayjgYcej9ZovVL7KV94FjBbDVD5E1nUid29kPExfiC8KTvJ1dHjdUsq55EFFTHu/kpCZwMBOvcnaQ==', 3, N'6fd9c84c187dd4603a66a2a7ee867087bd92d58c58a2c1bf86774075820b9b3b', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [Pass], [Salt], [Rol], [DigitoVerificadorHorizontal], [Activo]) VALUES (136, N'nelson@gmail.com', N'MCsm3R/fNNb7ohAl9bNjK/rYywXVFqtOLSM5URtA4wKyDhXjn3H7QBYbmFohL4uOqVLxaoHyqzsJoku6m4qahFZEUpta4C15nNfrcmyv6vxLH8/Ypk58Df9vQSGL6mLASqPZalEVHYG3bZnU4jGhqEGypGLzrM86qbCjLZWscaRqWPHCKhLFDbk6jXL47ECoTjPWIWUNRGLZ+GDzKoksWVlXDLyb20WeDPjgM0b3hjqXhn7DUK2XdkhONkgN0/ozpj0t7zlXv0ILwbhONCU2PlIyz7STOIb6FylOhLE8wUheUGCwR+MbAQDp2mw4wiBBJ0OxDNWw3reZtClpefsAaQ==', N'+lvUV0npefzqeB/HqP6EhEgWjVeNsvB6RYK1u5JCrBuFS73pJZI6DkoiqPxWszRFonHO1EBrN+vYnNza5H8I+g==', 4, N'a07dbe6bccf919b56ffe733248210adc2e6d2dbbd8c4d4fe4c5655a740e12985', 1)
INSERT [dbo].[Usuario] ([Id], [Email], [Pass], [Salt], [Rol], [DigitoVerificadorHorizontal], [Activo]) VALUES (138, N'test@gmail.com', N'DjagmN554uip0cnJp8eSEIU+rPDvEeG/MfLAso9gv2C37J5nICh3Yl53sN9C3c7LTfJjVL2E7kn3O+yxaP1EtdzYcqc7PTUVnx9cTJjXQ0cmoBhRdlJEtlXt7v2MATcV00qM5an8LYBeZNAzgfdAUsvfRVuTiHxwBuQYdVkLnXNoLo245rusE66va5g6ajPV2DrdZfkkLpL8BEnS532alu10ybBaWElhnWO7BHe3AdFySbFucVK4Hzjwqf1Ghthwo6KWHYlF9OBw6HW3+qdD9N9sZ0ReDKFPC8rqXavAyXxbgzSay39hoUFaajKZkF5SzQ1qEPY/QYa9Dj0T+ziTOA==', N'FsmRZBRr7r6poCcnrUmUfc11i9h+mum+9pd1Hu+4T6356StQvdGqLz+u1ZH9K4Zl5NbXOwFUwhiaQ3OrILeHzg==', 2, N'51f5cf3eb3d75edfa0848eb419b127473c01a883ef481cacdf2c13cb14361e44', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Producto]    Script Date: 31/10/2021 01:34:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Producto] ON [dbo].[Producto]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuario]    Script Date: 31/10/2021 01:34:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuario] ON [dbo].[Usuario]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Usuario] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuario] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Usuario]
GO
ALTER TABLE [dbo].[CompraProducto]  WITH CHECK ADD  CONSTRAINT [FK_CompraProducto_Compra] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompraProducto] CHECK CONSTRAINT [FK_CompraProducto_Compra]
GO
ALTER TABLE [dbo].[CompraProducto]  WITH CHECK ADD  CONSTRAINT [FK_CompraProducto_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompraProducto] CHECK CONSTRAINT [FK_CompraProducto_Producto]
GO
ALTER TABLE [dbo].[Rol_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Permiso_Permiso] FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rol_Permiso] CHECK CONSTRAINT [FK_Rol_Permiso_Permiso]
GO
ALTER TABLE [dbo].[Rol_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Permiso_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rol_Permiso] CHECK CONSTRAINT [FK_Rol_Permiso_Rol]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([Rol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
USE [master]
GO
ALTER DATABASE [MrCleanBD] SET  READ_WRITE 
GO
