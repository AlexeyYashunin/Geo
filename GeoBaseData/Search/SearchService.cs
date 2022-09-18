using GeoBaseDataDLL.Data;
using System.Collections.Generic;

namespace Metaquotes.Geo
{
    public class GeoDataBaseSearcher
    {
        private readonly GeoBaseData geoBaseData;
        public GeoDataBaseSearcher(GeoBaseData geoBaseData) => this.geoBaseData = geoBaseData;

        public Location GetLocationByIp(ulong ip)
        {
            int begin = 0;
            int end = geoBaseData.Ranges.Count - 1;
            while (begin <= end)
            {
                int middleOfRanges = begin + (end - begin) / 2;
                Range currentRange = geoBaseData.Ranges[middleOfRanges];
                if (IsRangeContainsIP(currentRange))
                    return geoBaseData.Locations[(int)currentRange.Index];
                MovePositions(currentRange, middleOfRanges);
            }
            return default;
            bool IsRangeContainsIP(Range range) => ip >= range.IpFrom && ip <= range.IpTo;
            void MovePositions(Range range, int middleOfRanges)
            {
                if (ip < range.IpFrom)
                    end = middleOfRanges - 1;
                else
                    begin = middleOfRanges + 1;
            }
        }

        public List<Location> GetLocationsByCity(string city)
        {
            List<Location> locations = new List<Location>();
            int begin = 0;
            int end = geoBaseData.Indexes.Count - 1;
            while (begin <= end)
            {
                int middleOfRanges = begin + (end - begin) / 2;
                Location location = geoBaseData.Locations[(int)geoBaseData.Indexes[middleOfRanges]];
                string cityCurrent = GetCity(location);
                bool isCityFound = cityCurrent.Equals(city);
                MovePositions(isCityFound, middleOfRanges);
                if (!isCityFound) continue;
                locations.Add(location);
                int leftIndex = middleOfRanges;
                int rightIndex = middleOfRanges;
                while (leftIndex-- > begin)
                {
                    Location leftLocation = geoBaseData.Locations[(int) geoBaseData.Indexes[leftIndex]];
                    if (!GetCity(leftLocation).Equals(city))
                        break;
                    locations.Add(leftLocation);
                }

                while (rightIndex++ < end)
                {
                    Location rightLocation = geoBaseData.Locations[(int) geoBaseData.Indexes[rightIndex]];
                    if (!GetCity(rightLocation).Equals(city))
                        break;
                    locations.Add(rightLocation);
                }
                break;
            }
            return locations;
            void MovePositions(bool isCityFound, int middleOfRanges)
            {
                if (isCityFound)
                    end = middleOfRanges - 1;
                else
                    begin = middleOfRanges + 1;
            }
            string GetCity(Location location) => new string(location.City).Replace("\0", string.Empty);
        }
    }
}