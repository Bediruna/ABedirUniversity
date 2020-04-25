using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ABedirUniversity.CSharp
{
    public static class PasswordManager
    {
        public static bool ValidatePassword(string username, string inputPassword)
        {
            string accountSalt = SQLDataAccess.GetAccountSalt(username);
            if (string.IsNullOrEmpty(accountSalt))
            {
                return false;
            }
            else
            {
                string hashedUserPassword = SQLDataAccess.GetHashedPassword(username);
                if (string.IsNullOrEmpty(hashedUserPassword))
                {
                    return false;
                }
                else
                {
                    string hashedInputPassword = HashPassword(inputPassword, accountSalt);
                    return hashedUserPassword.Equals(hashedInputPassword);
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