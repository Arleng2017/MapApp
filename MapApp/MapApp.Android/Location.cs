﻿using System;
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
using Xamarin.Forms;

[assembly: Dependency(typeof(MapApp.Droid.Location))]
namespace MapApp.Droid
{
    public class Location : ILocation
    {
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
    }
}