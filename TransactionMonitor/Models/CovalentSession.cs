using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;

namespace CovalentSDK.Covalent;

public class CovalentSession
{
    private string _apiKey;
    
    public CovalentSession() {
        this._apiKey = "ckey_133dcc45a47a44e599ebb752833";
    }
    
    public JObject? Query(string requestUrl)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var authToken = Encoding.ASCII.GetBytes($"{_apiKey}:");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(authToken));

        try
        {
            var result = client.GetStringAsync(requestUrl);
            var content = result.Result;
            JObject? json = JObject.Parse(content);
            return json;
        }
        catch (Exception e)
        {
            JObject? js = null;
            return js;
        }



    }
}