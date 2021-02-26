USE [master]
GO
/****** Object:  Database [Clientes]    Script Date: 26/02/2021 13:48:11 ******/
CREATE DATABASE [Clientes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Clientes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Clientes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Clientes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Clientes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Clientes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Clientes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Clientes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Clientes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Clientes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Clientes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Clientes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Clientes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Clientes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Clientes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Clientes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Clientes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Clientes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Clientes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Clientes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Clientes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Clientes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Clientes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Clientes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Clientes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Clientes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Clientes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Clientes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Clientes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Clientes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Clientes] SET  MULTI_USER 
GO
ALTER DATABASE [Clientes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Clientes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Clientes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Clientes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Clientes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Clientes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Clientes] SET QUERY_STORE = OFF
GO
USE [Clientes]
GO
/****** Object:  Table [dbo].[ClienteEndereco]    Script Date: 26/02/2021 13:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteEndereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Logradouro] [varchar](50) NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[Complemento] [varchar](30) NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[Estado] [varchar](30) NOT NULL,
	[Pais] [varchar](30) NOT NULL,
	[Cep] [varchar](8) NOT NULL,
 CONSTRAINT [PK_ClienteEndereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 26/02/2021 13:48:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[Nome] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClienteEndereco] ON 
GO
INSERT [dbo].[ClienteEndereco] ([Id], [IdCliente], [Logradouro], [Numero], [Complemento], [Bairro], [Cidade], [Estado], [Pais], [Cep]) VALUES (1, 1, N'Rua das Uvaias', N'101', N'Apto 100', N'São Paulo', N'São Paulo', N'SP', N'Brasil', N'04055110')
GO
SET IDENTITY_INSERT [dbo].[ClienteEndereco] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([Id], [CPF], [Nome]) VALUES (1, N'48302879002', N'Ronaldo')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
ALTER TABLE [dbo].[ClienteEndereco]  WITH CHECK ADD  CONSTRAINT [FK_ClienteEndereco_ClienteEndereco] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[ClienteEndereco] CHECK CONSTRAINT [FK_ClienteEndereco_ClienteEndereco]
GO
USE [master]
GO
ALTER DATABASE [Clientes] SET  READ_WRITE 
GO
