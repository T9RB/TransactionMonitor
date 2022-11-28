using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;

namespace CovalentSDK.Covalent;

public class Service
{
    public bool authStatus = false;

    public Image GetImage(string url)
    {
        using var client = new HttpClient();

        var result = client.GetByteArrayAsync(url);

        byte[] content = result.Result;

        using (MemoryStream imgStream = new MemoryStream(content))
        {
            return Image.FromStream(imgStream, false, false);
        }
    }

}