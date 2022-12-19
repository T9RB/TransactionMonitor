using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CovalentSDK.Covalent;
using ReactiveUI;
using TransactionMonitor.ViewModels;

namespace TransactionMonitor.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }
        private async Task DoShowDialogAsync(InteractionContext<ProfileViewModel, TransactionWithProtocolViewModel?> interaction)
        {
            var dialog = new ProfileWindow();
            dialog.DataContext = interaction.Input;
            var result = await dialog.ShowDialog<TransactionWithProtocolViewModel>(this);    
            interaction.SetOutput(result);
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.CanResize = false;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}