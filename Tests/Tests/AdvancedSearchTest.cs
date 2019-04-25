using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models;
using Modèles.Models.Page;

namespace Tests.Tests
{
    [TestFixture, Order(3)]
    public class AdvancedSearchTest : UnitTestClassBase
    {
        private const string MOT_TEST = "Test";
        AdvancedSearchPage asp = new AdvancedSearchPage();

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
        public void FillEditFields()
        {
            //asp.TitleEditField.SetValue(MOT_TEST);
            //asp.AuthorEditField.SetValue(MOT_TEST);
            //asp.CollectionEditField.SetValue(MOT_TEST);
            //asp.SubjectEditField.SetValue(MOT_TEST);
            //asp.EditorEditField.SetValue(MOT_TEST);
            //asp.ISBN_EAN13_EditField.SetValue(MOT_TEST);
            //asp.RBCodeEditField.SetValue(MOT_TEST);
            //asp.SetDates((int)Shared.Months.JAN, 2016, (int)Shared.Months.DEC, 2019);
            //asp.SelectCategory((int)Shared.Categories.Books);
            //asp.CoupsCoeurCheckBox.Set(true);
            //asp.ExcludeEnglishCheckBox.Set(true);
            //asp.SearchButton.Click();
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
