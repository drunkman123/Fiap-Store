/*
 Navicat Premium Data Transfer

 Source Server         : Conexão Local FiapStore
 Source Server Type    : SQL Server
 Source Server Version : 16001000
 Source Host           : localhost:1433
 Source Catalog        : fiapStore
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000
 File Encoding         : 65001

 Date: 08/09/2023 23:20:48
*/


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
  [Preco] decimal(18)  NULL,
  [SubTotal] decimal(18)  NULL
)
GO

ALTER TABLE [dbo].[Item] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for Item
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Item]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Item
-- ----------------------------
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK__Item__51E84262A7C86674] PRIMARY KEY CLUSTERED ([IdItem])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Item
-- ----------------------------
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [dbo].[Pedido] ([IdPedido]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Item] ADD CONSTRAINT [PK_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [dbo].[Produto] ([IdProduto]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

