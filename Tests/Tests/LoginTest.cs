using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models;
using Modèles.Models.Page;
using HP.LFT.SDK.Web;
using System.IO;
using System.Text.RegularExpressions;

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
        public void LoginLinkClick()
        {
            SolutionBrowser._browser.Sync();
            lp.LoginLink.Click();
        }

        [Test, Order(2)]
        public void GetUserInfos()
        {
            user = excel.GetUserFromName(FILE_PATH, SITE, FIRSTNAME, LASTNAME);
        }

        [Test, Order(3)]
        public void UsernameSet()
        {
            SolutionBrowser._browser.Sync();
            lp.UsernameEditField.SetValue(user.Email);
        }

        [Test, Order(4)]
        public void PasswordSet()
        {
            SolutionBrowser._browser.Sync();
            lp.PasswordEditField.SetValue(user.Pwd);
        }

        [Test, Order(5)]
        public void LoginButtonClick()
        {
            SolutionBrowser._browser.Sync();
            lp.LoginButton.Click();
        }

        [Test, Order(6)]
        public void CheckLogIn()
        {
            SolutionBrowser._browser.Sync();
            ILink userWelcome = lp.CheckLogIn(FIRSTNAME, LASTNAME);

            if (userWelcome != null)
            {
                string welcome = userWelcome.InnerText;
                var regex = "^Bonjour\\s" + user.FirstName + "\\s" + LASTNAME;

                var match = Regex.Match(welcome, regex, RegexOptions.IgnoreCase);

                if (!match.Success)
                    Assert.Fail("The LogIn was not successful.");
            }
            else
                Assert.Fail("The LogIn was not successful.");
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
