using System.Linq;
using GoldSplashCasino.Entities.DTO;
using GoldSplashCasino.Entities.BO;
using GoldSplashCasino.Entities.Enums;
using System;

namespace GoldSplashCasino.DataAccessLayer
{
    public class UserInfoRepository
    {
        public TblUserInfo Create(UserBO userBO, dbGSCasinoContext db)
        {
            TblUserInfo _userInfo = new TblUserInfo();
            _userInfo.FirstName = userBO.FirstName;
            _userInfo.LastName = userBO.LastName;
            _userInfo.PhoneNumber = userBO.PhoneNumber;
            _userInfo.Email = userBO.Email;
            _userInfo.Dob = userBO.Dob;
            _userInfo.CountryIsoCode2 = userBO.CountryIsoCode2;
            _userInfo.Gender = userBO.Gender;
            _userInfo.Uid = new Guid().ToString();
            _userInfo.IsEnabled = true;

            db.TblUserInfo.Add(_userInfo);
            db.SaveChanges();

            return _userInfo;
        }

        public TblUserInfo Get(TblUserAuth userAuth, dbGSCasinoContext db)
        {
            var _qUi = from a in db.TblUserInfo
                       where a.Id == userAuth.UserInfoId
                       select new TblUserInfo
                       {
                           FirstName = a.FirstName,
                           LastName = a.LastName,
                           Dob = a.Dob,
                           Email = a.Email,
                           PhoneNumber = a.PhoneNumber,
                           Gender = a.Gender,
                           Uid = a.Uid,
                           EmailStatus = a.EmailStatus,
                           CreatedOn = a.CreatedOn,
                           CountryIsoCode2 = a.CountryIsoCode2,
                           CompanyName = a.CompanyName

                       };

            TblUserInfo _tblUserInfo = _qUi.FirstOrDefault();
            return _tblUserInfo;
        }
    }
}
