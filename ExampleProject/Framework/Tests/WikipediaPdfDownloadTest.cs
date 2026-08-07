using Aquality.Selenium.Browsers;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class WikipediaPdfDownloadTest : BaseTest
    {
        private FileInfo? downloadedFile;

        [Test]
        public void VerifyPdfDownloadTest()
        {
            var mainPage = new WikipediaHomePage();

            Assert.That(mainPage.State.WaitForDisplayed(), Is.True, "Wikipedia main page is not displayed");

            mainPage.SelectLanguage("en");
            mainPage.Search("Albert Einstein");

            var albertEinsteinPage = new AlbertEinsteinPage();

            Assert.That(albertEinsteinPage.State.WaitForDisplayed(), Is.True);

            albertEinsteinPage.OpenDownloadPdfPage();

            var pdfPage = new PdfDownloadPage();

            string pdfName = pdfPage.GetPdfName();

            pdfPage.DownloadButton.State.WaitForDisplayed();
            pdfPage.DownloadButton.Click();

            string downloadFilePath = Path.Combine(AqualityServices.Browser.DownloadDirectory, pdfName);
            downloadedFile = new FileInfo(downloadFilePath);

            Assert.That(FileUtils.IsFileExists(downloadFilePath), Is.True);
        }

        [TearDown]
        public void DeleteFile()
        {
            if (downloadedFile != null)
            {
                FileUtils.DeleteFileIfExists(downloadedFile);
            }
        }
    }
}
