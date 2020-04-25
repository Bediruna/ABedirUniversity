using ABedirUniversity.CSharp;
using System;

namespace ABedirUniversity.WebForms.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginSubmitBtn_Click(object sender, EventArgs e)
        {
            bool validation = PasswordManager.ValidatePassword(usernameInput.Value, passwordInput.Value, "admin");
            if (validation)
            {
                Session["user"] = usernameInput.Value;
                Response.Redirect("Admin/Home.aspx");
            }
        }
    }
}