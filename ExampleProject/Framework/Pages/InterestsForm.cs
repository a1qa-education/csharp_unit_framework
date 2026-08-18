using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework.Utils;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class InterestsForm : Form
    {
        private IButton uploadBtn => ElementFactory.GetButton(By.XPath("//a[contains(@class,'upload-button')]"), "Upload");
        private IButton nextBtn => ElementFactory.GetButton(By.XPath("//button[@name='button' and text()='Next']"), "Next");

        private readonly By interestsCheckboxesLoc = By.XPath("//label[contains(@for,'interest')]");

        public InterestsForm()
            : base(By.XPath("//a[contains(@class,'avatar-and-interests')]"), "Interests form")
        { }

        public void ClickRandomInterests(int number)
        {
            IList<ICheckBox> allInterests = GetAllInterests();

            int counter = 0;
            while (counter < number)
            {
                int randomIndex = RandomUtils.GetRandomInt(allInterests.Count);
                allInterests[randomIndex].Click();
                counter++;
            }
        }

        public void ClickNextBtn()
        {
            nextBtn.Click();
        }

        public void UploadAvatar(string fileName)
        {
            uploadBtn.Click();
            UploadUtils.UploadFileFromResources(fileName);
        }

        private IList<ICheckBox> GetAllInterests()
        {
            AqualityServices.ConditionalWait.WaitFor(() => ElementFactory.FindElements<ICheckBox>(interestsCheckboxesLoc).Count > 0);

            return ElementFactory.FindElements<ICheckBox>(interestsCheckboxesLoc);
        }
    }
}