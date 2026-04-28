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
            mainPage.ClickNavigationLink("JavaScript Alerts");
            jsAlertPage.ClickJSAlertBtn();
            BrowserUtils.AcceptAlert();
            Assert.IsTrue(jsAlertPage.IsSuccessMessageDisplayed(), "Success message is not displayed");
        }
    }
}
