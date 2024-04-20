using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Application.Features.Extensions;
public static class CommonExtensions
{
    public static string ConvertTitleToUrl(this string str)
        //this string str ile extensions metot oluşturduk. Bu sayede string olan herhangi bir değişkende ConvertTitleToUrl metodunu çağırabiliyoruz.
    {
        Dictionary<string, string> characters = new()
        {
            {"ü","u"},
            {"ş","s"},
            {"ı","i"},
            {"ö","o"},
            {"ç","c"},
            {"ğ","g"},
            {"#","sharp"}
        };
        string url = str.ToLower();
        foreach (var c in characters)
        {
            url = url.Replace(c.Key, c.Value);
        }

        var urls = url.Split(" ");
        url = string.Join("-", urls);
        return url;
    }
}
