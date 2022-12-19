using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using AvaloniaEdit;
using CovalentSDK.Covalent;

namespace TransactionMonitor.Views;

public class TransactionWithProtocolViewModel
{
    public ObservableCollection<TransactionWithProtocol> TransactionWithProtocolsList { get; } = new();
    public TransactionWithProtocolViewModel()
    {
        
    }

    public void LoadTransactions(string ChainId, string DexName, string wallet)
    {
        CovalentMethods covalentMethods = new CovalentMethods();
        Service service = new Service();

        var Transactions = covalentMethods.GetXyTransaction(ChainId, DexName, wallet);

        if (Transactions == null) 
        {
            service.MessageBoxShow("Предупреждение", "Вы ввели неверные данные");
        }
        else
        {
            var hash = " ";
            var act = " ";
            var quote_currensy = " ";
            var total_quote = " ";

            var TransactionsProtoc = covalentMethods.GetXyTransaction(ChainId, DexName, wallet);

            var Transaction =
                from transaction in TransactionsProtoc["data"]["items"]
                select new
                {
                    hash = (string)transaction["tx_hash"],
                    act = (string)transaction["act"],
                    quote_currensy = (string)transaction["quote_currency"],
                    total_quote = (string)transaction["total_quote"]
                };
            foreach (var value in Transaction)
            {
                TransactionWithProtocolsList.Add(new TransactionWithProtocol(){Hash = value.hash, Act = value.act, Quote_Currensy = value.quote_currensy, Total_Quote = value.total_quote});
            }
        }
    }
}