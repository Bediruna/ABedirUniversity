using ABedirUniversity.CSharp;
using System;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class AssignmentDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["studentid"] == null)
            {
                Response.Redirect("/WebForms/StudentLogin.aspx");
            }
            else
            {
                string assignmentIdQueryString = Request.QueryString["assignmentid"];
                if (string.IsNullOrEmpty(assignmentIdQueryString))
                {
                    //In case there is no query string, redirect back to application list.
                    Response.Redirect("TermList.aspx");
                }
                else
                {
                    if (int.TryParse(assignmentIdQueryString, out int assignmentIdInt))
                    {
                        hiddenAssignmentID.Value = assignmentIdInt.ToString();
                        DisplayAssignmentDetails(assignmentIdInt);
                    }
                }
            }
        }
        private void DisplayAssignmentDetails(int assignmentId)
        {
            var term = SQLDataAccess.GetAssignmentDetails(assignmentId);
            if (term == null)
            {
                AssignmentDetailsLabel.Text = "Sorry could not find details for assignment: " + assignmentId;
            }
            else
            {
                AssignmentDetailsLabel.Text = "Details for assignment id: " + assignmentId;
                AssignmentDetailGridView.DataSource = term;
                AssignmentDetailGridView.DataBind();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            SQLDataAccess.DeleteAssignment(hiddenAssignmentID.Value);
        }
    }
}