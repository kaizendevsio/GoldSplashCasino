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
    public class SessionController : ControllerBase
    {
        public string USER_SESSION { get; private set; } = "USER_SESSION";
        public bool CreateSession([FromBody] UserResponseBO userAuthResponse, ISession session)
        {
            session.SetString(USER_SESSION, JsonConvert.SerializeObject(userAuthResponse.UserAuth));
            return true;
        }

        public TblUserAuth GetSession(ISession session)
        {
            string _currentUserSession = session.GetString(USER_SESSION);

            if (_currentUserSession != null)
            {
                TblUserAuth userAuth = JsonConvert.DeserializeObject<TblUserAuth>(_currentUserSession);
                return userAuth;
            }
            else
            {
                throw new System.ArgumentException("User session invalid or expired.");
            }

            

            
        }
    }
}
