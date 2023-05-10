USE [ProductDB]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 10-05-2023 23:38:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[MOQ] [int] NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[LastPrice] [decimal](18, 2) NULL,
	[CostPrice] [decimal](18, 2) NULL,
	[MinSalePrice] [decimal](18, 2) NULL,
	[DiscountType] [nvarchar](max) NOT NULL,
	[DiscountValue] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


