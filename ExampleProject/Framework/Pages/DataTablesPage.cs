using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Framework.Pages
{
    internal class DataTablesPage : Form
    {
        private const string Name = "Data Tables";
        private static readonly By due = By.XPath("//*[@id='table1']//td[4]");
        
        public DataTablesPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, Name)), Name)
        {
        }

        public List<string> GetFirstDueList()
        {
            //implement logic
            return new List<string>();
        }

        private IList<ILabel> GetFirstDueLblList()
        {
            return ElementFactory.FindElements<ILabel>(due, "due label");
        }
    }
}
