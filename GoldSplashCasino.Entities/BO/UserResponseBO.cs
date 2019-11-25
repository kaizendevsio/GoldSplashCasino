using System.Collections.Generic;
using GoldSplashCasino.Entities.DTO;

namespace GoldSplashCasino.Entities.BO
{
    public class UserResponseBO : ApiResponseBO
    {
        public TblUserAuth UserAuth { get; set; }
        public TblUserInfo UserInfo { get; set; }
        public TblUserRole UserRole { get; set; }
        public List<UserWalletBO> UserWallet { get; set;}
    }
}
