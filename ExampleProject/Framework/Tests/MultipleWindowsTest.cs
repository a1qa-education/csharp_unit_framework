using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class MultipleWindowsTest : BaseTest
    {
        private MultipleWindowsPage multipleWindowsPage = new();

        [Test]
        public void MultipleWindowsTestSuccessful()
        {
            mainPage.ClickNavigationLink(MainPageNavigation.MultipleWindows);
            // todo: add test logic
        }
    }
}
