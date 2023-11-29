using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class BasicAuthPage : Form
    {
        private const string Name = "Basic Auth";
        public BasicAuthPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, Name)), Name)
        {
        }
        
        public bool IsSuccessMessageDisplayed()
        {
            //implement logic here
            return true;
        }
    }
}
