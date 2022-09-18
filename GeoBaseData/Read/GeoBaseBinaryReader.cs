using GeoBaseDataDLL.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeoBaseDataDLL
{
    public partial class GeoBaseBinaryReader
    {
        public GeoBaseData ReadGeoData(string fileName)
        {
            if (!File.Exists(fileName)) return new GeoBaseData(default,default,default,default);
            GeoBaseData geoBaseData = default;
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                Header header = GetHeader(reader);
                Range[] ranges = GetIpRanges(reader, header.Records);
                Location[] locations = GetIpLocations(reader, header.Records);
                uint[] indexes = GetIndexes(reader, header.Records);
                geoBaseData = new GeoBaseData(header, ranges, locations,indexes);
            }
            return geoBaseData;
        }

        private Header GetHeader(BinaryReader reader)
        {
            SetPosition(SetHeaderPosition, reader);
            return new Header()
            {
                Version = reader.ReadInt32(),
                Name = reader.ReadChars(32),
                Timestamp = reader.ReadUInt64(),
                Records = reader.ReadInt32(),
                Offset_ranges = reader.ReadUInt32(),
                Offset_cities = reader.ReadUInt32(),
                Offset_locations = reader.ReadUInt32()
            };
        }

        private Range[] GetIpRanges(BinaryReader reader, int records)
        {
            SetPosition(SetIpRangesPosition, reader);
            Range[] ranges = new Range[records];
            for (int i = 0; i < records; i++)
            {
                ranges[i].IpFrom = reader.ReadUInt32();
                ranges[i].IpTo = reader.ReadUInt32();
                ranges[i].Index = reader.ReadUInt32();
            }
            return ranges;
        }

        private Location[] GetIpLocations(BinaryReader reader, int records)
        {
            SetPositionByRecords(SetIpLocationsPosition, reader, records);
            Location[] locations = new Location[records];
            for (int i = 0; i < records; i++)
            {
                locations[i].Country = reader.ReadChars(8);
                locations[i].Region = reader.ReadChars(12);
                locations[i].Postal = reader.ReadChars(12);
                locations[i].City = reader.ReadChars(24);
                locations[i].Organization = reader.ReadChars(32);
                locations[i].Latitude = reader.ReadSingle();
                locations[i].Longitude = reader.ReadSingle();
            }
            return locations;
        }

        private uint[] GetIndexes(BinaryReader reader,int records)
        {
            SetPositionByRecords(SetIndexesPosition, reader, records);
            uint[] indexes = new uint[records];
            for (int i = 0; i < records; i++)
                indexes[i] = reader.ReadUInt32();
            return indexes;
        }
    }
}