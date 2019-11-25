using System;
using System.Collections.Generic;
using System.Text;
using GoldSplashCasino.Entities.Enums;

namespace GoldSplashCasino.Entities.BO
{
    public class TransactionQueryBO
    {
        public long ID { get; set; }
        public string FilterString { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public SortingType SortingType { get; set; }
        public WithdrawalRequestStatus RequestStatus { get; set; }
    }
}
