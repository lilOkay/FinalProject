using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {//hash oluşturur ve doğrular bu class
        public static void CreatePasswordHash
            (string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new  System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//her kullanıcı için bir key oluşturur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
                                                  //kullanıcının girdiği şifre
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//değerleri biz vereceğimiz için out olamamlı
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    }
}
