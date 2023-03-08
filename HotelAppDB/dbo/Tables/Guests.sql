CREATE TABLE [dbo].[Guests]
(
    [Id]        INT          NOT NULL IDENTITY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName]  NVARCHAR(50) NOT NULL,

    CONSTRAINT [PK_Guests] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Guests_FirstName_LastName] UNIQUE ([FirstName], [LastName])
)
