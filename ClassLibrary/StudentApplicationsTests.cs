using ABedirUniversity.CSharp;
using ABedirUniversity.CSharp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClassLibrary
{
    public class StudentApplicationsTests
    {
        [Fact]
        public void ValidateSecurityInfo_ShouldValidate()
        {
            SecurityInformation expectedSI = new SecurityInformation();

            SecurityInformation actualSI = Validator.ValidateSecurityInfoInput("TestUserName", "testpassword", "pending", "student");

            Assert.Equal(expectedSI, actualSI);
        }
    }
}
