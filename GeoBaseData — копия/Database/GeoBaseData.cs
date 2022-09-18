using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseData.Database
{
    public class GeoBaseData
    {
        public Header Header { get; set; } = new Header();
        public List<IP> IPs { get; set; } = new List<IP>();
        public List<Coordinates> Coordinates { get; set; } = new List<Coordinates>();
    }
}
