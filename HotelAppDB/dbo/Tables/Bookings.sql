CREATE TABLE [dbo].[Bookings]
(
    [Id]           INT       NOT NULL IDENTITY,
    [RoomId]       INT       NOT NULL,
    [GuestId]      INT       NOT NULL,
    [CheckedIn]    BIT       NOT NULL DEFAULT 0,
    [CheckInDate]  DATETIME2 NOT NULL,
    [CheckOutDate] DATETIME2 NOT NULL,
    [TotalPrice]   MONEY     NOT NULL,

    CONSTRAINT [PK_Bookings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Bookings_Rooms] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]),
    CONSTRAINT [FK_Bookings_Guests] FOREIGN KEY ([GuestId]) REFERENCES [dbo].[Guests] ([Id]),
    CONSTRAINT [CK_Bookings_CheckInDate_CheckOutDate] CHECK ([CheckInDate] < [CheckOutDate]),
    CONSTRAINT [UQ_Bookings_RoomId_GuestId] UNIQUE ([RoomId], [GuestId]),
    INDEX [IX_Bookings_CheckInDate] NONCLUSTERED ([CheckInDate])
)
