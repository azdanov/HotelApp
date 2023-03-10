using System;
using System.Collections.Generic;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data;

public interface IDatabaseData
{
    List<RoomTypeModel> GetAvailableRoomTypes(DateTime checkInDate, DateTime checkOutDate);

    void BookGuest(string firstName, string lastName, DateTime checkInDate, DateTime checkOutDate,
        int roomTypeId);

    List<BookingFullModel> SearchBookings(string lastName);

    void CheckInGuest(int bookingId);

    RoomTypeModel? GetRoomTypeById(int roomTypeId);
}