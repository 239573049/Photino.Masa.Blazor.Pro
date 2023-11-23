using Masa.Blazor.Pro.Rcl;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;

namespace Masa.Blazor.Pro.Photino;

internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.RootComponents.Add<App>("#app");
        appBuilder.Services.AddMasaBlazor();

        appBuilder.Services.AddMasaBlazor(builder =>
        {
            builder.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Primary = "#4318FF";
                theme.Themes.Light.Accent = "#4318FF";
            });
        }).AddI18nForServer(Path.Combine("wwwroot", "i18n"));

        appBuilder.Services.AddGlobalForServer();
        var app = appBuilder.Build();

        app.MainWindow
            .SetTitle("Photino Blazor Sample");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) => { };

        app.Run();
    }
}