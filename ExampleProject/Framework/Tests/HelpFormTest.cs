using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class HelpFormTest : BaseTest
    {
        [Test]
        public void CheckHelpFormCanBeCollapsed()
        {
            var welcomePage = new WelcomePage();

            welcomePage.ClickHereToGoLink();

            var helpForm = new MainPage().GetHelpForm();

            Assert.That(helpForm.State.WaitForDisplayed(), Is.True, "Help form should be displayed");

            helpForm.ClickSendToBottomBtn();

            Assert.That(helpForm.State.WaitForNotDisplayed(), Is.True, "Help form should be hidden");
        }
    }
}