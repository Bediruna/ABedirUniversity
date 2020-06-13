using ABedirUniversity.CSharp;
using ABedirUniversity.CSharp.DataModels;
using System;

namespace ABedirUniversity.WebForms.AdminForms
{
    public partial class CreateClassPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("/WebForms/AdminLogin.aspx");
            }
        }

        protected void CreateClassBtn_Click(object sender, EventArgs e)
        {
            HideErrorMsg();
            Class classToAdd = new Class
            {
                Name = InputClassName.Value,
                Description = InputClassDescription.Value
            };

            int classId = SQLDataAccess.InsertClass(classToAdd);

            if (classId == -1)
            {
                ShowErrorMsg("There was an issue creating class. Please try again.");
            }
            else
            {
                CreateClassFields.Visible = false;
                DisplayClassID.Text = classId.ToString();
                SuccessPanel.Visible = true;
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