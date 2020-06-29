using ABedirUniversity.CSharp;
using Xunit;

namespace TestLibrary
{
    public class PasswordTests
    {
        [Fact]
        public void ShouldValidateSecurity()
        {
            string plaintextshouldnotequal = "testpasswordtestsalt";

            string actual = PasswordManager.HashPassword("testpassword", "testsalt");

            Assert.NotEqual(plaintextshouldnotequal, actual);
        }
    }
}
