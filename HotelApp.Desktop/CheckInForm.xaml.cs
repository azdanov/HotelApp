using System;
using System.Globalization;
using System.Windows;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;

namespace HotelApp.Desktop;

/// <summary>
///     Interaction logic for CheckInForm.xaml
/// </summary>
public partial class CheckInForm : Window
{
    private readonly IDatabaseData _db;
    private readonly IFormatProvider _formatProvider;
    private BookingFullModel _data = null!;

    public CheckInForm(IDatabaseData db, IFormatProvider formatProvider)
    {
        _db = db;
        _formatProvider = formatProvider;
        InitializeComponent();
    }

    public void PopulateCheckInInfo(BookingFullModel data)
    {
        _data = data;
        FirstNameText.Text = _data.FirstName;
        LastNameText.Text = _data.LastName;
        TitleText.Text = _data.Title;
        RoomNumberText.Text = _data.RoomNumber;
        TotalPriceText.Text = _data.TotalPrice.ToString("C", _formatProvider);
    }

    private void CheckInUser_OnClick(object sender, RoutedEventArgs e)
    {
        _db.CheckInGuest(_data.Id);
        Close();
    }
}