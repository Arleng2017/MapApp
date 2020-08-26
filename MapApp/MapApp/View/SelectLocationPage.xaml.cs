using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using MapApp.View.Models;
using System.Collections.Generic;

namespace MapApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectLocationPage : ContentPage
    {
        public IList<DataRespone> LstLocations { get; set; }
        public SelectLocationPage(string lat, string lon)
        {
            InitializeComponent();
            LstLocations = new List<DataRespone>();
            GetAddressCurrent(lat, lon);
            DisplayLocation(lat, lon);
            LocationView.ItemsSource = LstLocations;
        }

        async void GetAddressCurrent(string lat, string lon)
        {
            var urlSearchApi = "https://atlas.microsoft.com/search/address/reverse/json" + $"?api-version=1.0&subscription-key=9Pr3bh-0TB9ZCDmRcvS_UFJDu_Xm7sGs3Z5ASG1AJhI&language=th-TH&query={lat},{lon}";
            var httpClient = new HttpClient();
            var resData = httpClient.GetAsync(urlSearchApi).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var resultObj = JsonConvert.DeserializeObject<Root2.Root>(resData);
            var result = resultObj.addresses?.FirstOrDefault().address;
            LstLocations.Add(new DataRespone()
            {
                Name = "พิกัดหมุด",
                Phone = "",
                HouseNo = result.streetNumber ?? "",
                Road = result.streetName ?? "",
                Sub_District = result.municipalitySubdivision ?? "",
                District = result.countrySecondarySubdivision ?? "",
                Province = result.municipality ?? "",
                PostalCode = result.postalCode ?? "",
            });
        }

        async void DisplayLocation(string lat, string lon)
        {
            try
            {
                var urlSearchApi = "https://atlas.microsoft.com/search/fuzzy/json" + $"?subscription-key=9Pr3bh-0TB9ZCDmRcvS_UFJDu_Xm7sGs3Z5ASG1AJhI&api-version=1.0&query={lat},{lon}&language=th-TH&countrySet=TH&idxSet=POI,PAD&lat={lat}&lon={lon}&limit=5";
                var httpClient = new HttpClient();
                var resData = httpClient.GetAsync(urlSearchApi).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var resultObj = JsonConvert.DeserializeObject<Root>(resData);
                var lstReults = resultObj.results;
                foreach (var item in lstReults)
                {
                    LstLocations.Add(new DataRespone()
                    {
                        Name = $"ชื่อสถานที่: {item.poi?.name ?? "-"}",
                        Phone = $"เบอร์ติดต่อ: {item.poi?.phone ?? "-"}",
                        HouseNo = item.address?.streetNumber ?? "",
                        Road = item.address?.streetName ?? "",
                        Sub_District = item.address?.municipalitySubdivision ?? "",
                        District = item.address?.countrySecondarySubdivision ?? "",
                        Province = item.address?.municipality ?? "",
                        PostalCode = item.address?.postalCode ?? "",
                    });
                }
                //var selectResult = lstReults.Any(it => it.type == "POI") ? lstReults.Where(it => it.type == "POI").FirstOrDefault() : lstReults.Where(it => it.type == "Point Address").FirstOrDefault();
                //var result = new DataRespone()
                //{
                //    Name = selectResult.poi?.name ?? "",
                //    phone = selectResult.poi?.phone ?? "",
                //    HouseNo = selectResult.address?.streetNumber ?? "",
                //    Road = selectResult.address?.streetName ?? "",
                //    Sub_District = selectResult.address?.municipalitySubdivision ?? "",
                //    District = selectResult.address?.countrySecondarySubdivision ?? "",
                //    Province = selectResult.address?.municipality ?? "",
                //    PostalCode = selectResult.address?.postalCode ?? "",
                //};
            }
            catch (Exception ex)
            {
            }
        }
    }
}