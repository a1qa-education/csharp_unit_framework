using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class MultipleWindowsPage : Form
    {
        private ILink clickHereLink => ElementFactory.GetLink(By.LinkText("Click Here"), "Click Here");

        public MultipleWindowsPage() : base(By.TagName("h3"), "Multiple Windows Page")
        {
        }

        public void ClickHere()
        {
            clickHereLink.Click();
        }
    }
}
