using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.Desktop;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IDatabaseData _db;

    public MainWindow(IDatabaseData db)
    {
        _db = db;
        InitializeComponent();
    }

    private void SearchForGuest_OnClick(object sender, RoutedEventArgs e)
    {
        // TODO: Filter should be done in DB?
        var bookings = _db.SearchBookings(LastNameText.Text).FindAll(model => model.CheckedIn == false);
        ResultsList.ItemsSource = bookings;
    }

    private void LastNameText_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            SearchForGuest_OnClick(this, new RoutedEventArgs());
        }
    }

    private void CheckInButton_OnClick(object sender, RoutedEventArgs e)
    {
        var checkInForm = App.ServiceProvider.GetService<CheckInForm>()!;
        var model = (BookingFullModel)((Button)e.Source).DataContext;

        if (model is null)
        {
            MessageBox.Show("No guest selected.");
            return;
        }

        checkInForm.PopulateCheckInInfo(model);
        checkInForm.Show();
    }
}