using ABedirUniversity.CSharp;
using System;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms
{
    public partial class StudentApplicationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) { 
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                ApplicationsGridView.DataSource = SQLDataAccess.GetApplications();
                ApplicationsGridView.DataBind();
            }
        }

        protected void ApplicationsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pName = ApplicationsGridView.SelectedRow.Cells[1].Text;
        }

        protected void ApplicationsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "location.href = 'StudentApplicationDetailView.aspx?applicationid=" + e.Row.Cells[0].Text + "';";
                e.Row.ToolTip = "Click to view details";
            }
        }
    }
}