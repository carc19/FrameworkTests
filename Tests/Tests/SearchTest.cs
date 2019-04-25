using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models.Page;
using Modèles.Models;

namespace Tests.Tests
{
    [TestFixture, Order(2)]
    public class SearchTest : UnitTestClassBase
    {
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
            sp.SearchEditField.SetValue("Space");
        }

        [Test, Order(2)]
        public void SearchButtonClick()
        {
            SolutionBrowser._browser.Sync();
            sp.SearchButton.Click();
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
