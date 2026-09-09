using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Utils;
using OpenQA.Selenium;
namespace ExampleProject.Framework.Pages
{
    internal class MainPage : Form
    {
        private ILink navigationLink(MainPageNavigation navigation) => ElementFactory.GetLink(
            By.LinkText(navigation.GetDescription()), "Navigation link");
        public MainPage() : base(By.XPath("//h1[text()='Welcome to the-internet']"), "Main page")
        {
        }

        public void ClickNavigationLink(MainPageNavigation navigation)
        {
            navigationLink(navigation).Click();
        }
    }
}
