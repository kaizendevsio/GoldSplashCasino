﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldSplashCasino.AppService;
using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoldSplashCasino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("Create")]
        public ActionResult Create([FromBody] UserBO userBO)
        {
            UserAppService userAppService = new UserAppService();
            ApiResponseBO _apiResponse = new ApiResponseBO();

            try
            {
                userAppService.Create(userBO);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "User successfully created";
                _apiResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.InnerException.Message;
                _apiResponse.Status = "Error";
            }

            return Ok(_apiResponse);
        }

        [HttpPost("Authenticate")]
        public ActionResult Authenticate([FromBody] UserBO userBO)
        {
            
            UserAppService userAppService = new UserAppService();
            UserResponseBO _apiResponse = new UserResponseBO();
            if (ModelState.IsValid)
            {
                try
                {
                    UserResponseBO userAuthResponse = userAppService.Authenticate(userBO);

                    _apiResponse.UserInfo = userAuthResponse.UserInfo;
                    _apiResponse.UserWallet = userAuthResponse.UserWallet;
                    _apiResponse.UserRole = userAuthResponse.UserRole;

                    // SET SESSIONS
                    SessionController sessionController = new SessionController();
                    sessionController.CreateSession(userAuthResponse, HttpContext.Session);


                    _apiResponse.HttpStatusCode = "200";
                    _apiResponse.Message = "User successfully authenticated";
                    _apiResponse.Status = "Success";

                }
                catch (Exception ex)
                {
                    _apiResponse.HttpStatusCode = "500";
                    _apiResponse.Message = ex.Message;
                    _apiResponse.Status = "Error";
                }
            }
            else
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = "Please input the required credentials";
                _apiResponse.Status = "Error";
            }
            return Ok(_apiResponse);

        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] UserBO userBO)
        {
            UserAppService userAppService = new UserAppService();
            ApiResponseBO _apiResponse = new ApiResponseBO();

            try
            {
                userAppService.Create(userBO);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "User successfully created";
                _apiResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.InnerException.Message;
                _apiResponse.Status = "Error";
            }

            return Ok(_apiResponse);
        }

        [HttpDelete("Delete")]
        public ActionResult Delete()
        {
            UserWalletAppService userWalletAppService = new UserWalletAppService();
            UserResponseBO _apiResponse = new UserResponseBO();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                _apiResponse.UserWallet = userWalletAppService.GetBO(userAuth);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "UserWallet GET";
                _apiResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

            }

            return Ok(_apiResponse);
        }

        [HttpGet("Profile")]
        public ActionResult Profile()
        {
            UserResponseBO _apiResponse = new UserResponseBO();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                UserAppService userAppService = new UserAppService();
                TblUserInfo userInfo = userAppService.Get(userAuth);

                _apiResponse.UserInfo = userInfo;

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "UserProfile GET";
                _apiResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

            }

            return Ok(_apiResponse);
        }

        [HttpGet("Wallet")]
        public ActionResult Wallet()
        {
            UserWalletAppService userWalletAppService = new UserWalletAppService();
            UserResponseBO _apiResponse = new UserResponseBO();

            try
            {
                // GET SESSIONS
                SessionController sessionController = new SessionController();
                TblUserAuth userAuth = sessionController.GetSession(HttpContext.Session);

                _apiResponse.UserWallet = userWalletAppService.GetBO(userAuth);

                _apiResponse.HttpStatusCode = "200";
                _apiResponse.Message = "UserWallet GET";
                _apiResponse.Status = "Success";
            }
            catch (Exception ex)
            {
                _apiResponse.HttpStatusCode = "500";
                _apiResponse.Message = ex.Message;
                _apiResponse.Status = "Error";

            }

            return Ok(_apiResponse);
        }
    }
}