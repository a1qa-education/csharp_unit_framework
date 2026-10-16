using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class MainPage : Form
    {
        private ILabel timerLabel => ElementFactory.GetLabel(By.CssSelector("div.timer--white"), "Timer");

        private SignUpForm? signUpForm;
        private InterestsForm? interestsForm;
        private CookieForm? cookieForm;
        private TermsConditionsForm? termsConditionsForm;

        public MainPage()
            : base(By.CssSelector("div.timer--white"), "Main page")
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

        public CookieForm GetCookieForm()
        {
            return cookieForm ??= new CookieForm();
        }

        public TermsConditionsForm GetTermsConditionsForm()
        {
            return termsConditionsForm ??= new TermsConditionsForm();
        }
    }
}