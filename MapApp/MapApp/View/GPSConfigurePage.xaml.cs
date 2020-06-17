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
            var checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
            var checkapp = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (checkapp == PermissionStatus.Granted && checkdevice)
            {
                Navigation.PushAsync(new MapPage());
            }
            else
            {
                gpsText.Text = "GPS ถูกปิดอยู่";
            }
        }

        //async void check()
        //{
        //    var checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
        //    var checkapp = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        //    if (checkapp != PermissionStatus.Granted)
        //    {
        //        checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
        //        //  checkapp = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        //        if (checkapp == PermissionStatus.Granted && checkdevice)
        //        {
        //            await Navigation.PushAsync(new MapPage());
        //        }
        //        if (checkapp != PermissionStatus.Granted)
        //        {
        //            await Navigation.PopAsync();
        //            DependencyService.Get<IGetGPS>().OpenApplicationSetting();


        //        }
        //    }
        //    else
        //    {
        //        checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
        //        checkapp = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        //        if (checkdevice == false || checkapp != PermissionStatus.Granted)
        //        {
        //            if (!checkdevice)
        //            {
        //                await Navigation.PopAsync();
        //                DependencyService.Get<IGetGPS>().GetGPS();
        //            }
        //        }
        //    }

        //}

        async void OpenSetting(Object sender, EventArgs e)
        {

            var checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
            var checkapp = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (checkapp != PermissionStatus.Granted)
            {
                checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
                if (checkapp == PermissionStatus.Granted && checkdevice)
                {
                    await Navigation.PushAsync(new MapPage());
                }
                if (checkapp == PermissionStatus.Denied && checkdevice)
                {
                   DependencyService.Get<IGetGPS>().OpenApplicationSetting();
                }

                if (checkapp == PermissionStatus.Denied && !checkdevice)
                {
                    DependencyService.Get<IGetGPS>().GetGPS();
                
                }
            }
            else
            {
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                checkdevice = DependencyService.Get<IGetGPS>().CheckStatus();
                checkapp = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (checkdevice == false || checkapp != PermissionStatus.Granted)
                {
                    if (!checkdevice)
                    {
                        DependencyService.Get<IGetGPS>().GetGPS();
                    }
                }
            }
        }


    }
}