using HP.LFT.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Extensions
{
    static public class ReporterWrapper
    {
        static public void ReporterContext(string contextName, Action action)
        {
            Reporter.StartReportingContext(contextName);
            action();
            Reporter.EndReportingContext();
        }
    }
}
