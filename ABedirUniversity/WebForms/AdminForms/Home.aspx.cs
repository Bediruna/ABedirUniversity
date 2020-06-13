using ABedirUniversity.CSharp;
using System;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms.AdminForms
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/AdminLogin.aspx");
            }
            else
            {
                string username = Session["user"].ToString();
                UsernameLabel.Text = "Welcome " + username;

                NewApplicationsGridView.DataSource = SQLDataAccess.GetNewStudentApplications();
                NewApplicationsGridView.DataBind();
            }
        }

        protected void NewApplicationsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "location.href = 'StudentApplicationDetailView.aspx?applicationid=" + e.Row.Cells[0].Text + "';";
                e.Row.ToolTip = "Click to view details";
            }
        }
    }
}