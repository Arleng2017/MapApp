using Plugin.Geolocator;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;




namespace MapApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GPSConfigurePage : ContentPage
    {
        public GPSConfigurePage()
        {
            InitializeComponent();
            CallApplicationPermission();
        }

        async void CallApplicationPermission() 
        {
            var isGPSDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
            var isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            var isGrantGPS = isGPSAppEnabled == PermissionStatus.Granted && isGPSDeviceEnabled;

            if (!isGrantGPS) { 
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                isGPSDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
                isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (isGPSAppEnabled == PermissionStatus.Granted && isGPSDeviceEnabled)
                    await Navigation.PushAsync(new MapPage());
                else
                    gpsText.Text = "GPS ถูกปิดอยู่";
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            var isGPSDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
            var isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (isGPSAppEnabled == PermissionStatus.Granted && isGPSDeviceEnabled)
                await Navigation.PushAsync(new MapPage());
            else
                gpsText.Text = "GPS ถูกปิดอยู่";
        }

        async void OpenSetting(Object sender, EventArgs e)
        {
            try 
            {
                DependencyService.Get<IActivityService>().DisplayLocationSettingsRequest();
                bool isShowGPSPermissionDialog = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
                bool isGpsDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
                var gspPermissionAppStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (isGpsDeviceEnabled)
                {
                    if (isShowGPSPermissionDialog) await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    else
                    {
                        if (gspPermissionAppStatus != PermissionStatus.Granted) DependencyService.Get<IActivityService>().OpenApplicationInfoSetting();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}