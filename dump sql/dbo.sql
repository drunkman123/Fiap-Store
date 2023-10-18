/*
 Navicat Premium Data Transfer

 Source Server         : local
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : 1302101L3149595\SQLEXPRESS:1433
 Source Catalog        : fiapStore
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 11/10/2023 17:32:35
*/


-- ----------------------------
-- Table structure for Cliente
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type IN ('U'))
	DROP TABLE [dbo].[Cliente]
GO

CREATE TABLE [dbo].[Cliente] (
  [IdCliente] int  IDENTITY(1,1) NOT NULL,
  [Nome] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [CPF] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Telefone] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Email] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Password] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [IdPermissao] tinyint  NOT NULL,
  [DataNascimento] date  NOT NULL
)
GO

ALTER TABLE [dbo].[Cliente] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Cliente
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Cliente] ON
GO

INSERT INTO [dbo].[Cliente] ([IdCliente], [Nome], [CPF], [Telefone], [Email], [Password], [IdPermissao], [DataNascimento]) VALUES (N'15', N'Admin Admin', N'11111111111', N'11111111111', N'admin@email.com', N'$2a$12$dCTbe2x/iXCSgwe2ebaBl.QW5L8JViqXYgCv7407f/J66AbaB2z.G', N'1', N'2000-10-06')
GO

INSERT INTO [dbo].[Cliente] ([IdCliente], [Nome], [CPF], [Telefone], [Email], [Password], [IdPermissao], [DataNascimento]) VALUES (N'16', N'Client Client', N'22222222222', N'22222222222', N'client@email.com', N'$2a$12$dCTbe2x/iXCSgwe2ebaBl.QW5L8JViqXYgCv7407f/J66AbaB2z.G', N'2', N'2000-10-06')
GO

SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO


-- ----------------------------
-- Table structure for Endereco
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Endereco]') AND type IN ('U'))
	DROP TABLE [dbo].[Endereco]
GO

CREATE TABLE [dbo].[Endereco] (
  [IdEndereco] int  IDENTITY(1,1) NOT NULL,
  [Rua] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Bairro] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Cidade] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Numero] varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Complemento] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CEP] varchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [IdCliente] int  NULL
)
GO

ALTER TABLE [dbo].[Endereco] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Endereco
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Endereco] ON
GO

INSERT INTO [dbo].[Endereco] ([IdEndereco], [Rua], [Bairro], [Cidade], [Numero], [Complemento], [CEP], [IdCliente]) VALUES (N'13', N'string', N'string', N'string', N'string', N'string', N'11111111', N'15')
GO

INSERT INTO [dbo].[Endereco] ([IdEndereco], [Rua], [Bairro], [Cidade], [Numero], [Complemento], [CEP], [IdCliente]) VALUES (N'14', N'string', N'string', N'string', N'string', N'string', N'11111111', N'16')
GO

INSERT INTO [dbo].[Endereco] ([IdEndereco], [Rua], [Bairro], [Cidade], [Numero], [Complemento], [CEP], [IdCliente]) VALUES (N'15', N'string', N'string', N'string', N'string', N'string', N'12123123', N'16')
GO

SET IDENTITY_INSERT [dbo].[Endereco] OFF
GO


-- ----------------------------
-- Table structure for Estoque
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Estoque]') AND type IN ('U'))
	DROP TABLE [dbo].[Estoque]
GO

CREATE TABLE [dbo].[Estoque] (
  [IdProduto] int  NOT NULL,
  [Qtde] int  NULL
)
GO

ALTER TABLE [dbo].[Estoque] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Estoque
-- ----------------------------
INSERT INTO [dbo].[Estoque] ([IdProduto], [Qtde]) VALUES (N'5', N'8')
GO

INSERT INTO [dbo].[Estoque] ([IdProduto], [Qtde]) VALUES (N'6', N'3')
GO


-- ----------------------------
-- Table structure for Item
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type IN ('U'))
	DROP TABLE [dbo].[Item]
GO

CREATE TABLE [dbo].[Item] (
  [IdItem] int  IDENTITY(1,1) NOT NULL,
  [IdPedido] int  NULL,
  [IdProduto] int  NULL,
  [Quantidade] int  NULL,
  [Preco] decimal(18,2)  NULL,
  [SubTotal] decimal(18,2)  NULL
)
GO

