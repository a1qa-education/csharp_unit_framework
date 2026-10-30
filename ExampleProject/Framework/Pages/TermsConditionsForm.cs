using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class TermsConditionsForm : Form
    {
        public TermsConditionsForm()
            : base(By.ClassName("terms-and-conditions"), "Terms and Conditions form")
        { }
    }
}