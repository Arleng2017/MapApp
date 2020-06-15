using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GPSConfigurePage : ContentPage
    {
        public GPSConfigurePage()
        {
            InitializeComponent();
            CheckGPSStatus();
        }


        async void CheckGPSStatus()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                var x = CrossGeolocator.Current.IsGeolocationEnabled;
                if (CrossGeolocator.Current.IsGeolocationEnabled)
                {
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PopAsync());
                    await Navigation.PushModalAsync(new MapPage(), false);
                }
                else
                {
                    await DisplayAlert("Notification", "Please turn on GPS", "OK");
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PopAsync());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }
    }
}