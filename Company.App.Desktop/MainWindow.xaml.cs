using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Company.App.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();

        // Register HttpClient so shared components (e.g. Weather) can inject it
        serviceCollection.AddScoped(_ => new HttpClient
        {
            BaseAddress = new Uri("https://localhost/")
        });

        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }
}
