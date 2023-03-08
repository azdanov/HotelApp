CREATE PROCEDURE dbo.spBookings_Search(
    @lastName NVARCHAR(50),
    @checkInDate DATETIME2
) AS
BEGIN
    SET XACT_ABORT, NOCOUNT ON;

    SELECT b.Id,
           b.RoomId,
           b.GuestId,
           b.CheckedIn,
           b.CheckInDate,
           b.CheckOutDate,
           b.TotalPrice,
           g.FirstName,
           g.LastName,
           r.RoomNumber,
           r.RoomTypeId,
           rt.Title,
           rt.Description,
           rt.Price
    FROM dbo.Bookings b
             INNER JOIN Guests g ON g.Id = b.GuestId
             INNER JOIN Rooms r ON r.Id = b.RoomId
             INNER JOIN dbo.RoomTypes rt ON rt.Id = r.RoomTypeId
    WHERE g.LastName = @lastName
      AND CONVERT(DATE, b.CheckInDate) = CONVERT(DATE, @checkInDate);
END
