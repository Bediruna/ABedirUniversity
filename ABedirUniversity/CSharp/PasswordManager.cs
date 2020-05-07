using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ABedirUniversity.CSharp
{
    public static class PasswordManager
    {
        public static string ValidateUser(string username, string inputPassword, string applicantType)
        {
            var securityInfo = SQLDataAccess.GetSecurityInfo(username, applicantType);
            if (securityInfo == null)
            {
                return "error";
            }
            else
            {
                if (string.IsNullOrEmpty(securityInfo.Status) ||
                    string.IsNullOrEmpty(securityInfo.HashedPassword) ||
                    string.IsNullOrEmpty(securityInfo.PasswordSalt))
                {
                    return "error";
                }
                else
                {
                    string hashedInputPassword = HashPassword(inputPassword, securityInfo.PasswordSalt);
                    if (securityInfo.HashedPassword.Equals(hashedInputPassword))
                    {
                        return securityInfo.Status;
                    }
                    else
                    {
                        return "invalid";
                    }
                }
            }
        }
        public static string GenerateSalt()
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider randomCryptoNumber = new RNGCryptoServiceProvider();
            byte[] byteArray = new byte[16];
            randomCryptoNumber.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }

        public static string HashPassword(string passwordString, string saltString)
        {
            byte[] passwordByteArray = Encoding.UTF8.GetBytes(passwordString);
            byte[] saltByteArray = Encoding.UTF8.GetBytes(saltString);
            byte[] saltedValue = passwordByteArray.Concat(saltByteArray).ToArray();
            byte[] hashedPasswordByteArray = new SHA256Managed().ComputeHash(saltedValue);
            return Convert.ToBase64String(hashedPasswordByteArray);
        }
    }
}