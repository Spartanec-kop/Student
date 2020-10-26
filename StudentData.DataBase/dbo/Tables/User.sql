CREATE TABLE [dbo].[User] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Login]      NVARCHAR (50) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [MiddleName] NVARCHAR (50) NULL,
    [Password]   NCHAR (10)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



