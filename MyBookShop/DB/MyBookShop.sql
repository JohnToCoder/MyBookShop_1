CREATE DATABASE MyBookShop
GO

USE MyBookShop
GO

CREATE TABLE [dbo].[Cart] (
	[CartId] [int] IDENTITY (1, 1) NOT NULL ,
	[UserId] [int] NULL ,
	[BookId] [int] NULL ,
	[Amount] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Book] (
	[BookId] [int] IDENTITY (1, 1) NOT NULL ,
	[BookName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[CategoryID] [int] NULL ,
	[Price] [float] NULL ,
	[Publisher] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[PublishDate] [datetime] NULL ,
	[Author] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[PageNum] [int] NULL ,
	[PictureUrl] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Description] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[SaleCount] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Category] (
	[CategoryID] [int] IDENTITY (1, 1) NOT NULL ,
	[CategoryName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[User] (
	[UserId] [int] IDENTITY (1, 1) NOT NULL ,
	[LoginName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[UserName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Password] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Address] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[Zip] [char] (10) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

Insert Into Category(CategoryName) Values ('中外文学')
Insert Into Category(CategoryName) Values ('政治经济')
Insert Into Category(CategoryName) Values ('学术名著')
Insert Into Category(CategoryName) Values ('IT技术')
GO