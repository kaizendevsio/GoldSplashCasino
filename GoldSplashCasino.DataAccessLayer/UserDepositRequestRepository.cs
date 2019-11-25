using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.Entities.DTO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSplashCasino.DataAccessLayer
{
   public class UserDepositRequestRepository
    {
        public bool Create(TblUserDepositRequest userDepositRequest, dbGSCasinoContext db)
        {
            db.TblUserDepositRequest.Add(userDepositRequest);
            db.SaveChanges();

            return true;
        }
        public List<TblUserDepositRequest> Get(TransactionQueryBO transactionQuery, dbGSCasinoContext db)
        {
            // ENUMERATE ALL WALELT TYPES
            var _q = from UDR in db.TblUserDepositRequest

                     from UA in db.TblUserAuth where UDR.UserAuthId == UA.Id
                     join userInfo in db.TblUserInfo on UA.UserInfoId equals userInfo.Id

                     //where UDR.DepositStatus == (short)transactionQuery.RequestStatus
                     //&& a.CreatedOn >= transactionQuery.DateFrom && a.CreatedOn <= transactionQuery.DateTo

                     select new TblUserDepositRequest
                     {
                         Id = UDR.Id,
                         Address = UDR.Address,
                         Amount = UDR.Amount,
                         CreatedOn = UDR.CreatedOn,
                         UserAuthId = UDR.UserAuthId,
                         DepositStatus = UDR.DepositStatus,
                         SourceCurrencyId = UDR.SourceCurrencyId,
                         TargetWalletTypeId = UDR.TargetWalletTypeId,
                         Remarks = UDR.Remarks,
                         CreatedBy = UDR.CreatedBy,
                         UserAuth = new TblUserAuth { Id = UDR.UserAuth.Id,UserInfo = UA.UserInfo, UserAlias = UA.UserAlias, UserName = UA.UserName}
                     };

            
            List<TblUserDepositRequest> _qWalletTypeRes = _q.ToList<TblUserDepositRequest>();

            return _qWalletTypeRes;

        }


    }
}
