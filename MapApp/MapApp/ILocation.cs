using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MapApp
{
    public interface ILocation
    {
        Task<bool> CheckPermission();
        Task<bool> ShouldRequestPermission();
        Task EnableLocation();
    }
}
