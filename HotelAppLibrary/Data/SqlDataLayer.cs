using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelAppLibrary.Data;

public class SqlDataLayer
{
    private const string ConnectionStringName = "SqlDb";
    private readonly ISqlDataAccess _db;

    public SqlDataLayer(IConfiguration config)
    {
        _db = new SqlDataAccess(config);
    }

    public List<RoomTypeModel> GetAvailableRoomTypes(DateTime checkInDate, DateTime checkOutDate)
    {
        return _db.LoadData<RoomTypeModel, dynamic>(
            "dbo.spRoomTypes_GetAvailable",
            new { checkInDate, checkOutDate },
            ConnectionStringName,
            new DataAccessOptions(IsStoredProcedure: true)
        );
    }

    public void BookGuest(string firstName, string lastName, DateTime checkInDate, DateTime checkOutDate,
        int roomTypeId)
    {
        GuestModel guest = _db.LoadData<GuestModel, dynamic>(
            "dbo.spGuests_Insert",
            new { firstName, lastName },
            ConnectionStringName,
            new DataAccessOptions(IsStoredProcedure: true)
        ).First();

        RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>(
            "SELECT Id, Title, Description, Price FROM dbo.RoomTypes WHERE Id = @roomTypeId",
            new { roomTypeId },
            ConnectionStringName
        ).First();

        TimeSpan stayLength = checkOutDate.Date.Subtract(checkInDate.Date);

        List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>(
            "dbo.spRooms_GetAvailable",
            new { checkInDate, checkOutDate, roomTypeId },
            ConnectionStringName,
            new DataAccessOptions(IsStoredProcedure: true)
        );

        _db.SaveData(
            "dbo.spBookings_Insert",
            new
            {
                roomId = availableRooms.First().Id,
                guestId = guest.Id,
                checkInDate,
                checkOutDate,
                totalCost = roomType.Price * stayLength.Days
            },
            ConnectionStringName,
            new DataAccessOptions(IsStoredProcedure: true)
        );
    }
}