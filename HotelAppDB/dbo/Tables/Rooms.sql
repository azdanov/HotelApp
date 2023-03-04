﻿CREATE TABLE [dbo].[Rooms]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[RoomNumber] VARCHAR(10) NOT NULL, 
	[RoomTypeId] INT NOT NULL, 
	[IsAvailable] BIT NOT NULL DEFAULT 1,
	CONSTRAINT [FK_Rooms_RoomTypes] FOREIGN KEY ([RoomTypeId]) REFERENCES [dbo].[RoomTypes] ([Id]) 
)
