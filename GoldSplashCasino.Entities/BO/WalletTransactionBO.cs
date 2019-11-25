﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.Entities.BO
{
  public class WalletTransactionBO : BaseAuditBO
    {
        public string From{ get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
        public string TxHash { get; set; }
    }
}
