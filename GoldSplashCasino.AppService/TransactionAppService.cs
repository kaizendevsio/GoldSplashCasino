using System;
using System.Collections.Generic;
using System.Text;
using GoldSplashCasino.DataAccessLayer;
using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.Entities.DTO;
using GoldSplashCasino.Entities.Enums;

namespace GoldSplashCasino.AppService
{
   public class TransactionAppService
    {
        public bool CreateWithdrawalRequest(WalletTransactionBO walletTransactionBO)
        {
            using (var db = new dbGSCasinoContext())
            {
                UserWithdrawRequestRepository userWithdrawRequestRepository = new UserWithdrawRequestRepository();

                TblUserWithdrawalRequest userWithdrawalRequest = new TblUserWithdrawalRequest();
                userWithdrawalRequest.Address = walletTransactionBO.To;
                userWithdrawalRequest.TotalAmount = (decimal)walletTransactionBO.Amount;
                userWithdrawalRequest.WithdrawalStatus = (short)WithdrawalRequestStatus.Pending;
                userWithdrawalRequest.SourceWalletTypeId = 12;


                userWithdrawRequestRepository.Create(userWithdrawalRequest, db);
            }

            return true;
        }

        public List<UserTransactionHistoryBO> Get(TransactionQueryBO transactionQuery) {

            using (var db = new dbGSCasinoContext())
            {
                List<UserTransactionHistoryBO> userWithdrawalHistoryBOs = new List<UserTransactionHistoryBO>();
                UserDepositRequestRepository userDepositRequest = new UserDepositRequestRepository();
                UserWithdrawRequestRepository withdrawRequestRepository = new UserWithdrawRequestRepository();

                List<TblUserDepositRequest> tblUserDeposits = new List<TblUserDepositRequest>();
                List<TblUserWithdrawalRequest> userWithdrawalRequests = new List<TblUserWithdrawalRequest>();

                switch (transactionQuery.TransactionType)
                {
                    case TransactionType.All:
 
                        tblUserDeposits = userDepositRequest.Get(transactionQuery, db);

                        for (int i = 0; i < tblUserDeposits.Count; i++)
                        {
                            UserTransactionHistoryBO withdrawalHistory = new UserTransactionHistoryBO();
                            withdrawalHistory.Address = tblUserDeposits[i].Address;
                            withdrawalHistory.ID = tblUserDeposits[i].Id;
                            withdrawalHistory.RequestedOn = tblUserDeposits[i].CreatedOn;
                            withdrawalHistory.TotalAmount = tblUserDeposits[i].Amount;
                            withdrawalHistory.WithdrawalStatus = (WithdrawalRequestStatus)tblUserDeposits[i].DepositStatus;
                            withdrawalHistory.MemberCode = tblUserDeposits[i].UserAuth.UserInfo.Uid;
                            withdrawalHistory.MemberEmail = tblUserDeposits[i].UserAuth.UserInfo.Email;
                            withdrawalHistory.MemberName = String.Format("{0} {1}", tblUserDeposits[i].UserAuth.UserInfo.FirstName, tblUserDeposits[i].UserAuth.UserInfo.LastName);
                            withdrawalHistory.Txid = tblUserDeposits[i].GetHashCode().ToString();

                            userWithdrawalHistoryBOs.Add(withdrawalHistory);
                        }

                        userWithdrawalRequests = withdrawRequestRepository.Get(transactionQuery, db);

                        for (int i = 0; i < userWithdrawalRequests.Count; i++)
                        {
                            UserTransactionHistoryBO withdrawalHistory = new UserTransactionHistoryBO();
                            withdrawalHistory.Address = userWithdrawalRequests[i].Address;
                            withdrawalHistory.ID = userWithdrawalRequests[i].Id;
                            withdrawalHistory.RequestedOn = userWithdrawalRequests[i].CreatedOn;
                            withdrawalHistory.TotalAmount = userWithdrawalRequests[i].TotalAmount;
                            withdrawalHistory.WithdrawalStatus = (WithdrawalRequestStatus)userWithdrawalRequests[i].WithdrawalStatus;
                            withdrawalHistory.MemberCode = userWithdrawalRequests[i].UserAuth.UserInfo.Uid;
                            withdrawalHistory.MemberEmail = userWithdrawalRequests[i].UserAuth.UserInfo.Email;
                            withdrawalHistory.MemberName = String.Format("{0} {1}", userWithdrawalRequests[i].UserAuth.UserInfo.FirstName, userWithdrawalRequests[i].UserAuth.UserInfo.LastName);
                            withdrawalHistory.Txid = userWithdrawalRequests[i].GetHashCode().ToString();

                            userWithdrawalHistoryBOs.Add(withdrawalHistory);
                        }

                        break;
                    case TransactionType.Sent:
                        break;
                    case TransactionType.Received:
                        break;
                    case TransactionType.Deposit:

                        tblUserDeposits = userDepositRequest.Get(transactionQuery, db);

                        for (int i = 0; i < tblUserDeposits.Count; i++)
                        {
                            UserTransactionHistoryBO withdrawalHistory = new UserTransactionHistoryBO();
                            withdrawalHistory.Address = tblUserDeposits[i].Address;
                            withdrawalHistory.ID = tblUserDeposits[i].Id;
                            withdrawalHistory.RequestedOn = tblUserDeposits[i].CreatedOn;
                            withdrawalHistory.TotalAmount = tblUserDeposits[i].Amount;
                            withdrawalHistory.WithdrawalStatus = (WithdrawalRequestStatus)tblUserDeposits[i].DepositStatus;
                            withdrawalHistory.MemberCode = tblUserDeposits[i].UserAuth.UserInfo.Uid;
                            withdrawalHistory.MemberEmail = tblUserDeposits[i].UserAuth.UserInfo.Email;
                            withdrawalHistory.MemberName = String.Format("{0} {1}", tblUserDeposits[i].UserAuth.UserInfo.FirstName, tblUserDeposits[i].UserAuth.UserInfo.LastName);
                            withdrawalHistory.Txid = tblUserDeposits[i].GetHashCode().ToString();

                            userWithdrawalHistoryBOs.Add(withdrawalHistory);
                        }

                        break;
                    case TransactionType.Withdraw:

                        userWithdrawalRequests = withdrawRequestRepository.Get(transactionQuery, db);

                        for (int i = 0; i < userWithdrawalRequests.Count; i++)
                        {
                            UserTransactionHistoryBO withdrawalHistory = new UserTransactionHistoryBO();
                            withdrawalHistory.Address = userWithdrawalRequests[i].Address;
                            withdrawalHistory.ID = userWithdrawalRequests[i].Id;
                            withdrawalHistory.RequestedOn = userWithdrawalRequests[i].CreatedOn;
                            withdrawalHistory.TotalAmount = userWithdrawalRequests[i].TotalAmount;
                            withdrawalHistory.WithdrawalStatus = (WithdrawalRequestStatus)userWithdrawalRequests[i].WithdrawalStatus;
                            withdrawalHistory.MemberCode = userWithdrawalRequests[i].UserAuth.UserInfo.Uid;
                            withdrawalHistory.MemberEmail = userWithdrawalRequests[i].UserAuth.UserInfo.Email;
                            withdrawalHistory.MemberName = String.Format("{0} {1}", userWithdrawalRequests[i].UserAuth.UserInfo.FirstName, userWithdrawalRequests[i].UserAuth.UserInfo.LastName);
                            withdrawalHistory.Txid = userWithdrawalRequests[i].GetHashCode().ToString();

                            userWithdrawalHistoryBOs.Add(withdrawalHistory);
                        }
                        
                        break;
                    default:
                        break;
                }

                return userWithdrawalHistoryBOs;

            }          
        
        }
        
        public bool UpdateWithdrawalRequest(TransactionQueryBO transactionQueryBO)
        {
            using (var db = new dbGSCasinoContext())
            {
                UserWithdrawRequestRepository userWithdrawRequestRepository = new UserWithdrawRequestRepository();

                TblUserWithdrawalRequest userWithdrawalRequest = new TblUserWithdrawalRequest();
                userWithdrawalRequest.Id = transactionQueryBO.ID;
                userWithdrawalRequest.WithdrawalStatus = (short)transactionQueryBO.RequestStatus;


                userWithdrawRequestRepository.Update(userWithdrawalRequest,db);
            }

            return true;
        }

    }
}
