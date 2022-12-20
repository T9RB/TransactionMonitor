using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using CovalentSDK.Covalent;
using ReactiveUI;

namespace TransactionMonitor.ViewModels;

public class AuthViewModel : ViewModelBase
{
    private Networks _selNetworks;
    private Protocols _selProtocols;
    public ObservableCollection<Networks> Networks { get; } = new();
    public ObservableCollection<Protocols> ProtocolsList { get; } = new();

    public AuthViewModel()
    {
        Service sr = new Service();
        LoadChains();

        ShowDialog = new Interaction<MainWindowViewModel, TokenListViewModel?>();
        LoadProtocols = ReactiveCommand.Create(() =>
        {
            ProtocolsList.Clear();
            if (Selected_Network != null)
            {
                try
                {
                    CovalentMethods cm = new CovalentMethods();
                    var deXes = cm.GetSupporteDEXes();
        
                    var id = " ";
                    var dex_name = " ";

                    var selected_dexes =
                        from dex in deXes["data"]["items"]
                        select new
                        {
                            id = (string)dex["chain_id"],
                            dex_name = (string)dex["dex_name"]
                        };
                    if (Selected_Network != null)
                    {
                        foreach (var value in selected_dexes)
                        {
                            if (value.id == " " || value.dex_name == " ")
                            {
                                continue;
                            }
                            else
                            {
                                if (Selected_Network.Id == value.id)
                                {
                                    ProtocolsList.Add(new Protocols() {ChainId = value.id, NameProtocol = value.dex_name});
                                }
                                else
                                {
                                    continue;
                                }
                            
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    
                }
            }

        });
        Authorization = ReactiveCommand.CreateFromTask(async () =>
        {
            Service sr = new Service();
            string nt = Selected_Network.Id;
            bool auth_status = sr.Authorization(wallet_address, nt);
            if (auth_status == true)
            {
                var mainwin = new MainWindowViewModel();
                mainwin.Tokens_Add_Col(Selected_Network.Id, wallet_address);
                mainwin.LoadData(Selected_Network.Id, Selected_Protocols.NameProtocol);

                await ShowDialog.Handle(mainwin);
            }
        });
        
        
    }

    public void LoadChains()
    {
        CovalentMethods cm = new CovalentMethods();
        var chain = cm.GetAllChain();

        try
        {
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
        catch (Exception e)
        {
           
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

    public Protocols Selected_Protocols
    {
        get => _selProtocols;
        set
        {
            _selProtocols = value;
            OnPropertyChanged();
        }
    }
    public ICommand Authorization { get; }
    public ICommand LoadProtocols { get; }
    
    public Interaction<MainWindowViewModel, TokenListViewModel?> ShowDialog { get; }

}
    

    
