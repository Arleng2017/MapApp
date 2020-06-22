using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Permissions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MapApp.Droid
{
    class ActivityService : IActivityService
    {
        public const int REQUEST_CHECK_SETTINGS = 0x1;

        private readonly object formsApp;
        public ActivityService(object formsApp)
        {
            this.formsApp = formsApp;
        }

        public async void DisplayApplictionSettingsRequest()
        {
            bool isShowGPSPermissionDialog = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
            bool isGpsDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
            var gspPermissionAppStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (isGpsDeviceEnabled)
            {
                if (isShowGPSPermissionDialog)
                {
                    await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }
                else
                {
                    if (gspPermissionAppStatus != PermissionStatus.Granted) {
                        Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName));
                        intent.AddFlags(ActivityFlags.NewTask);
                        intent.AddFlags(ActivityFlags.MultipleTask);
                        Android.App.Application.Context.StartActivity(intent);
                    }
                }
            }
        }

        public void DisplayLocationSettingsRequest()
        {
            var mainActivity = formsApp as MainActivity;
            var googleApiClient = new GoogleApiClient.Builder(mainActivity).AddApi(LocationServices.API).Build();
            googleApiClient.Connect();
            var locationRequest = LocationRequest.Create();
            locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
            locationRequest.SetInterval(10000);
            locationRequest.SetFastestInterval(10000 / 2);

            var builder = new LocationSettingsRequest.Builder().AddLocationRequest(locationRequest);
            builder.SetAlwaysShow(true);

            var result = LocationServices.SettingsApi.CheckLocationSettings(googleApiClient, builder.Build());

            result.SetResultCallback((LocationSettingsResult callback) =>
            {
                switch (callback.Status.StatusCode)
                {
                    case LocationSettingsStatusCodes.Success:
                        {
                            break;
                        }
                    case LocationSettingsStatusCodes.ResolutionRequired:
                        {
                            try
                            {
                                // Show the dialog by calling startResolutionForResult(), and check the result
                                // in onActivityResult().
                                callback.Status.StartResolutionForResult(mainActivity, REQUEST_CHECK_SETTINGS);
                            }
                            catch (IntentSender.SendIntentException e)
                            {
                            }

                            break;
                        }
                    default:
                        {
                            // If all else fails, take the user to the android location settings
                            mainActivity.StartActivity(new Intent(Android.Provider.Settings.ActionLocationSourceSettings));
                            break;
                        }
                }
            });
        }

        public void OpenApplicationInfoSetting()
        {
            Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName));
            intent.AddFlags(ActivityFlags.NewTask);
            intent.AddFlags(ActivityFlags.MultipleTask);
            Android.App.Application.Context.StartActivity(intent);
        }

}
}