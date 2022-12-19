using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static CovalentSDK.Covalent.CovalentSession;
namespace CovalentSDK.Covalent;

public class CovalentMethods
{
    private CovalentSession _covSession;
    public CovalentMethods()
    {
        CovalentSession covalentSession = new CovalentSession();
        _covSession = covalentSession;
    }
    
    public JObject? GetAllChain()
    {
        string url = "https://api.covalenthq.com/v1/chains/";
        return _covSession.Query(url);
    }

    public JObject? GetTokenBalanceForAddress(string covNet,string walletAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet}/address/{walletAddress}/balances_v2/";
        return _covSession.Query(url);
    }
    
    public JObject? GetTransactionForAddress(string covNet,string walletAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet}/address/{walletAddress}/transactions_v2/";
        return _covSession.Query(url);
    }
    
    public JObject? GetErc20TokenForAddress(string covNet,string walletAddress, string usdcContractAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet}/address/{walletAddress}/transfers_v2/?contract-address={usdcContractAddress}";
        return _covSession.Query(url);
    }
    
    public JObject? GetPoolsByAddress(string covNet,string dexname, string usdcPoolAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet}/xy=k/{dexname}/pools/address/{usdcPoolAddress}/";
        return _covSession.Query(url);
    }
    
    public JObject? GetLogByContract(string covNet,string startingBlock,string  endingBlock,string usdcContractAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet}/events/address/{usdcContractAddress}/?starting-block={startingBlock}&ending-block={endingBlock}";
        return _covSession.Query(url);
    }
    public JObject? GetHistoricalTokenPrices(string covNet,string quoteCurrency,string  contractAddresses)
    {
        
        string url = $"https://api.covalenthq.com/v1/pricing/historical_by_addresses_v2/{covNet}/{quoteCurrency}/{contractAddresses}/";
        return _covSession.Query(url);
    }
    
    public JObject? GetHistoricalPortfolio(string covNet,string walletAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet}/address/{walletAddress}/portfolio_v2/";
        return _covSession.Query(url);
    }
    
    public JObject? GetATransaction(string covNet,string txnHash)
    {
        
        var url = $"https://api.covalenthq.com/v1/{covNet}/transaction_v2/{txnHash}/";
        return _covSession.Query(url);
    }
    
    public JObject? GetXyTransaction(string covNet,string dexname, string walletAddress)
    {
        
        var url = $"https://api.covalenthq.com/v1/{covNet}/xy=k/{dexname}/address/{walletAddress}/transactions/";
        return _covSession.Query(url);
    }
    
    
}