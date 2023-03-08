CREATE TABLE [dbo].[Rooms]
(
    [Id]         INT         NOT NULL IDENTITY,
    [RoomNumber] VARCHAR(10) NOT NULL,
    [RoomTypeId] INT         NOT NULL,

    CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rooms_RoomTypes] FOREIGN KEY ([RoomTypeId]) REFERENCES [dbo].[RoomTypes] ([Id]),
    CONSTRAINT [UQ_Rooms_RoomNumber] UNIQUE ([RoomNumber])
)