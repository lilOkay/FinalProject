using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {//bize token oluşturacak mekanizma user için eğer bize verdiği bilgi doğruysa veritabanından claimlerini buluşturacak ve orada jwt üretecek ve onları hooop buraya vericek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
