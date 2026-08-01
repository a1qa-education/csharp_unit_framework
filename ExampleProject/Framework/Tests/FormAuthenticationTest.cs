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

            Assert.That(loginPage.State.WaitForDisplayed(), Is.True, "Form Authentication page is not open");

            loginPage.Login(testdata.GetValue<string>("login.username"), testdata.GetValue<string>("login.password"));
            
            Assert.That(secureAreaPage.GetSuccessMessageText().Contains("You logged into a secure area!"), Is.True, "Success message is not displayed");

            secureAreaPage.ClickLogout();

            Assert.That(loginPage.State.WaitForDisplayed(), Is.True, "Login page is not opened");
        }
    }
}
