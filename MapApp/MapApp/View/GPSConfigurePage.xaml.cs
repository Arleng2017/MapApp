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
            CheckGPSStatus();
        }


        async void CheckGPSStatus()
        {

            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Granted)
                {

                    Device.BeginInvokeOnMainThread(async () => await Navigation.PopAsync());
                    await Navigation.PushModalAsync(new MapPage(), false);
                }
                else
                {
                    var isOpenGps = await DisplayAlert("ผิดพลาด GPS ถูกปิดใช้งาน", "ต้องการเปิด GPS หรือไม่?", "Yes", "No");
                    if (isOpenGps)
                    {
                        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                        CheckGPSStatus();
                    }
                    else await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", "Unable to get GPS Location " + ex, "Ok");
            }
        }
    }
}