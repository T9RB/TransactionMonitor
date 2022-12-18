using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CovalentSDK.Covalent;
using Newtonsoft.Json.Linq;
using ReactiveUI;
using TransactionMonitor.ViewModels;

namespace TransactionMonitor.Views;

public partial class AuthWindow : ReactiveWindow<AuthViewModel>
{
    public AuthWindow()
    {
        InitializeComponent();
        this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<MainWindowViewModel, TokenListViewModel?> interaction)
    {
        var dialog = new MainWindow();
        dialog.DataContext = interaction.Input;
        var result = await dialog.ShowDialog<TokenListViewModel>(this);    
        interaction.SetOutput(result);
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        this.CanResize = false;
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }
    

    
}