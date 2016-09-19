using NUnit.Framework;
using System;


namespace RuPost.Tests
{
    [TestFixture]
    public class PriceTest : TestBase
    {
        private readonly string _pageUrl = "https://www.pochta.ru/postcards";

        PostCardsPage PostCardsPage;
        private string _originCity;
        private string _destinationCity;
        private bool _registered;
        private bool _withNotification;
        private string _expected;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this._webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [SetUp]
        public void Initialize()
        {
            this.PostCardsPage = new Tests.PostCardsPage(this._webDriver);

            this.OpenPage(this._pageUrl);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            this._webDriver.Close();
        }

        #region Tests

        [Test]
        public void PostCardPrice_when_internal_registered_with_notification_()
        {
            // Arrange:

            this._originCity = "Москва";
            this._destinationCity = "Санкт-Петербург";
            this._registered = true;
            this._withNotification = true;

            this._expected = "47,00 руб.";

            // Act: 

            var actual = Act();

            // Asseret:

            Asserts(actual);
        }

        [Test]
        public void PostCardPrice_when_internal_registered_without_notification_()
        {
            // Arrange:

            this._originCity = "Москва";
            this._destinationCity = "Санкт-Петербург";
            this._registered = true;
            this._withNotification = false;

            this._expected = "29,00 руб.";

            // Act: 

            var actual = Act();

            // Asseret:

            Asserts(actual);
        }

        [Test]
        public void PostCardPrice_when_internal_not_registered_without_notification_()
        {
            // Arrange:

            this._originCity = "Москва";
            this._destinationCity = "Санкт-Петербург";
            this._registered = false;
            this._withNotification = false;

            this._expected = "14,00 руб.";

            // Act: 

            var actual = Act();

            // Asseret:

            Asserts(actual);
        }

        [Test]
        public void PostCardPrice_when_international__registered_with_notification_()
        {
            // Arrange:

            this._originCity = "Москва";
            this._destinationCity = "Амстердам";
            this._registered = true;
            this._withNotification = true;

            this._expected = "176,50 руб.";

            // Act: 

            var actual = Act();

            // Asseret:

            Asserts(actual);
        }

        [Test]
        public void PostCardPrice_when_international__registered_without_notification_()
        {
            // Arrange:

            this._originCity = "Москва";
            this._destinationCity = "Амстердам";
            this._registered = true;
            this._withNotification = false;

            this._expected = "121,00 руб.";

            // Act: 

            var actual = Act();

            // Asseret:

            Asserts(actual);
        }

        [Test]
        public void PostCardPrice_when_international_not_registered_without_notification_()
        {
            // Arrange:

            this._originCity = "Москва";
            this._destinationCity = "Амстердам";
            this._registered = false;
            this._withNotification = false;

            this._expected = "31,00 руб.";

            // Act: 

            var actual = Act();

            // Asseret:

            Asserts(actual);
        }



        #endregion

        #region Act

        public string Act()
        {
            var page = this.PostCardsPage
                .InputOriginCity(this._originCity)
                .InputDestinationCity(this._destinationCity);

            if (this._registered)
            {
                page = page.RegisteredLetterCheck();
            }

            if (this._withNotification)
            {
                page = page.NotificationCheck();
            }

            return page.GetPrice();

        }

        #endregion

        #region Asserts

        private void Asserts(string actual)
        {
            Assert.AreEqual(this._expected, actual);
        }

        #endregion

    }
}
