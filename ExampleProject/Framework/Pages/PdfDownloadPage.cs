using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class PdfDownloadPage : Form
    {
        public IButton DownloadButton => ElementFactory.GetButton(By.XPath("//button[@tabindex='0']"), "Download Button");

        public PdfDownloadPage()
            : base(By.XPath("//h1[contains(.,'Download as PDF')]"), "PDF Download Page")
        { }

        public string GetPdfName()
        {
            return ElementFactory.GetLabel(By.XPath("//div[@class='mw-electronpdfservice-selection-label-desc']"), "PDF Name").Text;
        }
    }
}
