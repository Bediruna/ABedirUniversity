using ABedirUniversity.CSharp;
using ABedirUniversity.CSharp.DataModels;
using System;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class AddAssignmentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("/WebForms/StudentLogin.aspx");
            }
            else
            {
                string classIdQueryString = Request.QueryString["classid"];
                if (string.IsNullOrEmpty(classIdQueryString))
                {
                    //In case there is no query string, redirect back to application list.
                    Response.Redirect("TermList.aspx");
                }
                else
                {
                    if (int.TryParse(classIdQueryString, out int classIdInt))
                    {
                        hiddenClassID.Value = classIdInt.ToString();
                    }
                }
            }
        }

        protected void AddAssignmentBtn_Click(object sender, EventArgs e)
        {
            HideErrorMsg();
            Assignment assignmentToAdd = new Assignment
            {
                Name = InputAssignmentName.Value,
                Type = SelectAssignmentType.Value,
                Description = InputAssignmentDescription.Value
            };

            int assignmentId = SQLDataAccess.InsertAssignment(assignmentToAdd);

            if (assignmentId == -1)
            {
                ShowErrorMsg("There was an issue creating assignment. Please try again.");
            }
            else
            {
                SQLDataAccess.AddAssignmentToClass(Convert.ToInt32(hiddenClassID.Value), assignmentId);
            }
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