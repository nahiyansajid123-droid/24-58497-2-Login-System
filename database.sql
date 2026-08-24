IF DB_ID(N'db_users') IS NULL
BEGIN
    CREATE DATABASE db_users;
END
GO

USE db_users;
GO

IF OBJECT_ID(N'dbo.tbl_users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.tbl_users
    (
        id INT IDENTITY(1,1) PRIMARY KEY,
        username NVARCHAR(50) NOT NULL UNIQUE,
        password NVARCHAR(100) NOT NULL
    );
END
GO

IF EXISTS (SELECT 1 FROM dbo.tbl_users WHERE username = N'admin' AND password = N'admin123')
BEGIN
    UPDATE dbo.tbl_users
    SET password = N'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9'
    WHERE username = N'admin';
END
ELSE IF NOT EXISTS (SELECT 1 FROM dbo.tbl_users WHERE username = N'admin')
BEGIN
    INSERT INTO dbo.tbl_users (username, password)
    VALUES (N'admin', N'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9');
END
GO
