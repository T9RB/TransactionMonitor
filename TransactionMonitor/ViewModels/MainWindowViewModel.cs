using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using CovalentSDK.Covalent;
using ReactiveUI;

namespace TransactionMonitor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Tokens> TokensList { get; } = new();
        public ObservableCollection<Transaction> TransactionsList { get; } = new();
        public ObservableCollection<ActivePoolsByAddress> ActivePoolsByAddresses { get; } = new();

        public MainWindowViewModel()
        {
            ShowDialog = new Interaction<ProfileViewModel, TransactionWithProtocolViewModel?>();
            AddPoolsList = ReactiveCommand.Create(() =>
            {
                CovalentMethods cm = new CovalentMethods();
                AuthViewModel authViewModel = new AuthViewModel();
                Service sr = new Service();
                var ActivePools = cm.GetPoolsByAddress(ChainId, Name_Protocol,
                    PoolAddress);
                try
                {
                    var dex_name = " ";
                    var total_suply = " ";
                    var total_liquidity_quote = " ";

                    var SelPools =
                        from pools in ActivePools["data"]["items"]
                        select new
                        {
                            dex_name = (string)pools["dex_name"],
                            total_liquidity_quote = (string)pools["total_liquidity_quote"],
                            total_suply = (string)pools["total_supply"]
                        };
                    foreach (var value in SelPools)
                    {
                        ActivePoolsByAddresses.Add(new ActivePoolsByAddress()
                            {Dex_Name = value.dex_name,Total_Quote = value.total_liquidity_quote, Total_Suply = value.total_suply});
                    }
                }
                catch (Exception e)
                {
                    
                }
            });
            GoToProfile = ReactiveCommand.CreateFromTask(async () =>
            {
                var profilewindow = new ProfileViewModel();
                profilewindow.LoadData(ChainId, Name_Protocol, Address_Wallet);
                profilewindow.LoadCollection();

                await ShowDialog.Handle(profilewindow);
            });
        }

        public void Tokens_Add_Col(string Network, string Wallet)
        {
            CovalentMethods cm = new CovalentMethods();
            Service sr = new Service();
            Address_Wallet = Wallet;
            var Tokens = cm.GetTokenBalanceForAddress(Network, Wallet);
            var Transaction = cm.GetTransactionForAddress(Network, Wallet);

            try
            {
                var name = " ";
                var balance = " ";
                var Token_Sel =
                    from c in Tokens["data"]["items"]
                    select new
                    {
                        name = (string) c["contract_ticker_symbol"],
                        balance = (string) c["balance"]
                    };
                foreach (var value in Token_Sel)
                {
                    if (value.balance == "0" || value.name == " ")
                    {
                        continue;
                    }
                    else
                    {
                        TokensList.Add(new Tokens() {Name_token = value.name, Balance = value.balance});
                    }
                }
                var hash = " ";
                var successful = " ";
                var valuetr = " ";
                var Transactions =
                    from c in Transaction["data"]["items"]
                    select new
                    {
                        hash = (string)c["tx_hash"],
                        successful = (string)c["successful"],
                        valuetr= (string)c["value"]
                        
                    };
                foreach (var transaction in Transactions)
                {
                    if (transaction.valuetr == "0")
                    {
                        continue;
                    }
                    else
                    {
                        TransactionsList.Add(new Transaction(){Hash = transaction.hash, Successful = transaction.successful, ValueTransaction = transaction.valuetr});
                    }
                   
                }
            }
            catch (Exception e)
            {
                
            }
        }

        public void LoadData(string chainId, string dex)
        {
            ChainId = chainId;
            
            Name_Protocol = dex;
        }
        public string PoolAddress { get; set; }
        public string ChainId { get; set; }
        public string Name_Protocol { get; set; }
        public string Address_Wallet { get; set; }
        public ICommand AddPoolsList { get; }
        public ICommand GoToProfile { get; }
        
        public Interaction<ProfileViewModel, TransactionWithProtocolViewModel?> ShowDialog { get; }
    }
}