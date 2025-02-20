using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
namespace MyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
 
#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<DetailsViewModel>();

            builder.Services.AddSingleton<FormPage>();
            builder.Services.AddSingleton<FormViewModel>();

            builder.Services.AddTransient<JSONServices>();

            builder.Services.AddTransient<ChartsPage>();

            builder.Services.AddTransient<DbPage>();
            builder.Services.AddTransient<DbViewModel>();

            builder.Services.AddTransient<TestPage>();
            builder.Services.AddTransient<TestViewModel>();

            builder.Services.AddTransientPopup<PopUpPage, PopUpViewModel>();

            builder.Services.AddSingleton<ExportToCsv>();
            builder.Services.AddSingleton<ExportToCsvViewModel>();

            builder.Services.AddTransient<ChartsPage>();
            builder.Services.AddTransient<ChartsViewModel>();
 

            builder.Services.AddDbContext<DataAccessService>(e => e.UseSqlServer(
               $"Server=localhost\\SQLEXPRESS;Database=MAUI_PROJECT;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"));

            return builder.Build();
        }
    }
}
