using ABedirUniversity.CSharp;
using System;

namespace ABedirUniversity.WebForms
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginSubmitBtn_Click(object sender, EventArgs e)
        {
            string validationResult = PasswordManager.ValidateUser(usernameInput.Value, passwordInput.Value, "student");
            switch (validationResult)
            {
                case "Active":
                    HideErrorMsg();
                    Session["user"] = usernameInput.Value;
                    Response.Redirect("StudentForms/Home.aspx");
                    break;
                case "Pending":
                    ShowErrorMsg("Your application is still pending. Please try again later.");
                    break;
                case "Declined":
                    ShowErrorMsg("Your application was declined. Please contact support.");
                    break;
                default:
                    ShowErrorMsg();
                    break;
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