﻿using GoldSplashCasino.Entities.DTO;
using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.Entities.Enums;
using GoldSplashCasino.DataAccessLayer;
using System.Collections.Generic;

namespace GoldSplashCasino.AppService
{
    public class UserAppService
    {

        public UserResponseBO Authenticate(UserBO userBO)
        {
            using (var db = new dbGSCasinoContext())
            {
                UserAuthRepository userAuthRepository = new UserAuthRepository();
                TblUserAuth userAuth = userAuthRepository.Get(userBO, db);

                UserInfoRepository userInfoRepository = new UserInfoRepository();
                TblUserInfo userInfo = userInfoRepository.Get(userAuth, db);

                UserWalletRepository userWalletRepository = new UserWalletRepository();
                List<UserWalletBO> userWallet = userWalletRepository.GetBO(userAuth, db);

                UserRoleRepository userRoleRepository = new UserRoleRepository();
                TblUserRole userRole = userRoleRepository.Get(userAuth, db); 

                UserResponseBO userAuthResponse = new UserResponseBO();

                userAuthResponse.UserInfo = userInfo;
                userAuthResponse.UserWallet = userWallet;
                userAuthResponse.UserAuth = userAuth;
                userAuthResponse.UserRole = userRole;

                return userAuthResponse;
            }
        }

        public bool Create(UserBO userBO)
        {
            using (var db = new dbGSCasinoContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {

                    UserInfoRepository userInfoRepository = new UserInfoRepository();
                    TblUserInfo userInfo = userInfoRepository.Create(userBO, db);

                    UserAuthRepository userAuthRepository = new UserAuthRepository();
                    TblUserAuth userAuth = userAuthRepository.Create(userBO, userInfo, db);

                    UserRoleRepository userRoleRepository = new UserRoleRepository();
                    userRoleRepository.Create(userAuth, db);

                    // CREATE USER WALLETS
                    UserWalletAppService userWallet = new UserWalletAppService();
                    userWallet.Create(userAuth, db);

                    transaction.Commit();

                    return true;
                }
            }
        }

        public TblUserInfo Get(TblUserAuth userAuth)
        {
            using (var db = new dbGSCasinoContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {

                    UserInfoRepository userInfoRepository = new UserInfoRepository();
                    TblUserInfo userInfo = userInfoRepository.Get(userAuth, db);

                    return userInfo;
                }
            }
        }
    }
}
