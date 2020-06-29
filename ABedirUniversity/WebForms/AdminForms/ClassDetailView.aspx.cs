using ABedirUniversity.CSharp;
using System;

namespace ABedirUniversity.WebForms.AdminForms
{
    public partial class ClassDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/AdminLogin.aspx");
            }
            else
            {
                string classIdQueryString = Request.QueryString["classid"];
                if (string.IsNullOrEmpty(classIdQueryString))
                {
                    //In case there is no query string, redirect back to class list.
                    Response.Redirect("ClassList.aspx");
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
            var classDetails = SQLDataAccess.GetClassDetails(classId);
            if (classDetails == null)
            {
                ClassDetailsLabel.Text = "Sorry could not find details for class: " + classId;
            }
            else
            {
                ClassDetailsLabel.Text = "Details for class id: " + classId;
                ClassGridView.DataSource = classDetails;
                ClassGridView.DataBind();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            SQLDataAccess.DeleteClass(hiddenClassID.Value);
        }
    }
}