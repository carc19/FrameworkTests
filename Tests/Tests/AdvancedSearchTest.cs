using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models;
using Modèles.Models.Page;
using HP.LFT.SDK.Web;
using System.Text.RegularExpressions;

namespace Tests.Tests
{
    [TestFixture, Order(3)]
    public class AdvancedSearchTest : UnitTestClassBase
    {
        private const string MOT_TEST = "Test";
        private const string AUTHOR = "";
        private const string TITLE = "Harry Potter";

        AdvancedSearchPage asp = new AdvancedSearchPage();
        ProductPage pp = new ProductPage();
        Result result = new Result();

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
        public void AdvancedSearchLinkClick()
        {
            asp.AdvancedSearchLink.Click();
        }

        [Test, Order(2)]
        public void FillTitle()
        {
            asp.TitleEditField.SetValue(TITLE);
        }

        [Test, Order(3)]
        public void FillAuthor()
        {
            asp.AuthorEditField.SetValue(AUTHOR);
        }

        [Test, Order(4)]
        public void FillCollection()
        {
            //asp.CollectionEditField.SetValue(MOT_TEST);
        }

        [Test, Order(5)]
        public void FillSubject()
        {
            //asp.SubjectEditField.SetValue(MOT_TEST);
        }

        [Test, Order(6)]
        public void FillEditor()
        {
            //asp.EditorEditField.SetValue(MOT_TEST);
        }

        [Test, Order(7)]
        public void FillISBN()
        {
            //asp.ISBN_EAN13_EditField.SetValue(MOT_TEST);
        }

        [Test, Order(8)]
        public void FillRBCode()
        {
            //asp.RBCodeEditField.SetValue(MOT_TEST);
        }

        [Test, Order(9)]
        public void SelectDates()
        {
            //asp.SetDates((int)Shared.Months.JAN, 2016, (int)Shared.Months.DEC, 2019);
        }

        [Test, Order(10)]
        public void SelectCategories()
        {
            //asp.SelectCategory((int)Shared.Categories.Books);
        }

        [Test, Order(11)]
        public void CheckCoupsCoeur()
        {
            //asp.CoupsCoeurCheckBox.Set(true);
        }

        [Test, Order(12)]
        public void CheckEnglishOnly()
        {
            //asp.ExcludeEnglishCheckBox.Set(true);
        }

        [Test, Order(13)]
        public void SearchButtonClick()
        {
            asp.SearchButton.Click();
        }

        [Test, Order(14)]
        public void FirstResultClick()
        {
            result.FirstProductLink.Click();
        }

        [Test, Order(15)]
        public void CheckAuthorSearchResult()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(AUTHOR, pp.AuthorLink);

            if(!success)
                    Assert.Fail("The author specified in the search is not the same as the one for the selected product.");
        }

        [Test, Order(16)]
        public void CheckTitleSearchResult()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(TITLE, pp.Title);

            if (!success)
                Assert.Fail("The author specified in the search is not the same as the one for the selected product.");
        }

        [Test, Order(17)]
        public void CheckReleaseDate()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareReleaseDate((int)Shared.Months.JAN, 2019, (int)Shared.Months.APR, 2019, pp.ReleaseDate);

            if (!success)
                Assert.Fail("The release date from the search doesn't correspond with the start and end date.");
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
