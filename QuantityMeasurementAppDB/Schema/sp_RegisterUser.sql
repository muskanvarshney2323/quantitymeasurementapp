USE QuantityMeasurementDB;
GO

CREATE PROCEDURE sp_RegisterUser
    @Id NVARCHAR(50),
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @PasswordHash NVARCHAR(MAX),
    @IsGoogleUser BIT,
    @CreatedAt DATETIME2
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Users (Id, Name, Email, PasswordHash, IsGoogleUser, CreatedAt)
    VALUES (@Id, @Name, @Email, @PasswordHash, @IsGoogleUser, @CreatedAt);
END
GO