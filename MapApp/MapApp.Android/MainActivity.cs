using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Xamarin.Essentials;
using Android.Support.V4.App;
using Plugin.Permissions;
using System.Linq;
using Android;
using System.Threading.Tasks;
using Android.Util;
using Android.Content;

namespace MapApp.Droid
{
    [Activity(Label = "MapApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        readonly string[] PermissionsLocation = { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation };
        const int RequestLocationId = 0;

        const int RequestId = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
           // Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
            //if (grantResults[0] == Permission.Denied)
            //{
            //    Intent intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings,
            //        Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName));
            //    intent.AddFlags(ActivityFlags.NewTask);
            //    intent.AddFlags(ActivityFlags.MultipleTask);
            //    Android.App.Application.Context.StartActivity(intent);
            //}



            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}