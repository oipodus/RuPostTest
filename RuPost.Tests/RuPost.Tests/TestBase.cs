using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RuPost.Tests
{
    public class TestBase
    {
        protected readonly IWebDriver _webDriver = new ChromeDriver();

        protected void OpenPage(string pageUrl)
        {
            this._webDriver.Navigate().GoToUrl(pageUrl);
        }
    }
}
