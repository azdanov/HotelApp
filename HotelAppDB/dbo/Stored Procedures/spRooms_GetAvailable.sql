CREATE PROCEDURE dbo.spRooms_GetAvailable @checkInDate DATETIME2,
                                          @checkOutDate DATETIME2,
                                          @roomTypeId INT
AS
BEGIN
    SET XACT_ABORT, NOCOUNT ON;

    SELECT r.Id, r.RoomNumber, r.RoomTypeId
    FROM dbo.Rooms r
             INNER JOIN dbo.RoomTypes rt ON rt.Id = r.RoomTypeId
    WHERE r.RoomTypeId = @roomTypeId
      AND r.Id NOT IN
          (SELECT b.RoomId
           FROM dbo.Bookings b
           WHERE (@checkInDate < b.CheckInDate AND @checkOutDate > b.CheckOutDate)
              OR (b.CheckInDate <= @checkOutDate AND b.CheckOutDate >= @checkOutDate)
              OR (b.CheckInDate <= @checkInDate AND b.CheckOutDate >= @checkInDate));
END