using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Modèles.Models
{
    static public class SolutionBrowser
    {
        public const string BROWSER_URL = "http://www.renaud-bray.com";
        //public const string BROWSER_URL = "https://www.google.com";

        static public IBrowser _browser;

        static public void LaunchBrowser()
        {
            _browser = BrowserFactory.Launch(BrowserType.InternetExplorer);
            _browser.Navigate(BROWSER_URL);
        }

        static public Image GetSnapshot()
        {
            Image img = null;

            if (_browser != null)
                img = _browser.GetSnapshot();

            return img;
        }
    }
}
