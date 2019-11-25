using GoldSplashCasino.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.Entities.BO
{
  public class UserTransactionHistoryBO
    {
        public long ID { get; set; }
        public DateTime? RequestedOn { get; set; }
        public string MemberName { get; set; }
        public string MemberCode { get; set; }
        public string MemberEmail { get; set; }
        public string Address { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Txid { get; set; }
        public WithdrawalRequestStatus WithdrawalStatus { get; set; }
        public bool HasEntry { get; set; }
    }
}
