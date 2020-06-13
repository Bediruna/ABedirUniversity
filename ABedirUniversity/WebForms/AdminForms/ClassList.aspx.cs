using ABedirUniversity.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms.AdminForms
{
    public partial class ClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/AdminLogin.aspx");
            }
            else
            {
                ClassesGridView.DataSource = SQLDataAccess.GetClasses();
                ClassesGridView.DataBind();
            }
        }

        protected void ClassesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}