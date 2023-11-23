using System.Windows;
using System.Windows.Shapes;
using BlazorComponent;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Path = System.IO.Path;

namespace Masa.Blazor.Pro.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        BlazorWeb.HostPage = "wwwroot/index.html";
        BlazorWeb.RootComponents.Add(new RootComponent()
        {
            Selector = "#app",
            ComponentType = typeof(Rcl.App)
        });
        
        
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
#if DEBUG
        serviceCollection.AddBlazorWebViewDeveloperTools();
#endif
        serviceCollection.AddMasaBlazor(builder =>
        {
            builder.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Primary = "#4318FF";
                theme.Themes.Light.Accent = "#4318FF";
            });
        }).AddI18nForServer(Path.Combine("wwwroot", "i18n"));

        serviceCollection.AddGlobalForServer();
        
        Resources.Add("services", serviceCollection.BuildServiceProvider());
        
        
    }
}