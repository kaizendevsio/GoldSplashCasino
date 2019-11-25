using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.Entities.BO
{
   public class WalletBO : BaseAuditBO
    {
        public string xPub{ get; set; }
        public string xPriv { get; set; }
        public ValueBO Balance { get; set; }
    }
}
