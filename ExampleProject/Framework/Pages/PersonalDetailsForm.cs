using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class PersonalDetailsForm : Form
    {
        public PersonalDetailsForm()
            : base(By.ClassName("personal-details__form"), "Personal Details form")
        { }
    }
}