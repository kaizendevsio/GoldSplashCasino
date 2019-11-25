﻿using System;
using System.Collections.Generic;

namespace GoldSplashCasino.Entities.DTO
{
    public partial class TblUserIncomeTransaction
    {
        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long UserAuthId { get; set; }
        public long? IncomeTypeId { get; set; }
        public decimal? IncomePercentage { get; set; }
        public short? TransactionType { get; set; }
        public long? TriggeredByUbpId { get; set; }
        public short? IncomeStatus { get; set; }
        public string Remarks { get; set; }

        public virtual TblUserAuth UserAuth { get; set; }
    }
}
