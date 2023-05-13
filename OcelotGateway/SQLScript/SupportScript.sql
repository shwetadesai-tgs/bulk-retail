CREATE TABLE [dbo].[SupportCategory](
	[SupportCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[SupportCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Supports](
	[SupportId] [int] IDENTITY(1,1) NOT NULL,
	[SupportCategoryId] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Subject] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Status] [int] NULL
CONSTRAINT [PK_Supports] PRIMARY KEY CLUSTERED 
(
	[SupportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
insert into SupportCategory values ('I want to track my order');
go
insert into SupportCategory values ('I want help with other issues');
go
insert into SupportCategory values ('I want to return & refund my order');
go
insert into SupportCategory values ('I have a questions regarding products');
go
insert into SupportCategory values ('I want to cancel my order');
go


