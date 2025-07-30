using Imobi3DApp.Database;
using Microsoft.Extensions.Logging;

namespace Imobi3DApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "imobi3d.db3");
        builder.Services.AddSingleton(s => new AppDbContext(dbPath));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
