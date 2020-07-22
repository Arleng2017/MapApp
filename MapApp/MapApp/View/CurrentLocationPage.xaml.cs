using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MapApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentLocationPage : ContentPage
    {
        private static bool timeTrigger = true;
        public CurrentLocationPage()
        {
            InitializeComponent();
        }

        public async void MapChanged(object sender, PropertyChangedEventArgs e)
        {
            if (CurrentLocationPage.timeTrigger)
            {
                btn.IsEnabled = false;
                CurrentLocationPage.timeTrigger = false;
                latText.Text = "Pin Location";
                GetCurrentLocation();
            }
        }

        private async void GetCurrentLocation()
        {
            try
            {
                if (MyMap.VisibleRegion != null)
                {
                    Geocoder geoCoder = new Geocoder();
                    Position position = new Position(MyMap.VisibleRegion.Center.Latitude, MyMap.VisibleRegion.Center.Longitude);
                    var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                    latText.Text = possibleAddresses.FirstOrDefault();
                }
                Thread.Sleep(40);
                btn.IsEnabled = true;
                CurrentLocationPage.timeTrigger = true;
            }
            catch (Exception ex)
            {

            }
        }

    }
}