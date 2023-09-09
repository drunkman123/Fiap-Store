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

 Date: 08/09/2023 23:21:17
*/


-- ----------------------------
-- Table structure for TipoProduto
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoProduto]') AND type IN ('U'))
	DROP TABLE [dbo].[TipoProduto]
GO

CREATE TABLE [dbo].[TipoProduto] (
  [IdTipoProduto] int  IDENTITY(1,1) NOT NULL,
  [TipoProduto] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[TipoProduto] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for TipoProduto
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[TipoProduto]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table TipoProduto
-- ----------------------------
ALTER TABLE [dbo].[TipoProduto] ADD CONSTRAINT [PK__TipoProd__F71CDF6118F6A073] PRIMARY KEY CLUSTERED ([IdTipoProduto])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

