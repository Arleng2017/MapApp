using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Net.Http;
using Newtonsoft.Json;
using MapApp.View.Models;

namespace MapApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            GetLocation();
        }

        async void GetLocation()
        {
            try
            {
                Process();
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async void GetLatLonPoint_clicked(Object sender, EventArgs e)
        {
            try
            {
                Process();
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync();
                if (location != null)
                {
                    var position = MyMap.VisibleRegion.Center;
                    latText.Text = $"Latitude : {position.Latitude}";
                    longText.Text = $"Longitude : {position.Longitude}";


                    await Navigation.PushAsync(new SelectLocationPage(position.Latitude.ToString(), position.Longitude.ToString()));
                }



            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async Task<DataRespone> GetAddress(double lat, double lon)
        {
            try
            {
                var urlSearchApi = "https://atlas.microsoft.com/search/fuzzy/json" + $"?subscription-key=9Pr3bh-0TB9ZCDmRcvS_UFJDu_Xm7sGs3Z5ASG1AJhI&api-version=1.0&query={lat},{lon}&language=th-TH&countrySet=TH&idxSet=POI,PAD&lat={lat}&lon={lon}&limit=5";
                var httpClient = new HttpClient();
                var resData = httpClient.GetAsync(urlSearchApi).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var resultObj = JsonConvert.DeserializeObject<Root>(resData);
                var lstReults = resultObj.results;
                var selectResult = lstReults.Any(it => it.type == "POI") ? lstReults.Where(it => it.type == "POI").FirstOrDefault() : lstReults.Where(it => it.type == "Point Address").FirstOrDefault();
                var result = new DataRespone()
                {
                    Name = selectResult.poi?.name ?? "",
                    Phone = selectResult.poi?.phone ?? "",
                    HouseNo = selectResult.address?.streetNumber ?? "",
                    Road = selectResult.address?.streetName ?? "",
                    Sub_District = selectResult.address?.municipalitySubdivision ?? "",
                    District = selectResult.address?.countrySecondarySubdivision ?? "",
                    Province = selectResult.address?.municipality ?? "",
                    PostalCode = selectResult.address?.postalCode ?? "",
                };
                return result;
            }
            catch (Exception ex)
            {
                return new DataRespone();
            }
        }

        private void Process()
        {
            latText.Text = "Processing...";
            longText.Text = "Processing...";
        }
    }
}