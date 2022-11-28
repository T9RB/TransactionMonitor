using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CovalentSDK.Covalent;

public class CovalentSession
{
    private string apiKey;
    
    public CovalentSession() {
        this.apiKey = "ckey_133dcc45a47a44e599ebb752833";
    }
    
    public JObject query(string requestURL)
    {

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var authToken = Encoding.ASCII.GetBytes($"{apiKey}:");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(authToken));

        var result = client.GetStringAsync(requestURL);

        var content = result.Result;
        JObject json = JObject.Parse(content);
        return json;
    }
}