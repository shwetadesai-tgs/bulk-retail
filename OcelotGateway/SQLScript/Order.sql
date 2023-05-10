CREATE DATABASE [Orders]

ALTER DATABASE [Orders] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Orders].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Orders] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Orders] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Orders] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Orders] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Orders] SET ARITHABORT OFF 
GO
ALTER DATABASE [Orders] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Orders] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Orders] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Orders] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Orders] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Orders] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Orders] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Orders] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Orders] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Orders] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Orders] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Orders] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Orders] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Orders] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Orders] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Orders] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Orders] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Orders] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Orders] SET  MULTI_USER 
GO
ALTER DATABASE [Orders] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Orders] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Orders] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Orders] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Orders] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Orders] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Orders] SET QUERY_STORE = ON
GO
ALTER DATABASE [Orders] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Orders]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10-05-2023 04:49:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[NetPrice] [decimal](18, 0) NULL,
	[Discount] [int] NULL,
	[EstShippingDate] [datetime] NOT NULL,
	[EstDeliveryDate] [datetime] NOT NULL,
	[ActDeliveryDate] [datetime] NOT NULL,
	[IsCancelProd] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10-05-2023 04:49:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [int] NOT NULL,
	[CustomerId] [nvarchar](50) NOT NULL,
	[Discount] [bigint] NULL,
	[OrderPriceExGST] [decimal](18, 0) NULL,
	[OrderPriceIncGST] [decimal](18, 0) NULL,
	[PaymentModeId] [int] NOT NULL,
	[PaymentTransId] [int] NOT NULL,
	[OrderStatus] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  CONSTRAINT [DF_OrderDetails_IsCancelProd]  DEFAULT ((0)) FOR [IsCancelProd]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  CONSTRAINT [DF_OrderDetails_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]





INSERT INTO [dbo].[Orders]
           ([OrderNumber]
           ,[CustomerId]
           ,[Discount]
           ,[OrderPriceExGST]
           ,[OrderPriceIncGST]
           ,[PaymentModeId]
           ,[PaymentTransId]
           ,[OrderStatus]
           ,[IsDeleted])
     VALUES
           (1,1,10,480,500,1,1,1,0)

INSERT INTO [dbo].[OrderDetails]
           ([OrderId]
           ,[ProductId]
           ,[Quantity]
           ,[Price]
           ,[NetPrice]
           ,[Discount]
           ,[EstShippingDate]
           ,[EstDeliveryDate]
           ,[ActDeliveryDate]
           ,[IsCancelProd]
           ,[IsDeleted])
     VALUES
           (1
           ,1
           ,10
           ,500
           ,500
           ,10
           ,GETDATE()
           ,GETDATE()
           ,GETDATE()
           ,0
           ,0)

