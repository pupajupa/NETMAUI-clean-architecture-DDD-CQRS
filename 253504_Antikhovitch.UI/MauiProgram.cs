using _253504_Antikhovitch.Application;
using _253504_Antikhovitch.Persistense;
using _253504_Antikhovitch.Persistense.Data;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace _253504_Antikhovitch.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "_253504_Antikhovitch.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("ionicons.ttf", "ionicons");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            builder.Services
                .AddApplication()
                .AddPersistence(options)
                .RegisterPages()
                .RegisterViewModels();

            DbInitializer
                .Initialize(builder.Services.BuildServiceProvider())
                .Wait();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
