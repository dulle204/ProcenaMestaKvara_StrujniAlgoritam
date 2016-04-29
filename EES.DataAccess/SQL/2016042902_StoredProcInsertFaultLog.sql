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
		@Timestamp DATETIME
	AS
		INSERT INTO dbo.[FaultLog] values (@PrimaryLocations, @SecondaryLocations, @Timestamp);
	GO
    
    