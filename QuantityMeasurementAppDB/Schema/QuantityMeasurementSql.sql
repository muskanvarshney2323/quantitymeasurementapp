-- Select Database
USE QuantityMeasurementDB;
GO

-- Main Table: Stores all measurement operations
CREATE TABLE MeasurementRecords (
    Id NVARCHAR(50) PRIMARY KEY,
    Timestamp DATETIME2 NOT NULL,
    Operation INT NOT NULL,

    -- Input 1 Details
    Input1Value FLOAT NULL,
    Input1Unit NVARCHAR(25) NULL,
    Input1Type NVARCHAR(25) NULL,

    -- Input 2 Details
    Input2Value FLOAT NULL,
    Input2Unit NVARCHAR(25) NULL,
    Input2Type NVARCHAR(25) NULL,

    -- Conversion Target
    DesiredUnit NVARCHAR(25) NULL,

    -- Source for conversion
    OriginalValue FLOAT NULL,
    OriginalUnit NVARCHAR(25) NULL,
    OriginalType NVARCHAR(25) NULL,

    -- Output
    OutputValue FLOAT NULL,
    OutputUnit NVARCHAR(25) NULL,
    OutputText NVARCHAR(255) NULL,

    -- Status
    SuccessFlag BIT NOT NULL,
    ErrorMessage NVARCHAR(MAX) NULL
);
GO


-- Performance Indexes
CREATE INDEX IDX_Measurement_Timestamp ON MeasurementRecords(Timestamp);
CREATE INDEX IDX_Measurement_Operation ON MeasurementRecords(Operation);
CREATE INDEX IDX_Measurement_Input1Type ON MeasurementRecords(Input1Type);
CREATE INDEX IDX_Measurement_Input2Type ON MeasurementRecords(Input2Type);
CREATE INDEX IDX_Measurement_OriginalType ON MeasurementRecords(OriginalType);
GO


-- Stored Procedure: Summary Report
CREATE PROCEDURE sp_FetchMeasurementReport
AS
BEGIN
    -- Overall Stats
    SELECT 
        COUNT(*) AS TotalCount,
        SUM(CASE WHEN SuccessFlag = 1 THEN 1 ELSE 0 END) AS SuccessCount,
        SUM(CASE WHEN SuccessFlag = 0 THEN 1 ELSE 0 END) AS FailureCount,
        MIN(Timestamp) AS StartTime,
        MAX(Timestamp) AS EndTime,
        COUNT(DISTINCT Input1Type) AS UniqueTypes
    FROM MeasurementRecords;

    -- Operation-wise breakdown
    SELECT 
        Operation,
        COUNT(*) AS TotalPerOperation
    FROM MeasurementRecords
    GROUP BY Operation
    ORDER BY Operation;
END;
GO


-- View: Simplified Data for Reporting
CREATE VIEW vw_OperationOverview AS
SELECT 
    Id,
    Timestamp,
    CASE Operation
        WHEN 0 THEN 'Comparison'
        WHEN 1 THEN 'Conversion'
        WHEN 2 THEN 'Addition'
        WHEN 3 THEN 'Subtraction'
        WHEN 4 THEN 'Division'
    END AS OperationLabel,

    Input1Value,
    Input1Unit,
    Input1Type,

    Input2Value,
    Input2Unit,
    Input2Type,

    OriginalValue,
    OriginalUnit,
    OriginalType,

    DesiredUnit,

    OutputValue,
    OutputUnit,
    OutputText,

    SuccessFlag,
    ErrorMessage
FROM MeasurementRecords;
GO


-- Audit Table (Track changes)
CREATE TABLE MeasurementLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    RecordId NVARCHAR(50) NOT NULL,
    Action NVARCHAR(30) NOT NULL,
    PreviousData NVARCHAR(MAX) NULL,
    UpdatedData NVARCHAR(MAX) NULL,
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    ModifiedBy NVARCHAR(50) NULL
);
GO