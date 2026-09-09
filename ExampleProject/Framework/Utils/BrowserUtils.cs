using Aquality.Selenium.Browsers;

namespace ExampleProject.Framework.Utils
{
    internal class BrowserUtils
    {
        public static void AcceptAlert()
        {
            AqualityServices.Browser.HandleAlert(AlertAction.Accept);
        }
    }
}
