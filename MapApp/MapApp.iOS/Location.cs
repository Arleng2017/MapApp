using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLocation;
using Foundation;
using Plugin.Permissions;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapApp.iOS.Location))]
namespace MapApp.iOS
{
    public class Location : LocationBase, ILocation
    {
        protected override bool LocationServiceEnabled()
        {
            return CLLocationManager.LocationServicesEnabled;
        }

        protected override async Task EnableDeviceLocationService()
        {
            var shouldOpenAppSetting = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("บริการหาตำแหน่งที่ตั้งยังไม่ได้เปิดใช้งานในขณะนี้", "ไปที่ การตั้งค่า > ความเป็นส่วนตัว > เปิดใช้งาน บริการหาตำแหน่งที่ตั้ง", "การตั้งค่า", "ย้อนกลับ");
            if (shouldOpenAppSetting)
            {
                CrossPermissions.Current.OpenAppSettings();
            }
        }
    }
} 