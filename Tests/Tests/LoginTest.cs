using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using Modèles.Models;
using HP.LFT.SDK.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace Tests
{
    [TestFixture]
    public class LoginTest : UnitTestClassBase
    {
        private const string FILE_PATH = @"C:\Users\carel\Desktop\Stage\InfoAccounts.xlsx";
        private const string SITE = "Renaud-Bray";
        private const string FIRSTNAME = "Test";
        private const string LASTNAME = "Stage";

        IBrowser OBrowser;
        LoginPage lp = new LoginPage();
        Excel excel = new Excel();
        User user = new User();

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
            OBrowser = BrowserFactory.Launch(BrowserType.InternetExplorer);
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        [Test, Order(1)]
        public void LaunchSite()
        {
            OBrowser.Navigate("http://www.renaud-bray.com");
            lp.GetCurrentBrowser(OBrowser);
        }

        [Test, Order(2)]
        public void LoginLinkClick()
        {
            lp.LoginLink.Click();
        }

        [Test, Order(3)]
        public void GetUserInfos()
        {
            user = excel.GetUserFromName(FILE_PATH, SITE, FIRSTNAME, LASTNAME);
        }

        [Test, Order(4)]
        public void UsernameSet()
        {
            lp.UsernameEditField.SetValue(user.Email);
        }

        [Test, Order(5)]
        public void PasswordSet()
        {
            lp.PasswordEditField.SetValue(user.Pwd);
        }

        [Test, Order(6)]
        public void LoginButtonClick()
        {
            lp.LoginButton.Click();
        }

        [Test, Order(7)]
        public void CheckLogIn()
        {
            string welcome = lp.CheckLogIn(FIRSTNAME, LASTNAME).InnerText;
            var regex = "^Bonjour\\s" + user.FirstName + "\\s" + LASTNAME;

            var match = Regex.Match(welcome, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
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
