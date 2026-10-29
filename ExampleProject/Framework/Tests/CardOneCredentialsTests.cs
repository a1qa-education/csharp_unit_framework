using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Models;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class CardOneCredentialsTests : BaseTest
    {
        private const string FirstCardPageIndicatorText = "1 / 4";
        private const string SecondCardPageIndicatorText = "2 / 4";

        private readonly SignUpForm signUpForm = new MainPage().GetSignUpForm();
        private readonly InterestsForm interestsForm = new MainPage().GetInterestsForm();
        private readonly EmailData emailTestData = TestDataReader.GetEmailData();

        [Test]
        public void CheckPasswordPolicyCompliance()
        {
            Domains domain = Enum.Parse<Domains>(emailTestData.EmailExtension, ignoreCase: true);

            AssertCardOneIsOpened();
            FillCredentials(domain, emailTestData.FirstPassword);
            signUpForm.ClickNextBtn();

            Assert.That(interestsForm.State.WaitForDisplayed(), Is.True, "Interests card should be displayed");
            Assert.That(interestsForm.GetPageIndicatorText(), Is.EqualTo(SecondCardPageIndicatorText), "Page Indicator should be the same as expected");
        }

        [Test]
        public void CheckEmailDomainExtensions()
        {
            IList<Domains> emailExtensions = Enum.GetValues<Domains>();

            AssertCardOneIsOpened();
            foreach (Domains emailExtension in emailExtensions)
            {
                FillCredentials(emailExtension, emailTestData.SecondPassword);
                signUpForm.ClickNextBtn();
                Assert.That(interestsForm.State.WaitForDisplayed(), Is.True, "Interests card should be displayed");
                Assert.That(interestsForm.GetPageIndicatorText(), Is.EqualTo(SecondCardPageIndicatorText), "Page Indicator should be the same as expected");
                browser.Refresh();
            }
        }

        private void AssertCardOneIsOpened()
        {
            Assert.That(signUpForm.State.WaitForDisplayed(), Is.True, "Sign Up card should be displayed");
            Assert.That(signUpForm.GetPageIndicatorText(), Is.EqualTo(FirstCardPageIndicatorText), "Page Indicator should be the same as expected");
        }

        private void FillCredentials(Domains domain, string password)
        {
            signUpForm.TypePassword(password);
            signUpForm.TypeEmail(emailTestData.EmailName);
            signUpForm.TypeDomain(emailTestData.EmailDomain);
            signUpForm.SelectDomain(domain);
            signUpForm.AcceptTermsConditions();
        }
    }
}