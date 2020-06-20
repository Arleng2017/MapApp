using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.Gms.Tasks;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MapApp.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetGPS))]
namespace MapApp.Droid
{
    public class GetGPS : IGetGPS
    {
        LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);

        void IGetGPS.GetGPS()
        {
            //mainActivity.DisplayLocationSettingsRequest();

            //mainActivity.DisplayLocationSettingsRequest();
            //Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
            //intent.AddFlags(ActivityFlags.NewTask);
            //intent.AddFlags(ActivityFlags.MultipleTask);
            //Android.App.Application.Context.StartActivity(intent);
        }


        bool IGetGPS.CheckStatus() => LM.IsProviderEnabled(LocationManager.GpsProvider);

        public void OpenApplicationSetting()
        {
            Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName));
            intent.AddFlags(ActivityFlags.NewTask);
            intent.AddFlags(ActivityFlags.MultipleTask);
            Android.App.Application.Context.StartActivity(intent);
        }
        
    }

}