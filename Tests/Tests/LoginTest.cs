using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models;
using Modèles.Models.Page;
using HP.LFT.SDK.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using Tests.Extensions;

namespace Tests.Tests
{
    [TestFixture, Order(1)]
    public class LoginTest : UnitTestClassBase
    {
        private const string FILE_PATH = @"C:\Users\carel\Desktop\Stage\InfoAccounts.xlsx";
        private const string SITE = "Renaud-Bray";
        private const string FIRSTNAME = "Test";
        private const string LASTNAME = "Stage";

        LoginPage lp = new LoginPage();
        Excel excel = new Excel();
        User user = new User();

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            ReporterWrapper.ReporterContext("Launch browser", () =>
            {
                if (SolutionBrowser._browser == null)
                    SolutionBrowser.LaunchBrowser();

                VerifyWrapper.IsNotNull(SolutionBrowser._browser, "Check Browser", "Open and launch browser if it hasn't been already done.");
            });
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [Test, Order(1)]
        public void LoginLinkClick()
        {
            SolutionBrowser._browser.Sync();

            ReporterWrapper.ReporterContext("Click on login link", () =>
            {
                lp.LoginLink.Click();
                SolutionBrowser._browser.Sync();

                VerifyWrapper.IsMatch(SolutionBrowser._browser.URL, "login", "Navigate to login page", "Click on link to navigate to the login page", SolutionBrowser.GetSnapshot());
            });
        }

        [Test, Order(2)]
        public void GetUserInfos()
        {
            user = excel.GetUserFromName(FILE_PATH, SITE, FIRSTNAME, LASTNAME);

            ReporterWrapper.ReporterContext("Get user information", () =>
            {
                // When the Password verification fails, the Email verification also fails, even though it's not empty.
                VerifyWrapper.IsNotNullOrEmpty(user.Email, "Check if user contains email address", "Check if an email address was found in the excel file", null);
                VerifyWrapper.IsNotNullOrEmpty(user.Pwd, "Check if user contains password", "Check if a password was found in the excel file", null);
            });
        }

        [Test, Order(3)]
        public void UsernameSet()
        {
            SolutionBrowser._browser.Sync();

            ReporterWrapper.ReporterContext("Set Username credentials", () =>
            {
                lp.UsernameEditField.SetValue(user.Email);
                SolutionBrowser._browser.Sync();
                VerifyWrapper.IsMatch(lp.UsernameEditField.Value, user.Email, "Set Username", "Check the UsernameEditField to make sure its value is the username extracted from the Excel file", SolutionBrowser.GetSnapshot());
            });
        }

        [Test, Order(4)]
        public void PasswordSet()
        {
            SolutionBrowser._browser.Sync();

            ReporterWrapper.ReporterContext("Set Password credentials", () =>
            {
                lp.PasswordEditField.SetValue(user.Pwd);
                SolutionBrowser._browser.Sync();
                VerifyWrapper.IsMatch(lp.PasswordEditField.Value, user.Pwd, "Set Password", "Check the PasswordEditField to make its value matches the one extracted from the Excel File.", SolutionBrowser.GetSnapshot());
            });
        }

        [Test, Order(5)]
        public void LoginButtonClick()
        {
            SolutionBrowser._browser.Sync();

            ReporterWrapper.ReporterContext("Click on Login Button", () =>
            {
                lp.LoginButton.Click();
                // Add Button Click Validation
            });
        }

        [Test, Order(6)]
        public void CheckLogIn()
        {
            SolutionBrowser._browser.Sync();
            //ILink userWelcome = lp.CheckLogIn(FIRSTNAME, LASTNAME);

            var regex = "^Bonjour\\s" + user.FirstName + "\\s" + LASTNAME;
            VerifyWrapper.IsMatch(lp.LoggedInLink.InnerText, regex, "Check log in status", "Check if we were able to log in with the Excel file credentials.", SolutionBrowser.GetSnapshot());

            //if (userWelcome != null)
            //{
            //    string welcome = userWelcome.InnerText;
            //    var regex = "^Bonjour\\s" + user.FirstName + "\\s" + LASTNAME;

            //    var match = Regex.Match(welcome, regex, RegexOptions.IgnoreCase);

            //    if (!match.Success)
            //        Assert.Fail("The LogIn was not successful.");
            //}
            //else
            //    Assert.Fail("The LogIn was not successful.");
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
