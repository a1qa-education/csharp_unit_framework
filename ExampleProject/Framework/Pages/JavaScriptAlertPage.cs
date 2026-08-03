using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class JavaScriptAlertPage : Form
    {
        private const string PageName = "JavaScript Alerts";
        private IButton clickForJSAlertBtn => ElementFactory.GetButton(By.XPath("//button[@onclick='jsAlert()']"), "Click for JS Alert btn");
        private ILabel successMessageLbl => ElementFactory.GetLabel(By.XPath("//*[text()='You successfully clicked an alert']"), "Success message text");
        public JavaScriptAlertPage() : base(By.XPath($"//h3[text()='{PageName}']"), PageName)
        {
        }

        public void ClickJSAlertBtn() => clickForJSAlertBtn.Click();

        public bool IsSuccessMessageDisplayed() => successMessageLbl.State.IsDisplayed;
    }
}