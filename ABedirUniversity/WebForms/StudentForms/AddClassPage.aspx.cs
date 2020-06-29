using ABedirUniversity.CSharp;
using System;
using System.Web.UI.WebControls;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class AddClassPage : System.Web.UI.Page
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
                    hiddenTermID.Value = termIdQueryString;

                    ClassesGridView.DataSource = SQLDataAccess.GetClasses();
                    ClassesGridView.DataBind();
                }
            }
        }

        protected void ClassesGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "location.href = 'ClassAddSuccess.aspx?classid=" + e.Row.Cells[0].Text + "&termid="+ hiddenTermID.Value + "';";
                e.Row.ToolTip = "Click to view details";
            }
        }
    }
}