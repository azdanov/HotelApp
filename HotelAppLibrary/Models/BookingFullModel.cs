using System;

namespace HotelAppLibrary.Models;

public record BookingFullModel(int Id,
    int RoomId,
    int GuestId,
    bool CheckedIn,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    decimal TotalPrice,
    string FirstName,
    string LastName,
    string RoomNumber,
    int RoomTypeId,
    string Title,
    string Description,
    decimal Price
);