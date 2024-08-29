

/****** Object:  Database [ProjectDb]    Script Date: 19.01.2024 22:29:38 ******/
CREATE DATABASE [ProjectDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectDb', FILENAME = N'C:\MicrosoftSQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectDb_log', FILENAME = N'C:\MicrosoftSQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectDb_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ProjectDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ProjectDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ProjectDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ProjectDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ProjectDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [ProjectDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ProjectDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ProjectDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ProjectDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ProjectDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ProjectDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ProjectDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ProjectDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ProjectDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ProjectDb] SET  ENABLE_BROKER 
GO

ALTER DATABASE [ProjectDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ProjectDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ProjectDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ProjectDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ProjectDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ProjectDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ProjectDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ProjectDb] SET RECOVERY FULL 
GO

ALTER DATABASE [ProjectDb] SET  MULTI_USER 
GO

ALTER DATABASE [ProjectDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ProjectDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ProjectDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ProjectDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ProjectDb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ProjectDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [ProjectDb] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ProjectDb] SET  READ_WRITE 
GO

/*-----------------------------------------------------------------------------------------------------------------------------------------------------*/


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*-----------------------------------------------------------------------------------------------------------------------------------------------------*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GameSale](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Quantity] [decimal](18, 0) NULL,
	[Pdate] [date] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GameSale]  WITH CHECK ADD  CONSTRAINT [FK_GameSale_Product] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[GameSale] CHECK CONSTRAINT [FK_GameSale_Product]
GO

/*-----------------------------------------------------------------------------------------------------------------------------------------------------*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GameOrder](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Country] [varchar](50) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GameOrder]  WITH CHECK ADD  CONSTRAINT [FK_GameOrder_Product] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[GameOrder] CHECK CONSTRAINT [FK_GameOrder_Product]
GO



