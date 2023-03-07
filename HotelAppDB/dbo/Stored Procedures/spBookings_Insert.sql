CREATE PROCEDURE dbo.spBookings_Insert @roomId INT,
                                       @guestId INT,
                                       @checkInDate DATETIME,
                                       @checkOutDate DATETIME,
                                       @totalPrice MONEY
AS
BEGIN
    SET XACT_ABORT, NOCOUNT ON;

    INSERT INTO dbo.Bookings (RoomId, GuestId, CheckInDate, CheckOutDate, TotalPrice)
    VALUES (@roomId, @guestId, @checkInDate, @checkOutDate, @totalPrice);
END
