
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/28/2013 19:50:15
-- Generated from EDMX file: D:\ProjetosASPNet\Ecommerce\Ecommerce.Database\EcommerceDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Ecommerce];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Status] smallint  NOT NULL,
    [Senha] nvarchar(max)  NOT NULL,
    [PessoaId] int  NOT NULL
);
GO

-- Creating table 'Pessoa'
CREATE TABLE [dbo].[Pessoa] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [DataNascimento] datetime  NULL,
    [CPF] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Produto'
CREATE TABLE [dbo].[Produto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Preco] decimal(10,2)  NOT NULL,
    [QtdEstoque] int  NOT NULL,
    [CategoriaId] int  NOT NULL
);
GO

-- Creating table 'Pedido'
CREATE TABLE [dbo].[Pedido] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] datetime  NOT NULL,
    [PessoaId] int  NOT NULL,
    [Status] smallint  NOT NULL
);
GO

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PedidoProduto'
CREATE TABLE [dbo].[PedidoProduto] (
    [Pedidos_Id] int  NOT NULL,
    [Produtos_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pessoa'
ALTER TABLE [dbo].[Pessoa]
ADD CONSTRAINT [PK_Pessoa]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [PK_Produto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pedido'
ALTER TABLE [dbo].[Pedido]
ADD CONSTRAINT [PK_Pedido]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categoria'
ALTER TABLE [dbo].[Categoria]
ADD CONSTRAINT [PK_Categoria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Pedidos_Id], [Produtos_Id] in table 'PedidoProduto'
ALTER TABLE [dbo].[PedidoProduto]
ADD CONSTRAINT [PK_PedidoProduto]
    PRIMARY KEY NONCLUSTERED ([Pedidos_Id], [Produtos_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PessoaId] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_PessoaUsuario]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoa]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaUsuario'
CREATE INDEX [IX_FK_PessoaUsuario]
ON [dbo].[Usuario]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaId] in table 'Pedido'
ALTER TABLE [dbo].[Pedido]
ADD CONSTRAINT [FK_PessoaPedido]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoa]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaPedido'
CREATE INDEX [IX_FK_PessoaPedido]
ON [dbo].[Pedido]
    ([PessoaId]);
GO

-- Creating foreign key on [Pedidos_Id] in table 'PedidoProduto'
ALTER TABLE [dbo].[PedidoProduto]
ADD CONSTRAINT [FK_PedidoProduto_Pedido]
    FOREIGN KEY ([Pedidos_Id])
    REFERENCES [dbo].[Pedido]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Produtos_Id] in table 'PedidoProduto'
ALTER TABLE [dbo].[PedidoProduto]
ADD CONSTRAINT [FK_PedidoProduto_Produto]
    FOREIGN KEY ([Produtos_Id])
    REFERENCES [dbo].[Produto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoProduto_Produto'
CREATE INDEX [IX_FK_PedidoProduto_Produto]
ON [dbo].[PedidoProduto]
    ([Produtos_Id]);
GO

-- Creating foreign key on [CategoriaId] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK_ProdutoCategoria]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categoria]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoCategoria'
CREATE INDEX [IX_FK_ProdutoCategoria]
ON [dbo].[Produto]
    ([CategoriaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------