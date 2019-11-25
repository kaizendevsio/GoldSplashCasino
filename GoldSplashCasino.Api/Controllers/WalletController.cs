using System.Collections.Generic;
using GoldSplashCasino.Entities.DTO;
using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.AppService;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace GoldSplashCasino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        [HttpGet("Create")]
        public ActionResult Create()
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                WalletBO wallet = new WalletBO();
                wallet.xPriv = "Cardano private key";
                wallet.xPub = "Cardano public key";
                
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

        [HttpPost("GetBalance")]
        public ActionResult GetBalance([FromBody] AddressBO address)
        {
            try
            {
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                AddressBO addressBO = new AddressBO();
                addressBO.AddressString = address.AddressString;
                addressBO.Value.Amount = 10m;

                return Ok(addressBO);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetServerBalance")]
        public ActionResult GetServerBalance()
        {
            try
            {
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                ServerWalletBO serverWallet = new ServerWalletBO();
                serverWallet.ServerBalance = 10000;
                serverWallet.ServerDeposit = 2000;
                serverWallet.TransferedToColdWallet = 30m;

                return Ok(serverWallet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("Get")]
        public ActionResult GetWallet([FromBody] WalletBO wallet)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                List<WalletBO> walletBOs = new List<WalletBO>();
                WalletBO walletBO = new WalletBO();
                wallet.xPriv = "Cardano private key";
                wallet.xPub = "Cardano public key";
                wallet.Balance.Amount = 10m;

                walletBOs.Add(walletBO);

                return Ok(walletBOs);
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
     
        [HttpGet("History")]
        public ActionResult History([FromBody] WalletBO wallet)
        {
            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                List<WalletTransactionBO> walletTransactions = new List<WalletTransactionBO>();

                WalletTransactionBO walletTransaction = new WalletTransactionBO();
                walletTransaction.From = "from wallet address..";
                walletTransaction.To = "to wallet address..";
                walletTransaction.Amount = 100f;

                walletTransactions.Add(walletTransaction);

                walletTransaction.From = "from wallet address..";
                walletTransaction.To = "to wallet address..";
                walletTransaction.Amount = 100f;

                walletTransactions.Add(walletTransaction);

                return Ok(walletTransactions);
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