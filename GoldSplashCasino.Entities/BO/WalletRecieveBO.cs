using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.Entities.BO
{
   public class WalletRecieveBO : AddressBO
    {
        public string CallbackUrl { get; set; }
    }
}
