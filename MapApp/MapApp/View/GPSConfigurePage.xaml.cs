using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
           // CheckGPSStatus();
        }

        async void ShowPermissionAlert(object sender,EventArgs e)
        {
            await Permissions.RequestAsync<Permissions.LocationAlways>();
           

        }
        async void CheckGPSStatus()
        {
            var checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
            var checkapp = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (checkapp == PermissionStatus.Granted && checkdevice)
            {
                await Navigation.PushAsync(new MapPage());
            }
            else
            {
                var alertAns = await DisplayAlert("GPS ไม่สามารถใช้งานได้ ลองใหม่อีกครั้ง", "คุณต้องการเปิด GPS หรือไม่ ", "Yes", "No");
                if (alertAns)
                {
                    OpenSetting();
                }
                else
                {
                    await Navigation.PopAsync();
                }

            }

        }

        async void OpenSetting()
        {
            var checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
            var permission = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            await Permissions.RequestAsync<Permissions.LocationAlways>();
            //if (checkdevice == false || permission != PermissionStatus.Granted)
            //{
            //    if (!checkdevice)
            //    {
            //        DependencyService.Get<IGetGPS>().GetGPS();
            //    }
            //    await Permissions.RequestAsync<Permissions.LocationAlways>();
            //}
        }


    }
}