using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class FramesPage : Form
    {
        private const string PageName = "Frames";
        private ILink nestedFramesLink => ElementFactory.GetLink(By.LinkText("Nested Frames"), "Nested Frames");

        public FramesPage() : base(By.XPath("//*[contains(text(),'Frames')]"), PageName)
        {
        }

        public void ClickNestedFramesLink()
        {
            nestedFramesLink.Click();
        }
    }
}
