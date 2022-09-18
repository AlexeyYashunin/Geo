namespace GeoBaseDataDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\venik\source\repos\GeoLocationSPA\GeoBaseData\Database\geobase.dat";
            new GeoBaseBinaryReader().ReadGeoData(fileName);
        }
    }
}
