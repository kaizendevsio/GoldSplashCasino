using GoldSplashCasino.Entities.DTO;
using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.Entities.Enums;
using GoldSplashCasino.DataAccessLayer;
using System.Collections.Generic;

namespace GoldSplashCasino.AppService
{
    public class UserWalletAppService
    {
       public bool Create(TblUserAuth tblUserAuth, dbGSCasinoContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.Create(tblUserAuth, db);
            }
            else
            {
                using (db = new dbGSCasinoContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();  
                        transaction.Commit();

                        return userWalletRepository.Create(tblUserAuth, db);
                    }
                }
            }
           
        }

        public List<TblUserWallet> Get(TblUserAuth tblUserAuth, dbGSCasinoContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.Get(tblUserAuth, db);
            }
            else
            {
                using (db = new dbGSCasinoContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.Get(tblUserAuth, db);
                    }
                }
            }
            
        }
        public List<UserWalletBO> GetBO(TblUserAuth tblUserAuth, dbGSCasinoContext db = null)
        {
            if (db != null)
            {
                UserWalletRepository userWalletRepository = new UserWalletRepository();
                return userWalletRepository.GetBO(tblUserAuth, db);
            }
            else
            {
                using (db = new dbGSCasinoContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        UserWalletRepository userWalletRepository = new UserWalletRepository();
                        return userWalletRepository.GetBO(tblUserAuth, db);
                    }
                }
            }

        }

    }
}
