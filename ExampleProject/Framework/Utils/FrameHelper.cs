using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using System;

namespace ExampleProject.Framework.Utils
{
    public static class FrameHelper
    {
        public static T SwitchToFrame<T>(By locator) where T : class, new()
        {
            var driver = AqualityServices.Browser.Driver;
            driver.SwitchTo().Frame(driver.FindElement(locator));

            try
            {
                return new T();
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot create page {typeof(T).Name}", e);
            }
        }

        public static void SwitchToDefaultContent()
        {
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();
        }

        public static void SwitchToParentFrame()
        {
            AqualityServices.Browser.Driver.SwitchTo().ParentFrame();
        }
    }
}
