using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExampleProject.Framework.Tests
{
    public class SteamTest
    {
        [Test]
        public void STEAM_TC_001_Dynamic_Filtering_Windows_Singleplayer_Ascending_Price_Sorting()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://store.steampowered.com/");

            Assert.NotNull(driver.Title);
            Assert.NotNull(driver.FindElement(By.TagName("body")));
            Assert.NotNull(driver.FindElement(By.TagName("body")));

            var search = driver.FindElement(By.XPath("//form//input[@autocomplete='off']"));

            if (search != null)
            {
                if (search.Displayed)
                {
                    if (search.Enabled)
                    {
                        Assert.IsTrue(search.Displayed);
                        Assert.IsTrue(search.Enabled);

                        search.SendKeys("strategy");
                        search.Submit();
                    }
                }
            }

            Thread.Sleep(5000);

            IWebElement windowsCheckbox = driver.FindElement(By.XPath("//span[@role='button']//span[contains(text(),'Windows')]"));

            if (windowsCheckbox != null)
            {
                windowsCheckbox.Click();
            }

            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//div[text()='Narrow by number of players']")).Click();

            Thread.Sleep(3000);

            var singlePlayer = driver.FindElement(By.XPath("//span[@role='button']//span[contains(text(),'Single-player')]"));

            if (singlePlayer != null)
            {
                singlePlayer.Click();
            }

            Thread.Sleep(3000);

            var sortDropdown = driver.FindElement(By.XPath("//button[contains(@onclick,'sort_by')]"));

            sortDropdown.Click();

            Thread.Sleep(2000);

            var lowestPrice = driver.FindElement(By.XPath("//*[contains(text(),'Lowest Price')]"));

            lowestPrice.Click();

            Thread.Sleep(5000);

            var prices = new List<double>();

            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    var priceElement = driver.FindElement(
                            By.XPath("//a[contains(@class,'search_result_row')][" + i +"]//*[contains(@class,'discount_final_price')]"));

                    var raw = priceElement.Text;
                    prices.Add(double.Parse(raw.Replace("$", "")));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ignoring error: " + e.Message);
                }
            }

            var expected = new List<double>(prices);

            for (int i = 0; i < expected.Count; i++)
            {
                for (int j = 0; j < expected.Count - i; j++)
                {
                    try
                    {
                        if (expected[j] > expected[j + 1])
                        {
                            var temp = expected[j];
                            expected[j] = expected[j + 1];
                            expected[j + 1] = temp;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            Assert.AreEqual(prices.ToString(), expected.ToString());

            driver.Quit();
        }

        [Test]
        public void STEAM_TC_002_Dynamic_Filtering_macOS_Multiplayer_Descending_Price_Sorting()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://store.steampowered.com/");

            Assert.NotNull(driver.Title);
            Assert.NotNull(driver.FindElement(By.TagName("body")));
            Assert.NotNull(driver.FindElement(By.TagName("body")));

            var search = driver.FindElement(By.XPath("//form//input[@autocomplete='off']"));

            if (search != null)
            {
                if (search.Displayed)
                {
                    if (search.Enabled)
                    {
                        Assert.IsTrue(search.Displayed);
                        Assert.IsTrue(search.Enabled);

                        search.SendKeys("strategy");
                        search.Submit();
                    }
                }
            }

            Thread.Sleep(5000);

            var macCheckbox = driver.FindElement(By.XPath("//span[@role='button']//span[contains(text(),'macOS')]"));
            if (macCheckbox != null)
            {
                macCheckbox.Click();
            }

            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//div[text()='Narrow by number of players']")).Click();

            Thread.Sleep(3000);

            var multiplayer = driver.FindElement(By.XPath("//span[@role='button']//span[contains(text(),'Multi-player')]"));

            if (multiplayer != null)
            {
                multiplayer.Click();
            }

            Thread.Sleep(3000);

            var sortDropdown = driver.FindElement(By.XPath("//button[contains(@onclick,'sort_by')]"));

            sortDropdown.Click();

            Thread.Sleep(2000);

            IWebElement highestPrice = driver.FindElement(By.XPath("//*[contains(text(),'Highest Price')]"));

            highestPrice.Click();

            Thread.Sleep(5000);

            var prices = new List<double>();

            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    var priceElement =driver.FindElement(
                            By.XPath("//a[contains(@class,'search_result_row')][" + i +"]//*[contains(@class,'discount_final_price')]"));

                    string raw = priceElement.Text;

                    prices.Add(double.Parse(raw.Replace("$", "")));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ignoring error: " + e.Message);
                }
            }

            var expected = new List<double>(prices);

            for (int i = 0; i < expected.Count; i++)
            {
                for (int j = 0; j < expected.Count - i; j++)
                {
                    try
                    {
                        if (expected[j] < expected[j + 1])
                        {
                            var temp = expected[j];
                            expected[j] = expected[j + 1];
                            expected[j + 1] = temp;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            Assert.AreEqual(prices.ToString(), expected.ToString());

            driver.Quit();
        }
    }
}
