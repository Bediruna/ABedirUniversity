using System;

namespace ABedirUniversity.WebForms.AdminForms
{
    public partial class ActiveStudentsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/AdminLogin.aspx");
            }
            else
            {
            }
        }
    }
}