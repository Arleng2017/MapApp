using System;
using MapApp.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override async void OnResume()
        {
            var mainPage = MainPage as NavigationPage;
            if (mainPage.CurrentPage is GPSConfigurePage)
            {
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                var isGpsDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
                var gspPermissionAppStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (gspPermissionAppStatus == PermissionStatus.Granted && isGpsDeviceEnabled)
                    await MainPage.Navigation.PushAsync(new MapPage());
            }
        }
    }
}
