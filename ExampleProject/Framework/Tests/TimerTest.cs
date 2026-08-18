using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class TimerTest : BaseTest
    {
        private const string ExpectedTimerValue = "00:00:00";

        [Test]
        public void CheckTimerInitialValue()
        {
            var welcomePage = new WelcomePage();

            Assert.That(
                welcomePage.State.WaitForDisplayed(),
                Is.True,
                "Welcome page should be displayed");

            welcomePage.ClickHereToGoLink();

            var mainPage = new MainPage();

            Assert.That(
                mainPage.State.WaitForDisplayed(),
                Is.True,
                "Main page should be displayed");

            Assert.That(
                mainPage.GetTimerValue(),
                Is.EqualTo(ExpectedTimerValue),
                "Timer should have initial value right after the main page is opened");
        }
    }
}