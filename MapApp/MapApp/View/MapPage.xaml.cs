using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

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
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                    accuracyText.Text = $"Horizontal Accuracy: {location.Accuracy} m.";
                    verticalAccuracyText.Text = $"Vertical Accuracy: {location.VerticalAccuracy} m.";
                    altitudeText.Text = $"Altitude {location.Altitude}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async void GetLowestGPS_clicked(Object sender, EventArgs e)
        {
            try
            {
                Process();
                var request = new GeolocationRequest(GeolocationAccuracy.Lowest);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                    accuracyText.Text = $"Horizontal Accuracy: {location.Accuracy} m.";
                    verticalAccuracyText.Text = $"Vertical Accuracy: {location.VerticalAccuracy} m.";
                    altitudeText.Text = $"Altitude {location.Altitude}";

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async void GetLowGPS_clicked(Object sender, EventArgs e)
        {
            try
            {
                Process();
                var request = new GeolocationRequest(GeolocationAccuracy.Low);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                    accuracyText.Text = $"Horizontal Accuracy: {location.Accuracy} m.";
                    verticalAccuracyText.Text = $"Vertical Accuracy: {location.VerticalAccuracy} m.";
                    altitudeText.Text = $"Altitude {location.Altitude}";

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async void GetMediumGPS_clicked(Object sender, EventArgs e)
        {
            try
            {
                Process();
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                    accuracyText.Text = $"Horizontal Accuracy: {location.Accuracy} m.";
                    verticalAccuracyText.Text = $"Vertical Accuracy: {location.VerticalAccuracy} m.";
                    altitudeText.Text = $"Altitude {location.Altitude}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async void GetHighGPS_clicked(Object sender, EventArgs e)
        {
            try
            {
                Process();
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                    accuracyText.Text = $"Horizontal Accuracy: {location.Accuracy} m.";
                    verticalAccuracyText.Text = $"Vertical Accuracy: {location.VerticalAccuracy} m.";
                    altitudeText.Text = $"Altitude {location.Altitude}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async void GetBestGPS_clicked(Object sender, EventArgs e)
        {
            try
            {
                Process();
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                    accuracyText.Text = $"Horizontal Accuracy: {location.Accuracy} m.";
                    verticalAccuracyText.Text = $"Vertical Accuracy: {location.VerticalAccuracy} m.";
                    altitudeText.Text = $"Altitude {location.Altitude}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private async void GetLastKnow_clicked(Object sender, EventArgs e)
        {
            try
            {
                Process();
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromKilometers(.2)));
                    latText.Text = $"Latitude : {location.Latitude}";
                    longText.Text = $"Longitude : {location.Longitude}";
                    accuracyText.Text = $"Horizontal Accuracy: {location.Accuracy} m.";
                    verticalAccuracyText.Text = $"Vertical Accuracy: {location.VerticalAccuracy} m.";
                    altitudeText.Text = $"Altitude {location.Altitude}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }

        private void Process()
        {
            latText.Text = "Processing...";
            longText.Text = "Processing...";
            accuracyText.Text = "Processing...";
            altitudeText.Text = "Processing...";
            verticalAccuracyText.Text = "Processing...";
        }
    }
}