using ABedirUniversity.CSharp;
using System;

namespace ABedirUniversity.WebForms
{
    public partial class StudentApplicationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitApplicationBtn_Click(object sender, EventArgs e)
        {
            //validate input first
            string salt = PasswordManager.GenerateSalt();
            StudentApplicationDetails application = new StudentApplicationDetails
            {
                Status = "Pending",
                FirstName = inputFirstName.Value,
                LastName = inputLastName.Value,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                UserName = inputUsername.Value,
                HashedPassword = PasswordManager.HashPassword(inputPassword.Value, salt),
                PasswordSalt =  salt,
                Email = inputEmail.Value,
                PhoneNumber = inputPhoneNumber.Value,
                Address1 = inputAddress.Value,
                Address2 = inputAddress2.Value,
                City = inputCity.Value,
                State = inputState.Value,
                ZipCode = inputZip.Value
            };

            if (SQLDataAccess.SaveApplication(application))
            {
                applicationDiv.Visible = false;
                successDiv.Visible = true;
            }
        }
    }
}