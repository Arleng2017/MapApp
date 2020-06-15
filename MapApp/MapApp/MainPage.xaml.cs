using MapApp.View;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();



        }

        public async void OpenMap_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GPSConfigurePage());
        }

        private async void GetGPSBtn_Clicked(object sender, EventArgs e)
        {

            //try
            //{

            //    var locator = CrossGeolocator.Current;
            //    var x = CrossGeolocator.Current.IsGeolocationEnabled;
            //    locator.DesiredAccuracy = 50;
            //    var position = await locator.GetPositionAsync();

            //    //LongiText.Text = position.Latitude.ToString();
            //    //LagiText.Text = position.Longitude.ToString();
            //    //isOpenGPS.Text = x;
            //    longPosition = position.Longitude;
            //    latiPosition = position.Latitude;

            //    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(100)));

            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            //}


        }


    }
}
