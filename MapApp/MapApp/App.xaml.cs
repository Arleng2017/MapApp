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
                var permissionStatus = await DependencyService.Get<ILocation>().CheckPermission();
                if (permissionStatus)
                {
                    await MainPage.Navigation.PushAsync(new MapPage());
                }
            }
        }
    }
}
