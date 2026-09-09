using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class SecureAreaPage : Form
    {
        private const string PageName = "Secure Area Page";
        private ILabel successMessageLbl => ElementFactory.GetLabel(By.Id("flash"), "Success message text");
        private IButton logoutBtn => ElementFactory.GetButton(By.XPath("//a[@href='/logout']"), "Logout button");

        public SecureAreaPage() : base(By.XPath("//h2[contains(.,'Secure Area')]"), PageName)
        {
        }

        public string GetSuccessMessageText()
        {
            return successMessageLbl.Text;
        }

        public void ClickLogout()
        {
            logoutBtn.Click();
        }
    }
}
