using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class LeftFrameForm : Form
    {
        private ILabel textLabel => ElementFactory.GetLabel(By.TagName("body"), "Left text");

        public LeftFrameForm() : base(By.TagName("body"), "Left Frame")
        {
        }

        public string GetText()
        {
            return textLabel.GetText();
        }
    }
}
