using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoBaseDataDLL
{
    public partial class GeoBaseBinaryReader
    {
        public void SetPosition(Action<BinaryReader> setPositionFunc, BinaryReader reader) { setPositionFunc(reader); }
        public void SetPositionByRecords(Action<BinaryReader, int> setPositionByRecordsFunc, BinaryReader reader, int records) => setPositionByRecordsFunc(reader, records);
        public void ResetPosition(BinaryReader reader) => reader.BaseStream.Seek(0, SeekOrigin.Begin);
        public void SetHeaderPosition(BinaryReader reader) => ResetPosition(reader);
        public void SetIpRangesPosition(BinaryReader reader) => reader.BaseStream.Seek(Constants.HeaderSize, SeekOrigin.Begin);
        public void SetIpLocationsPosition(BinaryReader reader, int records) => reader.BaseStream.Seek(Constants.RangesSize * records + Constants.HeaderSize, SeekOrigin.Begin); 
        public void SetIndexesPosition(BinaryReader reader, int records) => reader.BaseStream.Seek(Constants.LocationsSize * records + Constants.RangesSize * records + Constants.HeaderSize, SeekOrigin.Begin); 
    }
}