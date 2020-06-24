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
        public async Task<bool> CheckPermission()
        {
            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            var isGPSDeviceEnabled = LocationServiceEnabled();
            var isGPSAppEnabled = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            return isGPSAppEnabled == PermissionStatus.Granted && isGPSDeviceEnabled;
        }

        public async Task EnableLocation()
        {
            try
            {
                var deviceLocationServiceEnabled = LocationServiceEnabled();
                var shouldRequestPermission = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
                var locationPermissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                var appLocationPermissionDenied = locationPermissionStatus == PermissionStatus.Denied;

                if (shouldRequestPermission)
                {
                    await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }
                else
                {
                    if (!deviceLocationServiceEnabled || appLocationPermissionDenied)
                    {
                        CrossPermissions.Current.OpenAppSettings();
                    }
                }

                var granted = deviceLocationServiceEnabled && locationPermissionStatus == PermissionStatus.Granted;
                if (granted)
                {
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new MapPage());
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
