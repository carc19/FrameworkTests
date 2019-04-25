using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models.Page;
using Modèles.Models;
using HP.LFT.SDK.Web;
using System.Text.RegularExpressions;

namespace Tests.Tests
{
    [TestFixture, Order(2)]
    public class SearchTest : UnitTestClassBase
    {
        private const string SEARCH_WORD = "Nasa";

        private SearchPage sp = new SearchPage();

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
            if (SolutionBrowser._browser == null)
                SolutionBrowser.LaunchBrowser();
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [Test, Order(1)]
        public void SearchSet()
        {
            SolutionBrowser._browser.Sync();
            sp.SearchEditField.SetValue(SEARCH_WORD);
        }

        [Test, Order(2)]
        public void SearchButtonClick()
        {
            SolutionBrowser._browser.Sync();
            sp.SearchButton.Click();
        }

        [Test, Order(3)]
        public void CheckSearchResult()
        {
            bool successTitle = true;
            bool successAuthor = true;

            ILink firstProductTitle = null;
            IWebElement firstProductAuthor = null;

            SolutionBrowser._browser.Sync();
            firstProductTitle = sp.FirstProductLink;
            firstProductAuthor = sp.CheckSearchResultAuthor();

            successTitle = CheckFunctions.CompareSearchResult(SEARCH_WORD, firstProductTitle);
            successAuthor = CheckFunctions.CompareSearchResult(SEARCH_WORD, firstProductAuthor);

            if (!successAuthor && !successTitle)
                Assert.Fail("The first product was unrelated to the search.");
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
