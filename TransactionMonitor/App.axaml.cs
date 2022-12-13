using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TransactionMonitor.ViewModels;
using TransactionMonitor.Views;
using System.Windows;
using Avalonia.Controls;

namespace TransactionMonitor
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new AuthWindow
                {
                    DataContext = new AuthViewModel(),
                };
                

            }

            base.OnFrameworkInitializationCompleted();
        }
        
        
    }
}