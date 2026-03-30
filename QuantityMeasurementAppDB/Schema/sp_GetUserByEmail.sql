USE QuantityMeasurementDB;
GO

CREATE PROCEDURE sp_GetUserByEmail
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Email, PasswordHash, IsGoogleUser, CreatedAt
    FROM Users
    WHERE Email = @Email;
END
GO