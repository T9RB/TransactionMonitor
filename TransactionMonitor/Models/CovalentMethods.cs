using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static CovalentSDK.Covalent.CovalentSession;
using static CovalentSDK.Covalent.CovalentNetworks;
namespace CovalentSDK.Covalent;

public class CovalentMethods
{
    private CovalentSession _covSession;
    public CovalentMethods()
    {
        CovalentSession covalentSession = new CovalentSession();
        _covSession = covalentSession;
    }
    
    public JObject GetAllChain()
    {
        string url = "https://api.covalenthq.com/v1/chains/";
        return _covSession.query(url);
    }

    public JObject GetTokenBalanceForAddress(CovalentNetworks covNet,string walletAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet.Value}/address/{walletAddress}/balances_v2/";
        return _covSession.query(url);
    }
    
    public JObject GetTransactionForAddress(CovalentNetworks covNet,string walletAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet.Value}/address/{walletAddress}/transactions_v2/";
        return _covSession.query(url);
    }
    
    public JObject GetErc20TokenForAddress(CovalentNetworks covNet,string walletAddress, string usdcContractAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet.Value}/address/{walletAddress}/transfers_v2/?contract-address={usdcContractAddress}";
        return _covSession.query(url);
    }
    
    public JObject GetPoolsByAddress(CovalentNetworks covNet,string dexname, string usdcPoolAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet.Value}/xy=k/{dexname}/pools/address/{usdcPoolAddress}/";
        return _covSession.query(url);
    }
    
    public JObject GetLogByContract(CovalentNetworks covNet,string startingBlock,string  endingBlock,string usdcContractAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet.Value}/events/address/{usdcContractAddress}/?starting-block={startingBlock}&ending-block={endingBlock}";
        return _covSession.query(url);
    }
    public JObject GetHistoricalTokenPrices(CovalentNetworks covNet,string quoteCurrency,string  contractAddresses)
    {
        
        string url = $"https://api.covalenthq.com/v1/pricing/historical_by_addresses_v2/{covNet.Value}/{quoteCurrency}/{contractAddresses}/";
        return _covSession.query(url);
    }
    
    public JObject GetHistoricalPortfolio(CovalentNetworks covNet,string walletAddress)
    {
        
        string url = $"https://api.covalenthq.com/v1/{covNet.Value}/address/{walletAddress}/portfolio_v2/";
        return _covSession.query(url);
    }
    
    public JObject GetATransaction(CovalentNetworks covNet,string txnHash)
    {
        
        var url = $"https://api.covalenthq.com/v1/{covNet.Value}/transaction_v2/{txnHash}/";
        return _covSession.query(url);
    }
    
    public JObject GetXyTransaction(CovalentNetworks covNet,string dexname, string walletAddress)
    {
        
        var url = $"https://api.covalenthq.com/v1/{covNet.Value}/xy=k/{dexname}/address/{walletAddress}/transactions/";
        return _covSession.query(url);
    }
    
    
}