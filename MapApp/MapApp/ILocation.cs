using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp
{
    public interface ILocation
    {
        bool IsGpsEnabled();
        bool IsNetworkEnabled();
        bool IsLocationEnabled();
        void OpenApplicationInfoSetting();
    }
}
