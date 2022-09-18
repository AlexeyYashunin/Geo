using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseDataDLL.Extensions
{
    public static class IEnumerableExtension
    {
        public static List<T> ToList<T>(this IEnumerable<T> collection) where T : GeoBaseDataDLL.Data.GeoBaseData => collection != default ? new List<T>(collection) : new List<T>();
    }
}
