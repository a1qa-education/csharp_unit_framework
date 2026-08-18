using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Globalization;

namespace ExampleProject.Framework.Pages
{
    public class HelpForm : Form
    {
        private IButton sendToBottomBtn => ElementFactory.GetButton(By.XPath("//button[contains(@class,'send-to-bottom')]"), "Send to bottom");

        public HelpForm()
            : base(By.ClassName("help-form"), "Help form")
        { }

        public void ClickSendToBottomBtn()
        {
            sendToBottomBtn.ClickAndWait();
        }
    }
}