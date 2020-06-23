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
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Xamarin.Forms;

namespace MapApp.Droid
{
    [Activity(Label = "MapApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance { get; private set; }

        public const int REQUEST_CHECK_SETTINGS = 0x1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.FormsMaps.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Instance = this;
            DependencyService.RegisterSingleton<IActivityService>(new ActivityService(this));

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// ทำงานหลัง Google API แสดงเสร็จ
        /// </summary>
        protected override void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent data)
        {
            switch (requestCode)
            {
                case REQUEST_CHECK_SETTINGS:
                    {
                        switch (resultCode)
                        {
                            case Android.App.Result.Ok:
                                {
                                    OpenApplicationSetting();
                                    break;
                                }
                            case Android.App.Result.Canceled:
                                {

                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// จะทำงานเมื่อ USER ตอบตกลง
        /// </summary>
        async void OpenApplicationSetting() {
            bool isShowGPSPermissionDialog = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
            bool isGpsDeviceEnabled = DependencyService.Get<ILocation>().IsGpsEnabled();
            var gspPermissionAppStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (isGpsDeviceEnabled)
            {
                if (isShowGPSPermissionDialog) await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                else
                {
                    if (gspPermissionAppStatus != PermissionStatus.Granted) DependencyService.Get<IActivityService>().OpenApplicationInfoSetting();
                }
            }
        }

    }
}