using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class AlbertEinsteinPage : Form
    {
        private IButton toolsButton => ElementFactory.GetButton(By.CssSelector("div[id='vector-page-tools-dropdown']"), "Tools");

        public AlbertEinsteinPage()
            : base(By.XPath("//h1[@id='firstHeading']/span//span[text()='Albert Einstein']"), "Albert Einstein Page")
        { }

        public void OpenDownloadPdfPage()
        {
            toolsButton.Click();
            ElementFactory.GetButton(By.Id("coll-download-as-rl"), "Download as PDF").Click();
        }
    }
}
