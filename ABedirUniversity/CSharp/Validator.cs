using ABedirUniversity.CSharp.DataModels;
using System;

namespace ABedirUniversity.CSharp
{
    public static class Validator
    {
        public static SecurityInformation ValidateSecurityInfoInput(string _userName, string _inputPassword, string _userStatus, string _userType)
        {
            SecurityInformation securityInformation = new SecurityInformation
            {
                IsValid = true
            };
            if (string.IsNullOrEmpty(_userName))
            {
                securityInformation.IsValid = false;
                securityInformation.ValidationError += "Username Invalid. ";
            }
            else
            {
                securityInformation.Username = _userName;
            }

            if (string.IsNullOrEmpty(_inputPassword))
            {
                securityInformation.IsValid = false;
                securityInformation.ValidationError += "Password Invalid. ";
            }
            else
            {
                string salt = PasswordManager.GenerateSalt();
                string hashedPassword = PasswordManager.HashPassword(_inputPassword, salt);
                securityInformation.PasswordSalt = salt;
                securityInformation.HashedPassword = hashedPassword;
            }

            if (string.IsNullOrEmpty(_userStatus))
            {
                securityInformation.IsValid = false;
            }
            else
            {
                securityInformation.UserStatus = _userStatus;
            }

            if (string.IsNullOrEmpty(_userType))
            {
                securityInformation.IsValid = false;
            }
            else
            {
                securityInformation.UserType = _userType;
            }
            securityInformation.IPAddress = CustomUtilities.GetIPAddress();
            securityInformation.LastLoginDate = DateTime.Now;
            securityInformation.UserCreateDate = DateTime.Now;

            return securityInformation;
        }
        public static PersonalInformation ValidatePersonalInfoInput(string _firstName, string _lastName, string _phoneNumber, string _emailAddress)
        {
            PersonalInformation personalInfo = new PersonalInformation
            {
                IsValid = true
            };
            if (string.IsNullOrEmpty(_firstName))
            {
                personalInfo.IsValid = false;
                personalInfo.ValidationError += "First Name Invalid. ";
            }
            else
            {
                personalInfo.FirstName = _firstName;
            }
            if (string.IsNullOrEmpty(_lastName))
            {
                personalInfo.IsValid = false;
                personalInfo.ValidationError += "Last Name Invalid. ";
            }
            else
            {
                personalInfo.LastName = _lastName;
            }
            if (string.IsNullOrEmpty(_phoneNumber))
            {
                personalInfo.IsValid = false;
                personalInfo.ValidationError += "Phone Number Invalid. ";
            }
            else
            {
                personalInfo.PhoneNumber = _phoneNumber;
            }
            if (string.IsNullOrEmpty(_emailAddress))
            {
                personalInfo.IsValid = false;
                personalInfo.ValidationError += "Email Address Invalid. ";
            }
            else
            {
                personalInfo.EmailAddress = _emailAddress;
            }
            return personalInfo;
        }
        public static AddressInformation ValidateAddressInfoInput(string _address, string _address2, string _city, string _state, string _zipCode)
        {
            AddressInformation addressInfo = new AddressInformation
            {
                IsValid = true
            };
            if (string.IsNullOrEmpty(_address))
            {
                addressInfo.IsValid = false;
                addressInfo.ValidationError += "Address Invalid. ";
            }
            else
            {
                addressInfo.Address = _address;
            }
            if (string.IsNullOrEmpty(_address2))
            {
                addressInfo.IsValid = false;
                addressInfo.ValidationError += "Address 2 Invalid. ";
            }
            else
            {
                addressInfo.Address2 = _address2;
            }
            if (string.IsNullOrEmpty(_city))
            {
                addressInfo.IsValid = false;
                addressInfo.ValidationError += "City Invalid. ";
            }
            else
            {
                addressInfo.City = _city;
            }
            if (string.IsNullOrEmpty(_state))
            {
                addressInfo.IsValid = false;
                addressInfo.ValidationError += "State Invalid. ";
            }
            else
            {
                addressInfo.State = _state;
            }
            if (string.IsNullOrEmpty(_zipCode))
            {
                addressInfo.IsValid = false;
                addressInfo.ValidationError += "Zip Code Invalid. ";
            }
            else
            {
                addressInfo.ZipCode = _zipCode;
            }
            return addressInfo;
        }
    }
}