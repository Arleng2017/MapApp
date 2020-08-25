using System.Collections.Generic;

namespace MapApp.View.Models
{
    internal class Root
    {
        public Summary summary { get; set; }
        public List<Result> results { get; set; }
    }
    internal class GeoBias
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    internal class Summary
    {
        public string query { get; set; }
        public string queryType { get; set; }
        public int queryTime { get; set; }
        public int numResults { get; set; }
        public int offset { get; set; }
        public int totalResults { get; set; }
        public int fuzzyLevel { get; set; }
        public GeoBias geoBias { get; set; }
    }

    internal class Address
    {
        public string streetNumber { get; set; }
        public string streetName { get; set; }
        public string municipalitySubdivision { get; set; }
        public string municipality { get; set; }
        public string countrySecondarySubdivision { get; set; }
        public string countrySubdivision { get; set; }
        public string postalCode { get; set; }
        public string countryCode { get; set; }
        public string country { get; set; }
        public string countryCodeISO3 { get; set; }
        public string freeformAddress { get; set; }
        public string localName { get; set; }
    }

    internal class Position
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    internal class TopLeftPoint
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    internal class BtmRightPoint
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    internal class Viewport
    {
        public TopLeftPoint topLeftPoint { get; set; }
        public BtmRightPoint btmRightPoint { get; set; }
    }

    internal class Position2
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    internal class EntryPoint
    {
        public string type { get; set; }
        public Position2 position { get; set; }
    }

    internal class CategorySet
    {
        public int id { get; set; }
    }

    internal class Name
    {
        public string nameLocale { get; set; }
        public string name { get; set; }
    }

    internal class Classification
    {
        public string code { get; set; }
        public List<Name> names { get; set; }
    }

    internal class Poi
    {
        public string name { get; set; }
        public string phone { get; set; }
        public List<CategorySet> categorySet { get; set; }
        public List<string> categories { get; set; }
        public List<Classification> classifications { get; set; }
    }

    internal class Result
    {
        public string type { get; set; }
        public string id { get; set; }
        public double score { get; set; }
        public double dist { get; set; }
        public Address address { get; set; }
        public Position position { get; set; }
        public Viewport viewport { get; set; }
        public List<EntryPoint> entryPoints { get; set; }
        public string info { get; set; }
        public Poi poi { get; set; }
    }
}