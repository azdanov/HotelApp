CREATE PROCEDURE dbo.spGuests_Insert @firstName VARCHAR(50),
                                     @lastName VARCHAR(50)
AS
BEGIN
    SET XACT_ABORT, NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM dbo.Guests WHERE FirstName = @firstName AND LastName = @lastName)
        BEGIN
            INSERT INTO dbo.Guests (FirstName, LastName)
            VALUES (@firstName, @lastName)
        END

    SELECT Id, FirstName, LastName
    FROM dbo.Guests
    WHERE FirstName = @firstName
      AND LastName = @lastName
END