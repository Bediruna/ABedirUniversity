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
            bool successfulUpdate = SQLDataAccess.UpdateApplicationStatus(hiddenApplicationID.Value, "Active");
            if (successfulUpdate)
            {
                Response.Redirect("/WebForms/AdminForms/StudentApplicationList.aspx");
            }
            else
            {
                ShowErrorMsg("There was an issue processing your request. Please try again later.");
            }
        }

        protected void DeclineButton_Click(object sender, EventArgs e)
        {
            SQLDataAccess.UpdateApplicationStatus(hiddenApplicationID.Value, "Declined");
        }

        protected void ApplicationGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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