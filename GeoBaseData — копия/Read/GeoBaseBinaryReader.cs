using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoBaseData.Database;

namespace GeoBaseData
{
    public static partial class GeoBaseBinaryReader
    {
        public static void Read_GeoData()
        {
            string fileName = @"C:\Users\venik\source\repos\GeoLocationSPA\GeoLocationSPA\Database\geobase.dat";
            if (File.Exists(fileName))
            {
                GeoBaseData data = new GeoBaseData();
                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        data.Header = GetHeader(reader);
                        //?HERE data.IPs = 
                    }
                }
            }
        }

        private static Header GetHeader(BinaryReader reader)
        {
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            return new Header()
            {
                version = reader.ReadInt32(),
                name = reader.ReadChars(32),
                timestamp = reader.ReadUInt64(),
                records = reader.ReadInt32(),
                offset_ranges = reader.ReadUInt32(),
                offset_cities = reader.ReadUInt32(),
                offset_locations = reader.ReadUInt32()
            };
        }

        private static  Range[] ReadIpRanges(int records)
        {
            if (_binaryReader.BaseStream.Position != Constants.HeaderSize)
            {
                _binaryReader.BaseStream.Seek(Constants.HeaderSize, SeekOrigin.Begin);
            }
            Range[] ranges = new Range[records];
            //---
            for (int i = 0; i < records; i++)
            {
                ranges[i].IpFrom = _binaryReader.ReadUInt64();
                ranges[i].IpTo = _binaryReader.ReadUInt64();
                ranges[i].Index = _binaryReader.ReadUInt32();
            }
            //---
            return ranges;
        }

        private void SetPosition() { 
            
        }
    }
}
