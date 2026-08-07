using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    public class WikipediaHomePage : Form
    {
        private  ITextBox searchTextbox => ElementFactory.GetTextBox(By.CssSelector("#search-input input#searchInput"), "Search");
        private IButton searchButton => ElementFactory.GetButton(By.XPath("//button[@class='pure-button pure-button-primary-progressive']"), "Search Button");

        public WikipediaHomePage()
            : base(By.Id("www-wikipedia-org"), "Wikipedia Home")
        { }

        public void SelectLanguage(string languageCode)
        {
            ElementFactory.GetComboBox(By.Id("searchLanguage"), "Language Dropdown", ElementState.ExistsInAnyState).SelectByValue(languageCode);
        }

        public void Search(string value)
        {
            searchTextbox.ClearAndType(value);
            searchButton.Click();
        }
    }
}
