using System;
using System.Globalization;
using System.IO;
using System.Windows;
using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.Desktop;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ServiceProvider ServiceProvider { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        services.AddTransient<MainWindow>();
        services.AddTransient<CheckInForm>();
        services.AddTransient<ISqlDataAccess, SqlDataAccess>();
        services.AddTransient<IDatabaseData, SqlData>();
        services.AddSingleton(BuildConfiguration());

        var culture = new CultureInfo("et-EE");
        services.AddSingleton<IFormatProvider>(culture);

        ServiceProvider = services.BuildServiceProvider();
        var mainWindow = ServiceProvider.GetService<MainWindow>();

        mainWindow?.Show();
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}