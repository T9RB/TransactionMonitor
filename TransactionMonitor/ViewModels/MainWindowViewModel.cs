using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using CovalentSDK.Covalent;
using DynamicData.Binding;
using Microsoft.VisualBasic;
using ReactiveUI;
using TransactionMonitor.Views;

namespace TransactionMonitor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Tokens> TokensList { get; } = new();
        public ObservableCollection<Transaction> TransactionsList { get; } = new();
        public MainWindowViewModel()
        {
            AuthViewModel authViewModel = new AuthViewModel();
        }

        public void Tokens_Add_Col(string Network, string Wallet)
        {
            CovalentMethods cm = new CovalentMethods();
            Service sr = new Service();
            var Tokens = cm.GetTokenBalanceForAddress(Network, Wallet);
            var Transaction = cm.GetTransactionForAddress(Network, Wallet);
            if (Tokens == null)
            {
                sr.MessageBoxShow("Предупреждение", "Вы ввели неверные данные");
            }
            else
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
        }

    }
}