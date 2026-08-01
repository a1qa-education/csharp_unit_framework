using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class LoginPage : Form
    {
        private const string PageName = "Login Page";
        private ITextBox usernameTxt => ElementFactory.GetTextBox(By.Id("username"), "Username text box");
        private ITextBox passwordTxt => ElementFactory.GetTextBox(By.Id("password"), "Password text box");
        private IButton loginBtn => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Login button");

        public LoginPage() : base(By.XPath("//h2[text()='Login']"), PageName)
        {
        }

        public void Login(string username, string password)
        {
            usernameTxt.ClearAndType(username);
            passwordTxt.ClearAndType(password);
            loginBtn.Click();
        }
    }
}
