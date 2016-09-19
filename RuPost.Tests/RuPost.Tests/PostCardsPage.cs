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
    public class PostCardsPage
    {
        private readonly By PriceSelector = By.CssSelector("span[data-reactid='.1.2.1.1.0.0.0.0']");

        private readonly By NotificationCheckboxSelector = By.CssSelector("label[data-reactid='.1.0.0.2.1:$deliveryNotification.0.2']");

        private readonly By RegisteredLetterCheckboxSelector = By.CssSelector("label[data-reactid='.1.0.0.2.1:$registered.0.2']");

        private readonly By OriginCityInputSelector = By.CssSelector("input[data-reactid='.1.0.0.0.1:0.3']");

        private readonly By DestinationCityInputSelector = By.CssSelector("input[data-reactid='.1.0.0.0.1:1.3']");

        private readonly By SuggestListSelector = By.ClassName("input__suggest-wrapper");

        private readonly IWebDriver _webDriver;

        public PostCardsPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        public string GetPrice()
        {
            return this._webDriver.FindElement(this.PriceSelector).Text;
        }

        public PostCardsPage InputDestinationCity(string destinationCity)
        {
            var input = this._webDriver.FindElement(this.DestinationCityInputSelector);

            // waiting for default value to be shown
            Thread.Sleep(500);

            input.Click();
            input.SendKeys(Keys.Control + "a");
            input.SendKeys(Keys.Delete);

            input.SendKeys(destinationCity);

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

        public PostCardsPage InputOriginCity(string originCity)
        {
            var input = this._webDriver.FindElement(this.OriginCityInputSelector);

            // waiting for default value to be shown
            Thread.Sleep(500);

            input.Click();
            input.SendKeys(Keys.Control + "a");
            input.SendKeys(Keys.Delete);

            input.SendKeys(originCity);

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

        public PostCardsPage NotificationCheck()
        {
            IWebElement checkbox =
                           _webDriver.FindElement(NotificationCheckboxSelector);

            // waiting for DOM to be rebuild
            Thread.Sleep(500);

            checkbox.Click();

            // waiting for DOM to be rebuild
            Thread.Sleep(500);

            return this;
        }

        public PostCardsPage RegisteredLetterCheck()
        {
            IWebElement checkbox =
                           _webDriver.FindElement(RegisteredLetterCheckboxSelector);

            // waiting for DOM to be rebuild
            Thread.Sleep(500);

            checkbox.Click();

            // waiting for DOM to be rebuild
            Thread.Sleep(500);

            return this;
        }

    }
}
