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

 Date: 08/09/2023 23:20:40
*/


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
-- Auto increment value for Endereco
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Endereco]', RESEED, 7)
GO


-- ----------------------------
-- Primary Key structure for table Endereco
-- ----------------------------
ALTER TABLE [dbo].[Endereco] ADD CONSTRAINT [PK__Endereco__0B7C7F171B8019CA] PRIMARY KEY CLUSTERED ([IdEndereco])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Endereco
-- ----------------------------
ALTER TABLE [dbo].[Endereco] ADD CONSTRAINT [PK_IdClienteEnd] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([IdCliente]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

