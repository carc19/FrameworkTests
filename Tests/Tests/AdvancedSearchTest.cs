using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models;
using Modèles.Models.Page;
using HP.LFT.SDK.Web;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Tests.Tests
{
    [TestFixture, Order(3)]
    public class AdvancedSearchTest : UnitTestClassBase
    {
        private const string AUTHOR = "";
        private const string TITLE = "Back to the future";
        private const string EDITOR = "";
        private const string COLLECTION = "";
        private const string SUBJECT = "";
        private const string ISBN = "";
        private const string RBCODE = "";
        private const int START_MONTH = (int)Shared.Months.JAN;
        private const int START_YEAR = 2016;
        private const int END_MONTH = (int)Shared.Months.APR;
        private const int END_YEAR = 2019;

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
            SolutionBrowser._browser.Sync();
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
            asp.CollectionEditField.SetValue(COLLECTION);
        }

        [Test, Order(5)]
        public void FillSubject()
        {
            asp.SubjectEditField.SetValue(SUBJECT);
        }

        [Test, Order(6)]
        public void FillEditor()
        {
            asp.EditorEditField.SetValue(EDITOR);
        }

        [Test, Order(7)]
        public void FillISBN()
        {
            asp.ISBN_EAN13_EditField.SetValue(ISBN);
        }

        [Test, Order(8)]
        public void FillRBCode()
        {
            asp.RBCodeEditField.SetValue(RBCODE);
        }

        [Test, Order(9)]
        public void SelectDates()
        {
            asp.SetDates(START_MONTH, START_YEAR, END_MONTH, END_YEAR);
        }

        [Test, Order(10)]
        public void SelectCategories()
        {
            asp.SelectCategory((int)Shared.Categories.Books);
        }

        [Test, Order(11)]
        public void CheckCoupsCoeur()
        {
            asp.CoupsCoeurCheckBox.Set(true);
        }

        [Test, Order(12)]
        public void CheckEnglishOnly()
        {
            asp.ExcludeEnglishCheckBox.Set(true);
        }

        [Test, Order(13)]
        public void SearchButtonClick()
        {
            asp.SearchButton.Click();
        }

        [Test, Order(14)]
        public void FirstResultClick()
        {
            Reporter.StartReportingContext("Select first result");
            try
            {
                result.FirstProductClick();
                Image img = SolutionBrowser._browser.GetSnapshot();
                Reporter.ReportEvent("Select first product from search result.", "", HP.LFT.Report.Status.Passed, img);
            }
            catch (Exception ex)
            {
                Image img = SolutionBrowser._browser.GetSnapshot();
                Reporter.ReportEvent("Select first product from search result.", ex.Message, HP.LFT.Report.Status.Failed, img);
                Assert.Fail();
            }

            Reporter.EndReportingContext();
        }

        [Test, Order(15)]
        public void CheckAuthorSearchResult()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(AUTHOR, pp.AuthorLink);

            if (!success)
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
            success = CheckFunctions.CompareReleaseDate(START_MONTH, START_YEAR, END_MONTH, END_YEAR, pp.ReleaseDate);

            if (!success)
                Assert.Fail("The release date from the search doesn't correspond with the start and end date.");
        }

        [Test, Order(18)]
        public void CheckEditor()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(EDITOR, pp.Editor);

            if (!success)
                Assert.Fail("The editor from this product doesn't correspond to the one from the search.");
        }

        [Test, Order(19)]
        public void CheckCollection()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(COLLECTION, pp.Collection);

            if (!success)
                Assert.Fail("The collection from this product doesn't correspond to the one searched.");
        }

        [Test, Order(20)]
        public void CheckSubject()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(SUBJECT, pp.Subject);

            if (!success)
                Assert.Fail("This product's subject doesn't correspond to the one searched.");
        }

        [Test, Order(21)]
        public void CheckISBN()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(ISBN, pp.ISBN);

            if (!success)
                Assert.Fail("This product's ISBN doesn't correspond to the one searched.");
        }

        [Test, Order(22)]
        public void CheckRBCode()
        {
            SolutionBrowser._browser.Sync();

            bool success = true;
            success = CheckFunctions.CompareSearchResult(RBCODE, pp.RBCode);

            if (!success)
                Assert.Fail("This product's Renaud-Bray code doesn't correspond to the one searched.");
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
