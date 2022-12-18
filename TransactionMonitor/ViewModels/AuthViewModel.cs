using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CovalentSDK.Covalent;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using ReactiveUI;
using TransactionMonitor.Views;

namespace TransactionMonitor.ViewModels;

public class AuthViewModel : ViewModelBase
{
    private Networks _selNetworks;
    public ObservableCollection<Networks> Networks { get; } = new();

    public AuthViewModel()
    {
        LoadChains();

        ShowDialog = new Interaction<MainWindowViewModel, TokenListViewModel?>();
        Authorization = ReactiveCommand.CreateFromTask(async () =>
        {
            Service sr = new Service();
            string nt = Selected_Network.Id;
            bool auth_status = sr.Authorization(wallet_address, nt);
            if (auth_status == true)
            {
                var mainwin = new MainWindowViewModel();
                mainwin.Tokens_Add_Col(Selected_Network.Id, wallet_address);
                await ShowDialog.Handle(mainwin);
            }
            
            if (auth_status == false)
            {
                sr.MessageBoxShow("Предупреждение","Неверные данные! Повторите попытку");
            }
            
        });
        
        
    }

    public void LoadChains()
    {
        CovalentMethods cm = new CovalentMethods();
        var chain = cm.GetAllChain();

        var ids = " ";
        var label = " ";
        var chains =
            from c in chain["data"]["items"]
            select new
            {
                ids = (string)c["chain_id"],
                label = (string)c["label"]
            };
        foreach (var value in chains)
        {
            if (value.ids == " " || value.label == " ")
            {
                continue;
            }
            else
            {
                Networks.Add(new Networks() {Name = value.label, Id = value.ids});
            }
            
        }
    }
    
    public string wallet_address { get; set; }

    public Networks Selected_Network
    {
        get => _selNetworks;
        set
        {
            _selNetworks = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand Authorization { get; }
    
    public Interaction<MainWindowViewModel, TokenListViewModel?> ShowDialog { get; }

}
    

    
