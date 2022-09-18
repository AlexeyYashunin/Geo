using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseData.Database
{
    public class IP
    {
        public uint ip_from;//начало диапазона IP адресов
        public uint ip_to;//конец диапазона IP адресов
        public uint location_index;//индекс записи о местоположении
    }
}
