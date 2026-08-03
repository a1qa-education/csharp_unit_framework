using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class AlertTest : BaseTest
    {
        private JavaScriptAlertPage jsAlertPage = new();

        [Test]
        public void AlertsTest()
        {
            mainPage.ClickNavigationLink(MainPageNavigation.JavaScriptAlert);
            jsAlertPage.ClickJSAlertBtn();
            BrowserUtils.AcceptAlert();
            Assert.That(jsAlertPage.IsSuccessMessageDisplayed(), Is.True, "Success message is not displayed");
        }
    }
}
