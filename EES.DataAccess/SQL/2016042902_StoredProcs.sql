USE [EES]
GO

DECLARE @V VARCHAR(30)
SET @V = 'InsertFaultLog'

IF(EXISTS(SELECT * FROM sys.procedures WHERE name = @V))
BEGIN
	DROP PROCEDURE InsertFaultLog
END
GO
CREATE PROCEDURE InsertFaultLog
		@PrimaryLocations VARCHAR(100) = NULL,
		@SecondaryLocations VARCHAR(100) = NULL,
		@Timestamp DATETIME,
		@Current DECIMAL(10,2) = NULL
	AS
	BEGIN
		INSERT INTO dbo.[FaultLog] values (@PrimaryLocations, @SecondaryLocations, @Timestamp);
		--GO
		DECLARE @FID BIGINT;
		SET @FID = (SELECT TOP 1 ID FROM dbo.[FaultLog] ORDER BY [TimeStamp] DESC);
		INSERT INTO dbo.[Measurement] values (@FID, @Current, @Timestamp);
	END
	
    
    