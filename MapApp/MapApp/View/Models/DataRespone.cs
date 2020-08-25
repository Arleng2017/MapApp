using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp
{
    public class DataRespone
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string HouseNo { get; set; }
        public string Road { get; set; }
        public string Sub_District { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Address => $"ที่อยู่: {HouseNo} {Road} {Sub_District} {District} {Province} {PostalCode}";
    }
}
