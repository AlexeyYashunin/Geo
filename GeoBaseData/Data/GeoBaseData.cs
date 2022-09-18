using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseDataDLL.Data
{
    public class GeoBaseData
    {
        public Header Header { get; set; } = new Header();
        public List<Range> Ranges { get; set; } = new List<Range>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<uint> Indexes { get; set; } = new List<uint>();
        public GeoBaseData(Header header, Range[] ranges, Location[] locations, uint[] indexes)
        {
            Header = header;
            Ranges = ranges != default ? ranges.ToList() : default;
            Locations = locations != default ? locations.ToList() : default;
            Indexes = indexes != default ? indexes.ToList() : default;
        }
    }
}