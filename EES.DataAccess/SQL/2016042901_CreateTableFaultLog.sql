

IF( NOT EXISTS( SELECT * FROM sys.databases WHERE name = 'EES'))
BEGIN 
	CREATE DATABASE [EES]
END

USE [EES]
GO
IF( NOT EXISTS( SELECT * FROM sys.tables WHERE name = 'FaultLog'))
BEGIN 
	CREATE TABLE [FaultLog]
	(
	 [ID] BIGINT PRIMARY KEY IDENTITY(1,1),
	 [PrimaryLocations] VARCHAR(100) NULL,
	 [SecondaryLocations] VARCHAR(100) NULL,
	 [TimeStamp] DATETIME NOT NULL
	)	
END

IF( NOT EXISTS( SELECT * FROM sys.tables WHERE name = 'Measurement'))
BEGIN 
	CREATE TABLE [Measurement]
	(
	 [ID] BIGINT PRIMARY KEY IDENTITY(1,1),
	 [FaultID] BIGINT NOT NULL,
	 [Current(A)] DECIMAL(10,2) NOT NULL,
	 [TimeStamp] DATETIME NOT NULL,
	 CONSTRAINT FK_FaultLog FOREIGN KEY ([FaultID]) REFERENCES [FaultLog](ID)
	)
END
