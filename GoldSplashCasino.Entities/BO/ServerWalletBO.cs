using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.Entities.BO
{
   public class ServerWalletBO
    {
        public decimal ServerBalance { get; set; }
        public decimal ServerDeposit { get; set; }
        public decimal TransferedToColdWallet { get; set; }
    }
}
