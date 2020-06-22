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
using Plugin.Permissions;
using Xamarin.Forms.Internals;

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
            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            var isGpsDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
            var gspPermissionAppStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (gspPermissionAppStatus == PermissionStatus.Granted && isGpsDeviceEnabled)
                await Navigation.PushAsync(new MapPage());
            else
                gpsText.Text = "GPS ถูกปิดอยู่";
        }

        async void OpenSetting(Object sender, EventArgs e)
        {
            try
            {
                var ans = await DisplayAlert("บริการหาตำแหน่งที่ตั้งยังไม่ได้เปิดใช้งานในขณะนี้", "ไปที่ การตั้งค่า > ความเป็นส่วนตัว > เปิดใช้งาน บริการหาตำแหน่งที่ตั้ง", "การตั้งค่า", "ย้อนกลับ");
                if (ans)
                {
                    bool isShowGPSPermissionDialog = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
                    bool isGpsDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
                    var gspPermissionAppStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                    if (isShowGPSPermissionDialog)
                    {
                        await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    }
                    else
                    {
                        if (gspPermissionAppStatus != PermissionStatus.Granted || !isGpsDeviceEnabled)
                        {
                            CrossPermissions.Current.OpenAppSettings();
                        }
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