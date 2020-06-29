using ABedirUniversity.CSharp;
using System;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("/WebForms/StudentLogin.aspx");
            }
            else
            {
                string username = Session["username"].ToString();
                UsernameLabel.Text = "Welcome " + username;

                //CurrentClassesGridView.DataSource = SQLDataAccess.GetStudentClasses(username);
                //CurrentClassesGridView.DataBind();

                UpcomingAssignmentsGridView.DataSource = SQLDataAccess.GetNewStudentApplications();
                UpcomingAssignmentsGridView.DataBind();
            }
        }

        protected void CurrentClassesGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }

        protected void UpcomingAssignmentsGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }
    }
}