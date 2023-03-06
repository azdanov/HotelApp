using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace HotelAppLibrary.Data
{
    public class SqlDataLayer
    {
        private const string ConnectionStringName = "SqlDb";
        private readonly SqlDataAccess _db;

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
    }
}
