using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models
{
    static public class SolutionBrowser
    {
        public const string BROWSER_URL = "http://www.renaud-bray.com";

        static public IBrowser _browser;

        public static void LaunchBrowser()
        {
            _browser = BrowserFactory.Launch(BrowserType.InternetExplorer);
            _browser.Navigate(BROWSER_URL);
        }
    }
}
