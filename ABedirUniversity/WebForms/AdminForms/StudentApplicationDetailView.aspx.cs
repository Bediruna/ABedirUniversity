using ABedirUniversity.CSharp;
using System;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms.AdminForms
{
    public partial class StudentApplicationDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/AdminLogin.aspx");
            }
            else
            {
                string applicationIdQueryString = Request.QueryString["applicationid"];
                if (string.IsNullOrEmpty(applicationIdQueryString))
                {
                    //In case there is no query string, redirect back to application list.
                    Response.Redirect("StudentApplicationList.aspx");
                }
                else
                {
                    if (int.TryParse(applicationIdQueryString, out int applicationIdInt))
                    {
                        hiddenApplicationID.Value = applicationIdInt.ToString();
                        DisplayApplicationDetails(applicationIdInt);
                    }
                }
            }
        }
        private void DisplayApplicationDetails(int applicationId)
        {
            var application = SQLDataAccess.GetApplicationDetails(applicationId);
            if (application == null)
            {
                ApplicationDetailsLabel.Text = "Sorry could not find details for application: " + applicationId;
            }
            else
            {
                ApplicationDetailsLabel.Text = "Details for student application id: " + applicationId;
                ApplicationGridView.DataSource = application;
                ApplicationGridView.DataBind();
            }
        }

        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            SQLDataAccess.UpdateApplicationStatus(hiddenApplicationID.Value, "Active");
        }

        protected void DeclineButton_Click(object sender, EventArgs e)
        {
            SQLDataAccess.UpdateApplicationStatus(hiddenApplicationID.Value, "Declined");
        }

        protected void ApplicationGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //int cellsToHide = 3;
            //for (int i = e.Row.Cells.Count - 1; i > e.Row.Cells.Count - 1 - cellsToHide; i--)
            //{
            //    e.Row.Cells[i].Visible = false;
            //}
        }
    }
}