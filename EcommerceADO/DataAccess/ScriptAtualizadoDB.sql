USE [master]
GO
/****** Object:  Database [Ecommerce2]    Script Date: 04/23/2013 21:21:50 ******/
CREATE DATABASE [Ecommerce2] ON  PRIMARY 
( NAME = N'Ecommerce2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS2\MSSQL\DATA\Ecommerce2.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ecommerce2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS2\MSSQL\DATA\Ecommerce2_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ecommerce2] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ecommerce2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ecommerce2] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Ecommerce2] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Ecommerce2] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Ecommerce2] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Ecommerce2] SET ARITHABORT OFF
GO
ALTER DATABASE [Ecommerce2] SET AUTO_CLOSE ON
GO
ALTER DATABASE [Ecommerce2] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Ecommerce2] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Ecommerce2] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Ecommerce2] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Ecommerce2] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Ecommerce2] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Ecommerce2] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Ecommerce2] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Ecommerce2] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Ecommerce2] SET  ENABLE_BROKER
GO
ALTER DATABASE [Ecommerce2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Ecommerce2] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Ecommerce2] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Ecommerce2] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Ecommerce2] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Ecommerce2] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Ecommerce2] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Ecommerce2] SET  READ_WRITE
GO
ALTER DATABASE [Ecommerce2] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Ecommerce2] SET  MULTI_USER
GO
ALTER DATABASE [Ecommerce2] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Ecommerce2] SET DB_CHAINING OFF
GO
USE [Ecommerce2]
GO
/****** Object:  ForeignKey [FK_PessoaUsuario]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_PessoaUsuario]
GO
/****** Object:  ForeignKey [FK_PessoaPedido]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[Pedido] DROP CONSTRAINT [FK_PessoaPedido]
GO
/****** Object:  ForeignKey [FK_PedidoProduto_Pedido]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[PedidoProduto] DROP CONSTRAINT [FK_PedidoProduto_Pedido]
GO
/****** Object:  ForeignKey [FK_PedidoProduto_Produto]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[PedidoProduto] DROP CONSTRAINT [FK_PedidoProduto_Produto]
GO
/****** Object:  Table [dbo].[PedidoProduto]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[PedidoProduto] DROP CONSTRAINT [FK_PedidoProduto_Pedido]
GO
ALTER TABLE [dbo].[PedidoProduto] DROP CONSTRAINT [FK_PedidoProduto_Produto]
GO
DROP TABLE [dbo].[PedidoProduto]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[Pedido] DROP CONSTRAINT [FK_PessoaPedido]
GO
DROP TABLE [dbo].[Pedido]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_PessoaUsuario]
GO
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 04/23/2013 21:21:55 ******/
DROP TABLE [dbo].[Pessoa]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 04/23/2013 21:21:55 ******/
DROP TABLE [dbo].[Produto]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 04/23/2013 21:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[Preco] [decimal](10, 2) NOT NULL,
	[QtdEstoque] [int] NOT NULL,
	[CategoriaId] [int] NULL,
	[Foto] [varchar](max) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Produto] ON
INSERT [dbo].[Produto] ([Id], [Nome], [Descricao], [Preco], [QtdEstoque], [CategoriaId], [Foto]) VALUES (1, N'Televisao', N'Televisor 40" LED Full HD', CAST(4000.00 AS Decimal(10, 2)), 10, 1, N'tv.png')
SET IDENTITY_INSERT [dbo].[Produto] OFF
/****** Object:  Table [dbo].[Pessoa]    Script Date: 04/23/2013 21:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[DataNascimento] [datetime] NULL,
	[CPF] [nvarchar](max) NOT NULL,
	[NomeFoto] [varchar](max) NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Pessoa] ON
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [CPF], [NomeFoto]) VALUES (1, N'Gustavo', CAST(0x0000800F00000000 AS DateTime), N'11111', NULL)
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [CPF], [NomeFoto]) VALUES (2, N'Gustavo', CAST(0x0000A28700000000 AS DateTime), N'222222', N'AOL-Messenger-Icon-Akkasone.png')
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [CPF], [NomeFoto]) VALUES (3, N'ffAA', CAST(0x0000724300000000 AS DateTime), N'234.456.679-00', N'CuteFTP-Icon-Akkasone.png')
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [CPF], [NomeFoto]) VALUES (4, N'AAAAAA', CAST(0x0000724300000000 AS DateTime), N'223.444.555-00', N'CuteFTP-Icon-Akkasone.png')
INSERT [dbo].[Pessoa] ([Id], [Nome], [DataNascimento], [CPF], [NomeFoto]) VALUES (5, N'AAAAAA', CAST(0x0000724300000000 AS DateTime), N'223.444.555-00', N'CuteFTP-Icon-Akkasone.png')
SET IDENTITY_INSERT [dbo].[Pessoa] OFF
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/23/2013 21:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[Senha] [nvarchar](max) NOT NULL,
	[PessoaId] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FK_PessoaUsuario] ON [dbo].[Usuario] 
(
	[PessoaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([Id], [Login], [Status], [Senha], [PessoaId]) VALUES (1, N'gustavo', 1, N'1', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Table [dbo].[Pedido]    Script Date: 04/23/2013 21:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[PessoaId] [int] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FK_PessoaPedido] ON [dbo].[Pedido] 
(
	[PessoaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoProduto]    Script Date: 04/23/2013 21:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoProduto](
	[Pedidos_Id] [int] NOT NULL,
	[Produtos_Id] [int] NOT NULL,
 CONSTRAINT [PK_PedidoProduto] PRIMARY KEY NONCLUSTERED 
(
	[Pedidos_Id] ASC,
	[Produtos_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FK_PedidoProduto_Produto] ON [dbo].[PedidoProduto] 
(
	[Produtos_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_PessoaUsuario]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_PessoaUsuario] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_PessoaUsuario]
GO
/****** Object:  ForeignKey [FK_PessoaPedido]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_PessoaPedido] FOREIGN KEY([PessoaId])
REFERENCES [dbo].[Pessoa] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_PessoaPedido]
GO
/****** Object:  ForeignKey [FK_PedidoProduto_Pedido]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[PedidoProduto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoProduto_Pedido] FOREIGN KEY([Pedidos_Id])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[PedidoProduto] CHECK CONSTRAINT [FK_PedidoProduto_Pedido]
GO
/****** Object:  ForeignKey [FK_PedidoProduto_Produto]    Script Date: 04/23/2013 21:21:55 ******/
ALTER TABLE [dbo].[PedidoProduto]  WITH CHECK ADD  CONSTRAINT [FK_PedidoProduto_Produto] FOREIGN KEY([Produtos_Id])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[PedidoProduto] CHECK CONSTRAINT [FK_PedidoProduto_Produto]
GO
