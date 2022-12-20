using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using TransactionMonitor.ViewModels;

namespace CovalentSDK.Covalent;

public class Service
{
    
    public CovalentMethods CovalentMethods = new CovalentMethods();
    

    public bool Authorization(string wallet_address, string sel_net)
    {
        bool Auth_Check;
        var check = CovalentMethods.GetTokenBalanceForAddress(sel_net, wallet_address);
        if (check != null)
        {
            Auth_Check = true;
            return Auth_Check;
        }
        else
        {
            Auth_Check = false;
            return Auth_Check;
        }
    }
}