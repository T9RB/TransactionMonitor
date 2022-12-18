using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CovalentSDK.Covalent;
using DynamicData.Binding;
using Microsoft.VisualBasic;
using ReactiveUI;

namespace TransactionMonitor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Tokens> TokensList { get; } = new();
        public MainWindowViewModel()
        {
            
        }

        public void Tokens_Add_Col(string Network, string Wallet)
        {
            CovalentMethods cm = new CovalentMethods();
            TokenListViewModel tokenListViewModel = new TokenListViewModel();
            Service sr = new Service();
            var Tokens = cm.GetTokenBalanceForAddress(Network, Wallet);
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
            }
        }

    }
}