using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class BasicAuthPage : Form
    {
        private const string PageName = "Basic Auth";
        public BasicAuthPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }
        
        public bool IsSuccessMessageDisplayed()
        {
            //implement logic here
            return false;
        }
    }
}
