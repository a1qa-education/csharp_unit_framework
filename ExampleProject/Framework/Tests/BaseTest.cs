using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public abstract class BaseTest
    {
        protected Browser browser;
        protected static readonly JsonSettingsFile settings = new("config.json");

        [SetUp]
        public void SetUp()
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
        }

        [TearDown]
        public void TearDown()
        {
            browser.Quit();
        }
    }
}
