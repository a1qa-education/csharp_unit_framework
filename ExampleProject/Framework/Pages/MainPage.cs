using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class MainPage : Form
    {
        private ILabel timerLabel => ElementFactory.GetLabel(By.CssSelector("div.timer--gray"), "Timer");

        private SignUpForm? signUpForm;
        private InterestsForm? interestsForm;
        private PersonalDetailsForm? personalDetailsForm;
        private HelpForm? helpForm;
        private CookieForm? cookieForm;

        public MainPage()
            : base(By.ClassName("bagaar-link__image"), "Main page")
        { }

        public string GetTimerValue()
        {
            return timerLabel.Text;
        }

        public SignUpForm GetSignUpForm()
        {
            return signUpForm ??= new SignUpForm();
        }

        public InterestsForm GetInterestsForm()
        {
            return interestsForm ??= new InterestsForm();
        }

        public PersonalDetailsForm GetPersonalDetailsForm()
        {
            return personalDetailsForm ??= new PersonalDetailsForm();
        }

        public HelpForm GetHelpForm()
        {
            return helpForm ??= new HelpForm();
        }

        public CookieForm GetCookieForm()
        {
            return cookieForm ??= new CookieForm();
        }
    }
}