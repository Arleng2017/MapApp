using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp.View.Models
{
    class Root2
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Summary
        {
            public int queryTime { get; set; }
            public int numResults { get; set; }
        }

        public class BoundingBox
        {
            public string northEast { get; set; }
            public string southWest { get; set; }
            public string entity { get; set; }
        }

        public class Address2
        {
            public string buildingNumber { get; set; }
            public string streetNumber { get; set; }
            public List<object> routeNumbers { get; set; }
            public string street { get; set; }
            public string streetName { get; set; }
            public string streetNameAndNumber { get; set; }
            public string countryCode { get; set; }
            public string countrySubdivision { get; set; }
            public string countrySecondarySubdivision { get; set; }
            public string municipality { get; set; }
            public string postalCode { get; set; }
            public string municipalitySubdivision { get; set; }
            public string country { get; set; }
            public string countryCodeISO3 { get; set; }
            public string freeformAddress { get; set; }
            public BoundingBox boundingBox { get; set; }
            public string localName { get; set; }
        }

        public class Address
        {
            public Address2 address { get; set; }
            public string position { get; set; }
        }

        public class Root
        {
            public Summary summary { get; set; }
            public List<Address> addresses { get; set; }
        }



    }
}
