using MapApp.View;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MapApp
{
    public abstract class LocationBase
    {
        protected abstract bool LocationServiceEnabled();
        protected abstract Task EnableDeviceLocationService();


        public async Task<bool> CheckPermission()
        {
            var deviceLocationServiceEnabled = LocationServiceEnabled();
            var locationPermissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            var locationPermissionGranted = locationPermissionStatus == PermissionStatus.Granted;

            return locationPermissionGranted && deviceLocationServiceEnabled;
        }

        public async Task EnableLocation()
        {
            try
            {
                var shouldRequestPermission = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
                var locationPermissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                var appLocationPermissionDenied = locationPermissionStatus != PermissionStatus.Granted;

                if (shouldRequestPermission)
                {
                    await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }
                else
                {
                    if (appLocationPermissionDenied)
                    {
                        CrossPermissions.Current.OpenAppSettings();
                    }
                }

                var deviceLocationServiceEnabled = LocationServiceEnabled();
                if (!deviceLocationServiceEnabled)
                {
                    await EnableDeviceLocationService();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task NavigateToMapPage()
        {
            var deviceLocationServiceEnabled = LocationServiceEnabled();
            var locationPermissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            var locationPermissionGranted = locationPermissionStatus == PermissionStatus.Granted;

            if (locationPermissionGranted && deviceLocationServiceEnabled)
            {
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new MapPage());
            }
        }
    }
}
