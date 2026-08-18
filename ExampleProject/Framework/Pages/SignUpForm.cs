using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Utils;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class SignUpForm : Form
    {
        private static readonly By PasswordFieldLoc = By.XPath("//div[contains(@class,'login-form')]/input");

        private const string DomainItemLocTemplate = "//div[contains(@class,'dropdown__list-item') and normalize-space(text())='{0}']";

        private ITextBox passwordField => ElementFactory.GetTextBox(PasswordFieldLoc, "Password field");
        private ITextBox emailField => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'email')]"), "Email field");
        private ITextBox domainField => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'Domain')]"), "Domain field");
        private IButton domainDropdown => ElementFactory.GetButton(By.XPath("//div[contains(@class,'login-form')]//div[contains(@class,'opener')]"), "Domain dropdown");
        private IButton nextBtn => ElementFactory.GetButton(By.XPath("//div[contains(@class,'login-form')]//a[text()='Next']"), "Next");

        public SignUpForm()
            : base(PasswordFieldLoc, "Sign Up form")
        { }

        public void TypePassword(string password)
        {
            passwordField.ClearAndType(password);
        }

        public void TypeEmail(string email)
        {
            emailField.ClearAndType(email);
        }

        public void TypeDomain(string domain)
        {
            domainField.ClearAndType(domain);
        }

        public void SelectDomain(Domains domain)
        {
            domainDropdown.Click();
            GetDomainDropdownItem(domain).Click();
        }

        public void ClickNextBtn()
        {
            nextBtn.Click();
        }

        private IButton GetDomainDropdownItem(Domains domain)
        {
            return ElementFactory.GetButton(By.XPath(string.Format(DomainItemLocTemplate, domain.GetDescription())), $"{domain.GetDescription()} domain dropdown item");
        }
    }
}