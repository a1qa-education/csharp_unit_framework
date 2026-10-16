using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class InterestsForm : Form
    {
        private ILabel pageIndicatorLabel => ElementFactory.GetLabel(By.CssSelector("div.page-indicator"), "Page Indicator");

        public InterestsForm()
            : base(By.XPath("//a[contains(@class,'avatar-and-interests')]"), "Interests form")
        { }

        public string GetPageIndicatorText()
        {
            return pageIndicatorLabel.Text;
        }
    }
}