using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class CookiesPolicyTests : BaseTest
    {
        [Test]
        public void DismissCookiesBanner()
        {
            var cookieForm = new MainPage().GetCookieForm();

            Assert.That(cookieForm.State.WaitForDisplayed(), Is.True, "Cookies form should be displayed");

            cookieForm.ClickAcceptCookiesBtn();

            Assert.That(cookieForm.State.WaitForNotDisplayed(), Is.True, "Cookies form should be hidden");
        }
    }
}