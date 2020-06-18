using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var isGPSDeviceEnabled = DependencyService.Get<IGetGPS>().CheckStatus();
            var isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (isGPSAppEnabled == PermissionStatus.Granted && isGPSDeviceEnabled)
                await Navigation.PushAsync(new MapPage());
            else
                gpsText.Text = "GPS ถูกปิดอยู่";
        }

        async void OpenSetting(Object sender, EventArgs e)
        {
            await Permissions.RequestAsync<Permissions.LocationAlways>();
            var isGPSDeviceEnabled = DependencyService.Get<IGetGPS>().CheckStatus();
            var isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (isGPSAppEnabled != PermissionStatus.Granted)
            {
                isGPSDeviceEnabled = DependencyService.Get<IGetGPS>().CheckStatus();
                if (isGPSAppEnabled == PermissionStatus.Granted && isGPSDeviceEnabled)
                {
                    await Navigation.PushAsync(new MapPage());
                }
                if (isGPSAppEnabled == PermissionStatus.Denied && isGPSDeviceEnabled)
                {
                    DependencyService.Get<IGetGPS>().OpenApplicationSetting();
                }

                if (isGPSAppEnabled == PermissionStatus.Denied && !isGPSDeviceEnabled)
                {
                    DependencyService.Get<IGetGPS>().GetGPS();
                }
            }
            else
            {
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                isGPSDeviceEnabled = DependencyService.Get<IGetGPS>().CheckStatus();
                isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (!isGPSDeviceEnabled  || isGPSAppEnabled != PermissionStatus.Granted)
                {
                    if (!isGPSDeviceEnabled)
                    {
                        DependencyService.Get<IGetGPS>().GetGPS();
                    }
                }
            }
        }


    }
}