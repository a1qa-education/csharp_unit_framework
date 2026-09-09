using Aquality.Selenium.Forms;
using ExampleProject.Framework.Utils;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class TopFrameForm : Form
    {
        private static readonly By LeftFrame = By.Name("frame-left");
        private static readonly By RightFrame = By.Name("frame-right");

        public TopFrameForm() : base(By.TagName("frameset"), "Top Frame") // Java has body here, but frameset is safer
        {
        }

        public LeftFrameForm SwitchToLeftFrame()
        {
            return FrameHelper.SwitchToFrame<LeftFrameForm>(LeftFrame);
        }

        public RightFrameForm SwitchToRightFrame()
        {
            return FrameHelper.SwitchToFrame<RightFrameForm>(RightFrame);
        }
    }
}
