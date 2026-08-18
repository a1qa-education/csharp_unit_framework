using ExampleProject.Framework.Constants;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    public class CardsTest : BaseTest
    {
        private const int MinPasswordLength = 10;
        private const int NumberOfInterestsToSelect = 3;
        private const string FileToUploadName = "avatar.png";

        [Test]
        public void CheckCards()
        {
            var welcomePage = new WelcomePage();

            Assert.That(welcomePage.State.WaitForDisplayed(), Is.True, "Welcome page should be displayed");

            welcomePage.ClickHereToGoLink();

            var signUpForm = new MainPage().GetSignUpForm();

            Assert.That(signUpForm.State.WaitForDisplayed(), Is.True, "Sign Up card should be displayed");

            string email = RandomUtils.GetRandomAlphabeticString();
            string password = RandomUtils.GeneratePassword(MinPasswordLength);
            string domain = RandomUtils.GetRandomAlphabeticString();
            Domains domainPostfix = RandomUtils.GetRandomDomain();

            signUpForm.TypePassword(password);
            signUpForm.TypeEmail(email);
            signUpForm.TypeDomain(domain);
            signUpForm.SelectDomain(domainPostfix);
            signUpForm.ClickNextBtn();

            var interestsForm = new MainPage().GetInterestsForm();

            Assert.That(interestsForm.State.WaitForDisplayed(), Is.True, "Interests card should be displayed");

            interestsForm.ClickRandomInterests(NumberOfInterestsToSelect);
            interestsForm.UploadAvatar(FileToUploadName);
            interestsForm.ClickNextBtn();

            var personalDetailsForm = new MainPage().GetPersonalDetailsForm();

            Assert.That(personalDetailsForm.State.WaitForDisplayed(), Is.True, "Personal Details card should be displayed");
        }
    }
}