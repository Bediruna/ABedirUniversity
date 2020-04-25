using ABedirUniversity.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginSubmitBtn_Click(object sender, EventArgs e)
        {
            bool validation = PasswordManager.ValidatePassword(usernameInput.Value, passwordInput.Value);
            if (validation)
            {
                Session["user"] = usernameInput.Value;
                //Response.Redirect("StudentApplicationList.aspx");
            }
        }
    }
}