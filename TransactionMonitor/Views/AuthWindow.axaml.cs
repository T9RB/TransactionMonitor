using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CovalentSDK.Covalent;
using Newtonsoft.Json.Linq;
using TransactionMonitor.ViewModels;

namespace TransactionMonitor.Views;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
        
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        this.CanResize = false;
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    
}