using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class CookiesPolicyTests : BaseTest
    {
        [Test]
        public void DismissCookiesBanner()
        {
            var mainPage = new MainPage();
            var cookieForm = mainPage.GetCookieForm();

            Assert.That(cookieForm.State.WaitForDisplayed(), Is.True, "Cookies form should be displayed");

            mainPage.GetSignUpForm().OpenTermsConditions();

            Assert.That(mainPage.GetTermsConditionsForm().State.WaitForDisplayed(), Is.True, "Terms and Conditions form should be displayed");

            // Cookies banner is covered by the Terms and Conditions overlay: provokes ElementClickInterceptedException
            cookieForm.ClickAcceptCookiesBtn();

            Assert.That(cookieForm.State.WaitForNotDisplayed(), Is.True, "Cookies form should be hidden");
        }
    }
}