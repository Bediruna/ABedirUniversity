using System;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class ClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/StudentLogin.aspx");
            }
            else
            {
            }
        }
    }
}