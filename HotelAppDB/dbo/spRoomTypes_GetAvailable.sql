CREATE PROCEDURE dbo.spRoomTypes_GetAvailable 
    @checkInDate DATETIME2,
    @checkOutDate DATETIME2
AS
BEGIN
    SET NOCOUNT ON;

    SELECT rt.Id, rt.Title, rt.Description, rt.Price
    FROM dbo.Rooms r
             INNER JOIN dbo.RoomTypes rt ON rt.Id = r.RoomTypeId
    WHERE r.Id NOT IN
          (SELECT b.RoomId
           FROM dbo.Bookings b
           WHERE (@checkInDate < b.CheckInDate AND @checkOutDate > b.CheckOutDate)
              OR (b.CheckInDate <= @checkOutDate AND b.CheckOutDate >= @checkOutDate)
              OR (b.CheckInDate <= @checkInDate AND b.CheckOutDate >= @checkInDate))
    GROUP BY rt.Id, rt.Title, rt.Description, rt.Price;
END