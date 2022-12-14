using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TransactionMonitor.Views;

public partial class ProfileWindow : Window
{
    public ProfileWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}