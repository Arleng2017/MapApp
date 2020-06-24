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
            CheckLocationService();
        }

        /// <summary>
        /// เข้ามาครั้งแรก เพื่อถาม Permission
        /// </summary>
        async void CheckLocationService() 
        {
            var permissionStatus = await DependencyService.Get<ILocation>().CheckPermission();
            if (permissionStatus)
            {
                await Navigation.PushAsync(new MapPage());
            }
            else
            {
                gpsText.Text = "GPS ถูกปิดอยู่";
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //var isGPSDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
            //var isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            //if (isGPSAppEnabled == PermissionStatus.Granted && isGPSDeviceEnabled) await Navigation.PushAsync(new MapPage());
            //else gpsText.Text = "GPS ถูกปิดอยู่";
        }

        /// <summary>
        /// กดปุ่มสีแดง ที่หน้า UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void EnableLocation(Object sender, EventArgs e)
        {
            var locationService = DependencyService.Get<ILocation>();
            await locationService.EnableLocation();

            CheckLocationService();
        }
    }
}