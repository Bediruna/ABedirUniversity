using System;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("/WebForms/StudentLogin.aspx");
            }
            else
            {
                //string username = Session["user"].ToString();
                //UsernameLabel.Text = "Welcome " + username;
            }
        }
    }
}