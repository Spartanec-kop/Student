CREATE TABLE [dbo].[Students] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Sex]        BIT           NOT NULL,
    [LastName]   NVARCHAR (40) NOT NULL,
    [Name]       NVARCHAR (40) NOT NULL,
    [MiddleName] NVARCHAR (60) NULL,
    [NickName]   NVARCHAR (16) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

