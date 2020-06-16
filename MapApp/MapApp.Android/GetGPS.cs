using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MapApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(GetGPS))]
namespace MapApp.Droid
{
    public class GetGPS : IGetGPS
    {
        LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
        void IGetGPS.GetGPS()
        {
            if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                intent.AddFlags(ActivityFlags.NewTask);
                intent.AddFlags(ActivityFlags.MultipleTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }

        bool IGetGPS.CheckStatus()
        {
            //var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            //var c = LM.IsLocationEnabled;
            if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false) return false;
            else return true;
        }
    }
}