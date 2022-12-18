using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CovalentSDK.Covalent;
using ReactiveUI;

namespace TransactionMonitor.ViewModels;

public class TokenListViewModel
{
    //public string token_name { get; set; }
    

    public TokenListViewModel()
    {
       
    }
    /*public void Tokens_Add_Col(string Network, string Wallet)
    {
        CovalentMethods cm = new CovalentMethods();
        Service sr = new Service();
        var Tokens = cm.GetTokenBalanceForAddress(Network, Wallet);

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
            TokensList.Add(new Tokens() {Name_token = value.name, Balance = value.balance});
        }
    }*/
    
}