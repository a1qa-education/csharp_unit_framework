using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class SessionTimerTests : BaseTest
    {
        private const string ExpectedTimerValue = "00:00:00";
        private const int TimerInterval = 3;

        [Test]
        public void CheckTimerInitialValue()
        {
            var mainPage = new MainPage();

            Assert.That(
                mainPage.State.WaitForDisplayed(),
                Is.True,
                "Main page should be displayed");

            Assert.That(
                mainPage.GetTimerValue(),
                Is.EqualTo(ExpectedTimerValue),
                "Timer should have initial value right after the main page is opened");

            int initialValue = ConvertToSeconds(mainPage.GetTimerValue());
            WaitUtils.Sleep(TimerInterval);
            int actualValue = ConvertToSeconds(mainPage.GetTimerValue());

            Assert.That(
                actualValue,
                Is.EqualTo(initialValue + TimerInterval),
                "Timer should increase by 1 second every second");
        }

        private static int ConvertToSeconds(string timer)
        {
            string[] parts = timer.Split(':');

            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);
            int seconds = int.Parse(parts[2]);

            return hours * 3600 + minutes * 60 + seconds;
        }
    }
}