using Imobi3DApp.Database;
using Imobi3DApp.ViewModels;
using Imobi3DApp.Views;
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

        // Registro das Views e ViewModels para Injeção de Dependência
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomeViewModel>();

        // Registre NewImovelPage e sua ViewModel futuramente
        // builder.Services.AddTransient<NewImovelPage>();
        // builder.Services.AddTransient<NewImovelViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
