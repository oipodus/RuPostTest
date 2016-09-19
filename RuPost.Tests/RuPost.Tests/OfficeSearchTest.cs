using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuPost.Tests
{
    class OfficeSearchTest : TestBase
    {
        private readonly string _pageUrl = "https://www.pochta.ru/offices";
        private string _city;

        public OfficeSearchPage OfficeSearchPage { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this._webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [SetUp]
        public void Initialize()
        {
            this.OfficeSearchPage = new Tests.OfficeSearchPage(this._webDriver);

            this.OpenPage(this._pageUrl);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            this._webDriver.Close();
        }

        #region Tests

        [Test]
        public void TestOfficeSearch()
        {
            // Arrange:
            this._city = "Москва";

            // Act:

            var actual = this.Act();

            // Assert:

            Asserts(actual);
        }

        #endregion

        #region Act

        public List<string> Act()
        {
            var page = this.OfficeSearchPage
                .InputCity(this._city);

            return page.GetShortAddresses();

        }

#endregion

        #region Asserts

        private void Asserts(List<string> actual)
        {
            foreach(var address in actual)
            {
                Assert.IsTrue(address.Contains(this._city));
            }
        }

        #endregion

    }
}
