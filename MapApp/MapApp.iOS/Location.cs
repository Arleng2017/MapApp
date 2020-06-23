using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MapApp.iOS.Location))]
namespace MapApp.iOS
{
    public class Location : ILocation
    {
        public Location()
        {
        }

        public bool IsGpsEnabled()
        {
            return CLLocationManager.LocationServicesEnabled;
        }

        public void OpenApplicationInfoSetting()
        {
            throw new NotImplementedException();
        }
    }
}