using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeoBaseDataDLL.Extensions
{
    public static class StringExtension
    {
        public static bool Equals(this string source, string comparable, Regex replacePattern) =>
            replacePattern.Replace(source, "").Equals(comparable.Replace(source, "")); 
        public static bool Equals(this char[] source, char[] comparable, Regex replacePattern) =>
             new string(source).Equals(new string(comparable), replacePattern);
    }
}
