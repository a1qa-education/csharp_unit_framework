using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class WelcomePage : Form
    {
        private ILink clickHereToGoLinkElement => ElementFactory.GetLink(By.ClassName("start__link"), "Click HERE to Go");

        public WelcomePage()
            : base(By.ClassName("start__button"), "Welcome page")
        {
        }

        public void ClickHereToGoLink()
        {
            clickHereToGoLinkElement.Click();
        }
    }
}