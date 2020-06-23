using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Plugin.Permissions;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapApp.Droid.Location))]
namespace MapApp.Droid
{
    public class Location : LocationBase, ILocation
    {
        private LocationManager locationManager { get; set; }

        public Location()
        {
            locationManager = (LocationManager)(Forms.Context.GetSystemService(Context.LocationService));
        }

        public Task<bool> ShouldRequestPermission()
        {
            DependencyService.Get<IActivityService>().DisplayLocationSettingsRequest();
            return Task.FromResult(true);
        }

        protected override bool LocationServiceEnabled()
        {
            try
            {
                return locationManager.IsProviderEnabled(LocationManager.GpsProvider);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}