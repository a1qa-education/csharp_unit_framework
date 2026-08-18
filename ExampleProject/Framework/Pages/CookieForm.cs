using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class CookieForm : Form
    {
        private IButton acceptCookiesBtn => ElementFactory.GetButton(By.XPath("//div[@class='cookies']//button[contains(text(),'Yes')]"), "Accept Cookies");

        public CookieForm()
            : base(By.ClassName("cookies"), "Cookie form")
        { }

        public void ClickAcceptCookiesBtn()
        {
            acceptCookiesBtn.ClickAndWait();
        }
    }
}
