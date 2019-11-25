using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.Entities.Enums
{
    public enum WithdrawalRequestStatus
    {
        None = 0,
        Pending = 1,
        Completed = 2,
        Canceled = 3,
        Rejected = 10
    }

}
