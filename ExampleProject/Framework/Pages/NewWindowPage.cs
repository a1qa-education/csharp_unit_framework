using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class NewWindowPage : Form
    {
        // todo: Implement this class
        public NewWindowPage() : base(By.XPath("//h3[text()='New Window']"), "New Window")
        {
        }
    }
}
