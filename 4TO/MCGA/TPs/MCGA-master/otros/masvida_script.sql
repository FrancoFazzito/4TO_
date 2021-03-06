USE [master]
GO
/****** Object:  Database [masvida_db]    Script Date: 16/10/2015 20:16:54 ******/
CREATE DATABASE [masvida_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'masvida', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\masvida.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'masvida_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\masvida_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [masvida_db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [masvida_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [masvida_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [masvida_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [masvida_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [masvida_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [masvida_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [masvida_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [masvida_db] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [masvida_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [masvida_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [masvida_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [masvida_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [masvida_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [masvida_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [masvida_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [masvida_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [masvida_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [masvida_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [masvida_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [masvida_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [masvida_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [masvida_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [masvida_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [masvida_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [masvida_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [masvida_db] SET  MULTI_USER 
GO
ALTER DATABASE [masvida_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [masvida_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [masvida_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [masvida_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [masvida_db]
GO
/****** Object:  User [masvidadb]    Script Date: 16/10/2015 20:16:56 ******/
CREATE USER [masvidadb] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [masvidadb]
GO
/****** Object:  Table [dbo].[Audits]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Audits](
	[AuditID] [int] IDENTITY(1,1) NOT NULL,
	[AuditDescription] [varchar](250) NULL,
	[UserID] [int] NULL,
	[AuditDateTime] [datetime] NULL,
 CONSTRAINT [PK_Audits] PRIMARY KEY CLUSTERED 
(
	[AuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FamiliesGroups]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FamiliesGroups](
	[FamilyGroupID] [int] IDENTITY(1,1) NOT NULL,
	[FamilyName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FamiliesGroups] PRIMARY KEY CLUSTERED 
(
	[FamilyGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Parameters]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parameters](
	[ParameterID] [int] IDENTITY(1,1) NOT NULL,
	[ParameterName] [varchar](50) NOT NULL,
	[ParameterValue] [varchar](50) NOT NULL,
	[ParameterDescription] [varbinary](250) NULL,
 CONSTRAINT [PK_Parameters] PRIMARY KEY CLUSTERED 
(
	[ParameterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[ProductDescription] [text] NULL,
	[ProductPrice] [float] NOT NULL CONSTRAINT [DF_Products_ProductPrice]  DEFAULT ((0)),
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Products_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[TransactionCreationDate] [datetime] NOT NULL CONSTRAINT [DF_Transactions_TransactionCreationDate]  DEFAULT (getdate()),
	[TransactionPaymentDate] [datetime] NULL,
	[IsPaid] [bit] NOT NULL CONSTRAINT [DF_Transactions_IsPaid]  DEFAULT ((0)),
	[TransactionTypeID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Month] [int] NOT NULL CONSTRAINT [DF_Transactions_Month]  DEFAULT ((1)),
	[Year] [int] NOT NULL CONSTRAINT [DF_Transactions_Year]  DEFAULT ((2015)),
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionsTypes]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransactionsTypes](
	[TransactionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeName] [varchar](50) NOT NULL,
	[TransactionTypeDescription] [text] NULL,
 CONSTRAINT [PK_TransactionsTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DNI] [varchar](8) NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](25) NULL,
	[Birthday] [date] NULL,
	[UserName] [varchar](50) NULL,
	[UserPassword] [varchar](150) NULL,
	[ProductID] [int] NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)),
	[UserTypeID] [int] NOT NULL CONSTRAINT [DF_Users_UserTypeID]  DEFAULT ((3)),
	[FamilyGroupID] [int] NULL,
	[CreationDateTime] [datetime] NULL CONSTRAINT [DF_Users_CreationDateTime]  DEFAULT (getdate()),
	[LastTransactionID] [int] NULL,
	[AccountTotal] [float] NULL CONSTRAINT [DF_Users_AccountTotal]  DEFAULT ((0)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsersTypes]    Script Date: 16/10/2015 20:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsersTypes](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UsersTypes] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Audits] ADD  CONSTRAINT [DF_Audits_AuditDateTime]  DEFAULT (getdate()) FOR [AuditDateTime]
GO
ALTER TABLE [dbo].[Audits]  WITH CHECK ADD  CONSTRAINT [FK_Audits_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Audits] CHECK CONSTRAINT [FK_Audits_Users]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Products]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_TransactionsTypes] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[TransactionsTypes] ([TransactionTypeID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_TransactionsTypes]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre y apellido del usuario al cual se le asigna el grupo familiar' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FamiliesGroups', @level2type=N'COLUMN',@level2name=N'FamilyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Productos y servicios de la empresa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Movimientos monetarios realizados en las cuentas corrientes de clientes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipos de transacciones que se puden realizar en una cuenta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransactionsTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contiene usuarios de aplicacion, clientes y otroa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users'
GO
USE [master]
GO
ALTER DATABASE [masvida_db] SET  READ_WRITE 
GO
