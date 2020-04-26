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
            if (SQLDataAccess.IsUsernameAvailable(inputUsername.Value, "student"))
            {
                HideErrorMsg();

                //validate input first
                string salt = PasswordManager.GenerateSalt();
                StudentApplication application = new StudentApplication
                {
                    Status = "Pending",
                    FirstName = inputFirstName.Value,
                    LastName = inputLastName.Value,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Username = inputUsername.Value,
                    HashedPassword = PasswordManager.HashPassword(inputPassword.Value, salt),
                    PasswordSalt = salt,
                    Email = inputEmail.Value,
                    PhoneNumber = inputPhoneNumber.Value,
                    Address1 = inputAddress.Value,
                    Address2 = inputAddress2.Value,
                    City = inputCity.Value,
                    State = inputState.Value,
                    ZipCode = inputZip.Value,
                    ApplicantType = "student"
                };

                if (SQLDataAccess.SaveApplication(application))
                {
                    ApplicationPanel.Visible = false;
                    SuccessMsg.Visible = true;
                }
            }
            else
            {
                ShowErrorMsg("That username already exists");
            }
        }
        private void ShowErrorMsg(string errorMsg = "There was an error. Please try again later.")
        {
            ErrorLabel.Text = errorMsg;
            ErrorLabel.Visible = true;
        }
        private void HideErrorMsg()
        {
            ErrorLabel.Text = "";
            ErrorLabel.Visible = false;
        }
    }
}