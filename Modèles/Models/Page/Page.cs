using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models.Page
{
    public class Page
    {
        protected IBrowser Browser
        {
            get
            {
                return SolutionBrowser._browser;
            }
        }
    }
}
