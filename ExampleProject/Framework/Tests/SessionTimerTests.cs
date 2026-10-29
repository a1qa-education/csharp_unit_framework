using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class SessionTimerTests : BaseTest
    {
        private const string ExpectedTimerValue = "00:00:00";
        private const int TimerDisplayTimeoutMs = 700;

        [Test]
        public void CheckTimerInitialValue()
        {
            var mainPage = new MainPage();

            Assert.That(mainPage.State.WaitForDisplayed(), Is.True, "Main page should be displayed");

            WaitUtils.Sleep(TimerDisplayTimeoutMs);

            Assert.That(
                mainPage.GetTimerValue(),
                Is.EqualTo(ExpectedTimerValue),
                "Timer should have initial value right after the main page is opened");
        }
    }
}
