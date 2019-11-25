using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.Entities.Enums
{
    [Flags]
    public enum AccessRole : int
    {
        None = 0,
        Admin = 1,
        Client = 2,
        SuperAdmin = 3,
        Default = 4,
        Support = 5,
        Free = 10
    }
}
