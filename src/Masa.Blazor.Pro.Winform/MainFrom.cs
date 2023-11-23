using Masa.Blazor.Pro.Rcl;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace Masa.Blazor.Pro.Winform;

public partial class MainFrom : Form
{
    public MainFrom()
    {
        InitializeComponent();

        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        
#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif

        services.AddMasaBlazor(builder =>
        {
            builder.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Primary = "#4318FF";
                theme.Themes.Light.Accent = "#4318FF";
            });
        }).AddI18nForServer(Path.Combine("wwwroot", "i18n"));

        services.AddGlobalForServer();

        blazorWebView1.HostPage = "wwwroot/index.html";
        blazorWebView1.Services = services.BuildServiceProvider();
        blazorWebView1.RootComponents.Add<App>("#app");
    }
}