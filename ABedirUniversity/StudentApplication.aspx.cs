using System;

namespace ABedirUniversity
{
    public partial class StudentApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitApplicationBtn_Click(object sender, EventArgs e)
        {
            StudentApplicationModel application = new StudentApplicationModel
            {
                FirstName = inputFirstName.Value,
                LastName = inputLastName.Value,
                Username = inputUsername.Value,
                Password = inputPassword.Value,
                Email = inputEmail.Value,
                PhoneNumber = inputPhoneNumber.Value,
                Address1 = inputAddress.Value,
                Address2 = inputAddress2.Value,
                City = inputCity.Value,
                State = inputState.Value,
                Zip = inputZip.Value
            };

            if (SqliteDataAccess.SaveApplication(application))
            {
                applicationDiv.Visible = false;
                successDiv.Visible = true;
            }
        }
    }
}