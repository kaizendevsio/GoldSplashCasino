using GoldSplashCasino.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GoldSplashCasino.Entities.BO;

namespace GoldSplashCasino.DataAccessLayer
{
   public class UserWithdrawRequestRepository
    {
        public bool Create(TblUserWithdrawalRequest userWithdrawalRequest, dbGSCasinoContext db)
        {
            db.TblUserWithdrawalRequest.Add(userWithdrawalRequest);
            db.SaveChanges();

            return true;
        }

        public List<TblUserWithdrawalRequest> Get(TransactionQueryBO transactionQuery, dbGSCasinoContext db)
        {
            // ENUMERATE ALL WALELT TYPES
            var _q = from a in db.TblUserWithdrawalRequest
                         //where a.WithdrawalStatus == (short)transactionQuery.RequestStatus
                         //&& a.CreatedOn >= transactionQuery.DateFrom && a.CreatedOn <= transactionQuery.DateTo

                     from UA in db.TblUserAuth where a.UserAuthId == UA.Id
                     join userInfo in db.TblUserInfo on UA.UserInfoId equals userInfo.Id

                     select new TblUserWithdrawalRequest
                     {
                         Id = a.Id,
                         Address = a.Address,
                         TotalAmount = a.TotalAmount,
                         CreatedOn = a.CreatedOn,
                         UserAuthId = a.UserAuthId,
                         WithdrawalStatus = a.WithdrawalStatus,
                         SourceWalletTypeId = a.SourceWalletTypeId,
                         TargetCurrencyId = a.TargetCurrencyId,
                         Remarks = a.Remarks,
                         CreatedBy = a.CreatedBy,
                         UserAuth = new TblUserAuth { Id = a.UserAuth.Id, UserInfo = UA.UserInfo, UserAlias = UA.UserAlias, UserName = UA.UserName }
                     };

            List<TblUserWithdrawalRequest> _qWalletTypeRes = _q.ToList<TblUserWithdrawalRequest>();

            return _qWalletTypeRes;
        }

        public bool Update(TblUserWithdrawalRequest tblUserWithdrawalRequest, dbGSCasinoContext db)
        {
            try
            {
                db.TblUserWithdrawalRequest.Update(tblUserWithdrawalRequest);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}