ALTER TABLE [dbo].[Item] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Item
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Item] ON
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'8', N'4', N'5', N'2', N'10.20', N'20.40')
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'9', N'4', N'6', N'3', N'70.00', N'210.00')
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'10', N'5', N'5', N'1', N'10.20', N'10.20')
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'11', N'5', N'6', N'1', N'70.00', N'70.00')
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'12', N'8', N'6', N'1', N'70.00', N'70.00')
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'13', N'9', N'5', N'1', N'10.20', N'10.20')
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'14', N'9', N'6', N'2', N'70.00', N'140.00')
GO

INSERT INTO [dbo].[Item] ([IdItem], [IdPedido], [IdProduto], [Quantidade], [Preco], [SubTotal]) VALUES (N'15', N'10', N'5', N'2', N'10.20', N'20.40')
GO

SET IDENTITY_INSERT [dbo].[Item] OFF
GO


-- ----------------------------
-- Table structure for LogErro
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[LogErro]') AND type IN ('U'))
	DROP TABLE [dbo].[LogErro]
GO

CREATE TABLE [dbo].[LogErro] (
  [IdLog] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Message] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [StackTrace] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [TimeStamp] bigint  NULL
)
GO

ALTER TABLE [dbo].[LogErro] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of LogErro
-- ----------------------------

-- ----------------------------
-- Table structure for Pedido
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedido]') AND type IN ('U'))
	DROP TABLE [dbo].[Pedido]
GO

CREATE TABLE [dbo].[Pedido] (
  [IdPedido] int  IDENTITY(1,1) NOT NULL,
  [IdCliente] int  NULL,
  [DataPedido] datetime  NULL,
  [ValorTotal] decimal(18,2)  NULL,
  [Pago] bit  NULL
)
GO

ALTER TABLE [dbo].[Pedido] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Pedido
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Pedido] ON
GO

INSERT INTO [dbo].[Pedido] ([IdPedido], [IdCliente], [DataPedido], [ValorTotal], [Pago]) VALUES (N'4', N'16', N'2023-10-11 12:31:44.390', N'230.40', N'0')
GO

INSERT INTO [dbo].[Pedido] ([IdPedido], [IdCliente], [DataPedido], [ValorTotal], [Pago]) VALUES (N'5', N'16', N'2023-10-11 12:45:18.790', N'80.20', N'0')
GO

INSERT INTO [dbo].[Pedido] ([IdPedido], [IdCliente], [DataPedido], [ValorTotal], [Pago]) VALUES (N'8', N'16', N'2023-10-11 15:02:37.343', N'70.00', N'0')
GO

INSERT INTO [dbo].[Pedido] ([IdPedido], [IdCliente], [DataPedido], [ValorTotal], [Pago]) VALUES (N'9', N'16', N'2023-10-11 15:04:03.673', N'150.20', N'0')
GO

INSERT INTO [dbo].[Pedido] ([IdPedido], [IdCliente], [DataPedido], [ValorTotal], [Pago]) VALUES (N'10', N'15', N'2023-10-11 16:20:27.010', N'20.40', N'0')
GO

SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO


-- ----------------------------
-- Table structure for Permissao
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Permissao]') AND type IN ('U'))
	DROP TABLE [dbo].[Permissao]
GO

CREATE TABLE [dbo].[Permissao] (
  [IdPermissao] tinyint  IDENTITY(1,1) NOT NULL,
  [Permissao] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Permissao] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Permissao
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Permissao] ON
GO

INSERT INTO [dbo].[Permissao] ([IdPermissao], [Permissao]) VALUES (N'1', N'Administrador')
GO

INSERT INTO [dbo].[Permissao] ([IdPermissao], [Permissao]) VALUES (N'2', N'Cliente')
GO

SET IDENTITY_INSERT [dbo].[Permissao] OFF
GO


-- ----------------------------
-- Table structure for Produto
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Produto]') AND type IN ('U'))
	DROP TABLE [dbo].[Produto]
GO

CREATE TABLE [dbo].[Produto] (
  [IdProduto] int  IDENTITY(1,1) NOT NULL,
  [Nome] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Preco] decimal(18,2)  NULL,
  [Descricao] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [IdTipoProduto] int  NULL
)
GO

ALTER TABLE [dbo].[Produto] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Produto
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Produto] ON
GO

INSERT INTO [dbo].[Produto] ([IdProduto], [Nome], [Preco], [Descricao], [IdTipoProduto]) VALUES (N'5', N'calça leg', N'10.20', N'calça feia', N'4')
GO

INSERT INTO [dbo].[Produto] ([IdProduto], [Nome], [Preco], [Descricao], [IdTipoProduto]) VALUES (N'6', N'moletom', N'70.00', N'string', N'5')
GO

