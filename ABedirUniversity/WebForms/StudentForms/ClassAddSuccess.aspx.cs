using ABedirUniversity.CSharp;
using System;

namespace ABedirUniversity.WebForms.StudentForms
{
    public partial class ClassAddSuccess : System.Web.UI.Page
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
                string termIdQueryString = Request.QueryString["termid"];
                if (string.IsNullOrEmpty(classIdQueryString) || string.IsNullOrEmpty(termIdQueryString))
                {
                    Response.Redirect("AddClassPage.aspx");
                }
                else
                {
                    if (int.TryParse(classIdQueryString, out int classIdInt) && int.TryParse(termIdQueryString, out int termIdInt))
                    {
                        SQLDataAccess.AddClassToTerm(termIdInt, classIdInt);
                        Response.Redirect("AddClassPage.aspx");
                    }
                }
            }

        }
    }
}