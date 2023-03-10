CREATE PROCEDURE dbo.spRoomTypes_GetById(
    @roomTypeId INT
) AS
BEGIN
    SET XACT_ABORT, NOCOUNT ON;

    SELECT rt.Id, rt.Title, rt.Description, rt.Price
    FROM dbo.RoomTypes rt
    WHERE rt.Id = @roomTypeId;
END