using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TinyUrl.Common
{
    public class Helper
    {
        public static bool IsValidURL(string URL)
        {
            string Pattern = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}
