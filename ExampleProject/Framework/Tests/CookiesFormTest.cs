using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class CookiesFormTest : BaseTest
    {
        [Test]
        public void CheckCookiesFormCanBeHidden()
        {
            var welcomePage = new WelcomePage();

            welcomePage.ClickHereToGoLink();

            var cookieForm = new MainPage().GetCookieForm();

            cookieForm.ClickAcceptCookiesBtn();

            Assert.That(cookieForm.State.WaitForNotDisplayed(), Is.True, "Cookies form should be hidden");
        }
    }
}