SET IDENTITY_INSERT [dbo].[Produto] OFF
GO


-- ----------------------------
-- Table structure for TipoProduto
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoProduto]') AND type IN ('U'))
	DROP TABLE [dbo].[TipoProduto]
GO

CREATE TABLE [dbo].[TipoProduto] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Tipo] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[TipoProduto] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of TipoProduto
-- ----------------------------
SET IDENTITY_INSERT [dbo].[TipoProduto] ON
GO

INSERT INTO [dbo].[TipoProduto] ([Id], [Tipo]) VALUES (N'4', N'Calças')
GO

INSERT INTO [dbo].[TipoProduto] ([Id], [Tipo]) VALUES (N'5', N'BLUSAS')
GO

SET IDENTITY_INSERT [dbo].[TipoProduto] OFF
GO


-- ----------------------------
-- Auto increment value for Cliente
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Cliente]', RESEED, 16)
GO


-- ----------------------------
-- Uniques structure for table Cliente
-- ----------------------------
ALTER TABLE [dbo].[Cliente] ADD CONSTRAINT [UN_CPF] UNIQUE NONCLUSTERED ([CPF] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Cliente
-- ----------------------------
ALTER TABLE [dbo].[Cliente] ADD CONSTRAINT [PK__Cliente__D5946642BA1EBF98] PRIMARY KEY CLUSTERED ([IdCliente])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Endereco
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Endereco]', RESEED, 15)
GO


-- ----------------------------
-- Primary Key structure for table Endereco
-- ----------------------------
ALTER TABLE [dbo].[Endereco] ADD CONSTRAINT [PK__Endereco__0B7C7F171B8019CA] PRIMARY KEY CLUSTERED ([IdEndereco])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Estoque
-- ----------------------------
ALTER TABLE [dbo].[Estoque] ADD CONSTRAINT [PK__Estoque__2E883C23B5AC6755] PRIMARY KEY CLUSTERED ([IdProduto])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Item
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Item]', RESEED, 15)
GO


-- ----------------------------
-- Primary Key structure for table Item
-- ----------------------------
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK__Item__51E84262A7C86674] PRIMARY KEY CLUSTERED ([IdItem])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table LogErro
-- ----------------------------
ALTER TABLE [dbo].[LogErro] ADD CONSTRAINT [PK__LogErro__0C54DBC651FBC885] PRIMARY KEY CLUSTERED ([IdLog])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Pedido
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Pedido]', RESEED, 10)
GO


-- ----------------------------
-- Primary Key structure for table Pedido
-- ----------------------------
ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [PK__Pedido__9D335DC3254C024B] PRIMARY KEY CLUSTERED ([IdPedido])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Permissao
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Permissao]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table Permissao
-- ----------------------------
ALTER TABLE [dbo].[Permissao] ADD CONSTRAINT [PK__Permissa__356F319ACEB83055] PRIMARY KEY CLUSTERED ([IdPermissao])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Produto
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Produto]', RESEED, 6)
GO


-- ----------------------------
-- Primary Key structure for table Produto
-- ----------------------------
ALTER TABLE [dbo].[Produto] ADD CONSTRAINT [PK__Produto__2E883C231CC72B34] PRIMARY KEY CLUSTERED ([IdProduto])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for TipoProduto
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TipoProduto]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table TipoProduto
-- ----------------------------
ALTER TABLE [dbo].[TipoProduto] ADD CONSTRAINT [PK__TipoProd__F71CDF6118F6A073] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Cliente
-- ----------------------------
ALTER TABLE [dbo].[Cliente] ADD CONSTRAINT [FK_Permissao] FOREIGN KEY ([IdPermissao]) REFERENCES [dbo].[Permissao] ([IdPermissao]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Endereco
-- ----------------------------
ALTER TABLE [dbo].[Endereco] ADD CONSTRAINT [PK_IdClienteEnd] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([IdCliente]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Estoque
-- ----------------------------
ALTER TABLE [dbo].[Estoque] ADD CONSTRAINT [FK_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [dbo].[Produto] ([IdProduto]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Item
-- ----------------------------
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [dbo].[Pedido] ([IdPedido]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [dbo].[Produto] ([IdProduto]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Pedido
-- ----------------------------
ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [PK_IdClientePedido] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([IdCliente]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Produto
-- ----------------------------
ALTER TABLE [dbo].[Produto] ADD CONSTRAINT [FK_IDTIPOPRODUTO] FOREIGN KEY ([IdTipoProduto]) REFERENCES [dbo].[TipoProduto] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

