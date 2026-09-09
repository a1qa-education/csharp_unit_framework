using Aquality.Selenium.Forms;
using ExampleProject.Framework.Utils;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class NestedFramesPage : Form
    {
        private static readonly By TopFrame = By.Name("frame-top");

        public NestedFramesPage() : base(TopFrame, "Nested Frames")
        {
        }

        public string GetLeftFrameText()
        {
            string text = SwitchToTopFrame().SwitchToLeftFrame().GetText();
            FrameHelper.SwitchToDefaultContent();
            return text;
        }

        public string GetRightFrameText()
        {
            // todo: Implement the method
            return "";
        }

        private TopFrameForm SwitchToTopFrame()
        {
            return FrameHelper.SwitchToFrame<TopFrameForm>(TopFrame);
        }
    }
}
