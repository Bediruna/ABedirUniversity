using ABedirUniversity.CSharp;
using ABedirUniversity.CSharp.DataModels;
using System;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class AddTermPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("/WebForms/StudentLogin.aspx");
            }
        }
        protected void AddTermBtn_Click(object sender, EventArgs e)
        {
            HideErrorMsg();
            Term termToAdd = new Term
            {
                Name = InputTermName.Value,
                StartDate = Convert.ToDateTime(InputStartDate.Value),
                EndDate = Convert.ToDateTime(InputEndDate.Value)
            };

            int termId = SQLDataAccess.InsertTerm(termToAdd);

            if (termId == -1 || Session["studentid"] == null)
            {
                ShowErrorMsg("There was an issue creating term. Please try again.");
            }
            else
            {
                int studentId = (int)Session["studentid"];
                SQLDataAccess.InsertStudentTerm(studentId, termId);

                Response.Redirect("TermList.aspx");
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