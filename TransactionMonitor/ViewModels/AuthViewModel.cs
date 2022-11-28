using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Data;
using CovalentSDK.Covalent;
using DynamicData;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Image = System.Drawing.Image;

namespace TransactionMonitor.ViewModels;

public class AuthViewModel : ViewModelBase
{
    public ObservableCollection<Networks> Networks { get; } = new();

    public AuthViewModel()
    {
        LoadChains();
    }
    public void Auth()
    {
        Service sr = new Service();
    }
    
    public void LoadChains()
    {
        CovalentMethods cm = new CovalentMethods();
        Service sr = new Service();
        var chain = cm.GetAllChain();

        var nameChain =
            from n in chain["data"]["items"]
            where (string) n["label"] == "Ethereum Mainnet"
            select (string) n["label"];

        var imageChain = 
            from n in chain["data"]["items"]
            select (string) n["logo_url"];
        
        foreach (var value in nameChain)
        {
            Networks.Add(new Networks() {Name = value, ImageChain = sr.GetImage("https://www.covalenthq.com/static/images/icons/display-icons/ethereum-eth-logo.png")}); 
        }
       


    }

    
}