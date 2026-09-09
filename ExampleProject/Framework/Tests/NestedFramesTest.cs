using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class NestedFramesTest : BaseTest
    {
        private FramesPage framesPage = new();
        private NestedFramesPage nestedFramesPage = new();

        [Test]
        public void NestedFramesTestSuccessful()
        {
            mainPage.ClickNavigationLink(MainPageNavigation.Frames);
            framesPage.ClickNestedFramesLink();
            // todo: implement the rest of the test
        }
    }
}
