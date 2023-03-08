CREATE TABLE [dbo].[RoomTypes]
(
    [Id]          INT            NOT NULL IDENTITY,
    [Title]       NVARCHAR(50)   NOT NULL,
    [Description] NVARCHAR(2000) NOT NULL,
    [Price]       MONEY          NOT NULL,

    CONSTRAINT [PK_RoomTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_RoomTypes_Title] UNIQUE ([Title])
)
