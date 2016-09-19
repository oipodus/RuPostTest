using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RuPost.Tests
{
    public class OfficeSearchPage
    {
        private readonly By InputSelector = By.CssSelector("input[data-reactid='.1.0.0.0.0.3']");

        private readonly By SuggestListSelector = By.ClassName("input__suggest-wrapper");

        private readonly By ShortAddressSelector = By.ClassName("office-card__short-address");

        private readonly IWebDriver _webDriver;

        public OfficeSearchPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        public OfficeSearchPage InputCity(string city)
        {
            var input = this._webDriver.FindElement(this.InputSelector);

            // waiting for default value to be shown
            Thread.Sleep(500);

            input.Click();
            input.SendKeys(Keys.Control + "a");
            input.SendKeys(Keys.Delete);

            input.SendKeys(city);

            // waiting for suggest list
            IWebElement suggestList =
                _webDriver.FindElement(SuggestListSelector);

            // select the first suggested value
            Actions builder = new Actions(_webDriver);
            builder.SendKeys(Keys.Down);
            builder.SendKeys(Keys.Enter);
            builder.Perform();

            // waiting for DOM to be rebuild
            Thread.Sleep(500);

            return this;
        }

        public List<string> GetShortAddresses()
        {
            var foundShortAddresses = 
                this._webDriver.FindElements(this.ShortAddressSelector)
                .Select(t=>t.Text)
                .ToList();

            return foundShortAddresses;

        }
    }
}
