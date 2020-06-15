using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
namespace MapApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

        }

        async void GetLocation()
        {
            try
            {

                var locator = CrossGeolocator.Current;
                var x = CrossGeolocator.Current.IsGeolocationEnabled;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync();

                //LongiText.Text = position.Latitude.ToString();
                //LagiText.Text = position.Longitude.ToString();
                //isOpenGPS.Text = x;
                longPosition = position.Longitude;
                latiPosition = position.Latitude;

                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(100)));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }
    }
}