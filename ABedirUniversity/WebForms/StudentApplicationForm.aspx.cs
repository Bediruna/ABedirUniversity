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
            if (SQLDataAccess.IsUsernameAvailable(InputUsername.Value, "student"))
            {
                HideErrorMsg();

                //validate input first
                string salt = PasswordManager.GenerateSalt();
                StudentApplication application = new StudentApplication
                {
                    Status = "Pending",
                    FirstName = InputFirstName.Value,
                    LastName = InputLastName.Value,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Username = InputUsername.Value,
                    HashedPassword = PasswordManager.HashPassword(InputPassword.Value, salt),
                    PasswordSalt = salt,
                    Email = InputEmail.Value,
                    PhoneNumber = InputPhoneNumber.Value,
                    Address1 = InputAddress.Value,
                    Address2 = InputAddress2.Value,
                    City = InputCity.Value,
                    State = InputState.Value,
                    ZipCode = InputZip.Value,
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