create Database [DBTask]
go

USE [DBTask]
GO

CREATE TABLE [dbo].[Task](
	[ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[Name] [nvarchar](100) NOT NULL
	)
go
