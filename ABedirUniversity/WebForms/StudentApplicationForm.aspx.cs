using ABedirUniversity.CSharp;
using ABedirUniversity.CSharp.DataModels;
using System;

namespace ABedirUniversity.WebForms
{
    public partial class StudentApplicationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitApplicationBtn_Click(object sender, EventArgs e)
        {
            HideErrorMsg();
            if (SQLDataAccess.IsUsernameAvailable(InputUsername.Value, "student"))
            {
                SecurityInformation securityInformation = Validator.ValidateSecurityInfoInput(InputUsername.Value, InputPassword.Value, "pending", "student");
                PersonalInformation personalInformation = Validator.ValidatePersonalInfoInput(InputFirstName.Value, InputLastName.Value, InputPhoneNumber.Value, InputEmail.Value);
                AddressInformation addressInformation = Validator.ValidateAddressInfoInput(InputAddress.Value, InputAddress2.Value, InputCity.Value, InputState.Value, InputZip.Value);

                if (securityInformation.IsValid && personalInformation.IsValid && addressInformation.IsValid)
                {
                    int securityInfoId = SQLDataAccess.InsertSecurityInfo(securityInformation);
                    int personalInfoId = SQLDataAccess.InsertPersonalInfo(personalInformation);
                    int addressInfoId = SQLDataAccess.InsertAddressInfo(addressInformation);
                    if (securityInfoId != -1 && personalInfoId != -1 && addressInfoId != -1)
                    {
                        Student student = new Student
                        {
                            SecurityInfoID = securityInfoId,
                            PersonalInfoID = personalInfoId,
                            AddressInfoID = addressInfoId
                        };

                        int studentId = SQLDataAccess.InsertStudent(student);
                        if (studentId == -1)
                        {
                            ShowErrorMsg("There was an issue creating your profile. Please try again later.");
                        }
                        else
                        {
                            StudentApplication application = new StudentApplication
                            {
                                StudentID = studentId,
                                ApplicationStatus = "pending",
                                SubmitDateTime = DateTime.Now
                            };
                            int applicationNumber = SQLDataAccess.InsertStudentApplication(application);
                            if (applicationNumber == -1)
                            {
                                ShowErrorMsg("There was an issue submitting your application. Please try again later.");
                            }
                            else
                            {
                                ApplicationNumber.Text = applicationNumber.ToString();
                                ApplicationPanel.Visible = false;
                                SuccessPanel.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        ShowErrorMsg("There was an issue submitting your information. Please try again later.");
                        Logger.LogError("Error saving information to database.", "SubmitApplicationBtn_Click");
                    }
                }
                else
                {
                    ShowErrorMsg(securityInformation.ValidationError + personalInformation.ValidationError + addressInformation.ValidationError);
                    Logger.LogError("Error validating informations.", "SubmitApplicationBtn_Click");
                }
            }
            else
            {
                ShowErrorMsg("That username already exists");
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