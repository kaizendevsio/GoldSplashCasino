using System.Collections.Generic;
using GoldSplashCasino.Entities.DTO;
using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.AppService;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using GoldSplashCasino.Entities.Enums;

namespace GoldSplashCasino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("Withdrawal/Create")]
        public ActionResult CreateWithdrawalRequest([FromBody] AddressBO addressBO)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserResponseBO _apiResponse = new UserResponseBO();

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "Transaction successful";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                ApiResponseBO _apiResponse = new ApiResponseBO();
                _apiResponse.HttpStatusCode = "400";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

                return BadRequest(_apiResponse);
            }

        }

        //TODO: UPADTE REPOSITORY
             
        [HttpGet("Withdrawal/Update")]
        public ActionResult UpdateWithdrawalRequest(TransactionQueryBO transactionQuery)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserResponseBO _apiResponse = new UserResponseBO();
                TransactionAppService transactionAppService = new TransactionAppService();
                transactionAppService.UpdateWithdrawalRequest(transactionQuery);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "Transaction successful";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                ApiResponseBO _apiResponse = new ApiResponseBO();
                _apiResponse.HttpStatusCode = "400";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

                return BadRequest(_apiResponse);
            }
        }

        [HttpGet("Withdrawal/BackupFunds")]
        public ActionResult BackupFunds()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserResponseBO _apiResponse = new UserResponseBO();

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "Transaction successful";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                ApiResponseBO _apiResponse = new ApiResponseBO();
                _apiResponse.HttpStatusCode = "400";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

                return BadRequest(_apiResponse);
            }
        }

        [HttpPost("Send")]
        public ActionResult Send([FromBody] WalletTransactionBO walletTransaction)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                UserResponseBO _apiResponse = new UserResponseBO();

                TransactionAppService transactionAppService = new TransactionAppService();
                transactionAppService.CreateWithdrawalRequest(walletTransaction);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "Transaction successful";
                _apiResponse.Status = "Success";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                ApiResponseBO _apiResponse = new ApiResponseBO();
                _apiResponse.HttpStatusCode = "400";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

                return BadRequest(_apiResponse);
            }
        }

        [HttpPost("Receive")]
        public ActionResult Receive([FromBody] WalletRecieveBO walletRecieve)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                WalletRecieveBO wallet = new WalletRecieveBO();
                wallet.AddressString = "Cardano wallet address";
                wallet.CallbackUrl = "Your callback url";

                return Ok(wallet);
            }
            catch (Exception ex)
            {
                ApiResponseBO _apiResponse = new ApiResponseBO();
                _apiResponse.HttpStatusCode = "400";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

                return BadRequest(_apiResponse);
            }
        }

        [HttpPost("History")]
        public ActionResult History([FromBody] TransactionQueryBO transactionQuery)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                TransactionAppService transactionAppService = new TransactionAppService();
                List<UserTransactionHistoryBO> userTransactionHistories = transactionAppService.Get(transactionQuery);

                return Ok(userTransactionHistories);
            }
            catch (Exception ex)
            {
                ApiResponseBO _apiResponse = new ApiResponseBO();
                _apiResponse.HttpStatusCode = "400";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

                return BadRequest(_apiResponse);
            }

        }

    }
}