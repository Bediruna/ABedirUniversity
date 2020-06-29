using ABedirUniversity.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class ClassDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["studentid"] == null)
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
                        DisplayClassDetails(classIdInt);
                    }
                }
            }
        }
        private void DisplayClassDetails(int classId)
        {
            var term = SQLDataAccess.GetClassDetails(classId);
            if (term == null)
            {
                ClassDetailsLabel.Text = "Sorry could not find details for class: " + classId;
            }
            else
            {
                ClassDetailsLabel.Text = "Details for class id: " + classId;
                ClassDetailGridView.DataSource = term;
                ClassDetailGridView.DataBind();


                AssignmentsGridView.DataSource = SQLDataAccess.GetClassAssignments(classId);
                AssignmentsGridView.DataBind();
            }
        }

        protected void AddAssignmentButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAssignmentPage.aspx?classid=" + hiddenClassID.Value);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            SQLDataAccess.RemoveClassFromTerm(hiddenClassID.Value);
        }

        protected void AssignemntsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "location.href = 'AssignmentDetailView.aspx?assignmentid=" + e.Row.Cells[0].Text + "';";
                e.Row.ToolTip = "Click to view details";
            }
        }
    }
}