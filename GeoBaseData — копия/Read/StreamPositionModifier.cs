using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseData.Database
{
    public static partial class GeoBaseBinaryReader
    {
        public static void ResetPosition(BinaryReader reader) => reader.BaseStream.Seek(0, SeekOrigin.Begin);
        public static void SetHeaderPosition(BinaryReader reader) => ResetPosition(reader);
        public static void SetIpRangesPosition(BinaryReader reader) => reader.BaseStream.Seek(Constants.HeaderSize, SeekOrigin.Begin);
        public static void SetIpLocationsPosition(BinaryReader reader, int records) => reader.BaseStream.Seek(Constants.RangesSize * records + Constants.HeaderSize, SeekOrigin.Begin); 
        public static void SetIndexesPosition(BinaryReader reader, int records) => reader.BaseStream.Seek(Constants.LocationsSize * records + Constants.RangesSize * records + Constants.HeaderSize, SeekOrigin.Begin); 
    }
}
