using ABedirUniversity.CSharp;
using System;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class TermDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["studentid"] == null)
            {
                Response.Redirect("/WebForms/StudentLogin.aspx");
            }
            else
            {
                string termIdQueryString = Request.QueryString["termid"];
                if (string.IsNullOrEmpty(termIdQueryString))
                {
                    //In case there is no query string, redirect back to application list.
                    Response.Redirect("TermList.aspx");
                }
                else
                {
                    if (int.TryParse(termIdQueryString, out int termIdInt))
                    {
                        hiddenTermID.Value = termIdInt.ToString();
                        DisplayTermDetails(termIdInt);
                    }
                }
            }
        }
        private void DisplayTermDetails(int termId)
        {
            var term = SQLDataAccess.GetTermDetails(termId);
            if (term == null)
            {
                TermDetailsLabel.Text = "Sorry could not find details for term: " + termId;
            }
            else
            {
                TermDetailsLabel.Text = "Details for term id: " + termId;
                TermDetailGridView.DataSource = term;
                TermDetailGridView.DataBind();


                ClassesGridView.DataSource = SQLDataAccess.GetTermClasses(termId);
                ClassesGridView.DataBind();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            SQLDataAccess.DeleteTerm(hiddenTermID.Value);
        }

        protected void AddClassButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddClassPage.aspx?termid=" + hiddenTermID.Value);
        }

        protected void ClassesGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "location.href = 'ClassDetailView.aspx?classid=" + e.Row.Cells[0].Text + "';";
                e.Row.ToolTip = "Click to view details";
            }
        }
    }
}