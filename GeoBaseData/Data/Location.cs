using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseDataDLL.Data
{
    public struct Location
    {
        public char[] Country;
        public char[] Region;
        public char[] Postal;
        public char[] City;
        public char[] Organization;
        public float Latitude;
        public float Longitude;
    }
}
