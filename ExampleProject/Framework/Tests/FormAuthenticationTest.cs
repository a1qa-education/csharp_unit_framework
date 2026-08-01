using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class FormAuthenticationTest : BaseTest
    {
        private LoginPage loginPage = new();
        private SecureAreaPage secureAreaPage = new();

        [Test]
        public void LoginTest()
        {
            mainPage.ClickNavigationLink(MainPageNavigation.FormAuthentication);

            loginPage.Login(testdata.GetValue<string>("login.username"), testdata.GetValue<string>("login.password"));
            
            Assert.That(secureAreaPage.IsSuccessMessageDisplayed(), Is.True, "Success message is not displayed");

            secureAreaPage.ClickLogout();

            Assert.That(loginPage.State.WaitForDisplayed(), Is.True, "Login page is not opened");
        }
    }
}
