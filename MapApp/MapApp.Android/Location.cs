using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Nio.Channels;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapApp.Droid.Location))]
namespace MapApp.Droid
{
    public class Location : ILocation
    {
        public const int REQUEST_CHECK_SETTINGS = 0x1;
        LocationManager LocationManager { get; set; }
        public Location()
        {
            LocationManager = (LocationManager)(Forms.Context.GetSystemService(Context.LocationService));
        }

        public bool IsGpsEnabled()
        {
            try
            {
                return LocationManager.IsProviderEnabled(LocationManager.GpsProvider);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsLocationEnabled()
        {
            try
            {
                return LocationManager.IsProviderEnabled(LocationManager.NetworkProvider);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNetworkEnabled()
        {
            return IsGpsEnabled() || IsNetworkEnabled();
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