using System;
using System.Collections.Generic;
using System.Text;

namespace MapApp
{
    public interface IGetGPS
    {
        void GetGPS();
        bool CheckStatus();
    }
}
