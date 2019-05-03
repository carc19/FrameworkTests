using HP.LFT.Report;
using HP.LFT.Verifications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tests.Extensions
{
    static public class VerifyWrapper
    {
        /// <summary>
        /// Description: Check if the value match what was expected.
        /// </summary>
        /// <param name="actual">Value</param>
        /// <param name="pattern">Regex pattern</param>
        /// <param name="verificationName">Name given to the verification</param>
        /// <param name="verificationDescription">Description of the verification</param>
        /// <param name="img">Snapshot of the browser after action</param>
        static public void IsMatch(string actual, string pattern, string verificationName, string verificationDescription, Image img)
        {
            if (img == null)
                verificationDescription += " No snapshot were taken.";

            try
            {
                Verify.IsMatch(actual, "(?i)" + pattern, "Verification - " + verificationName, verificationDescription);
                Assert.IsTrue(Regex.IsMatch(actual, pattern, RegexOptions.IgnoreCase), verificationName + " : " + verificationDescription);
            }
            catch (Exception ex)
            {
                Reporter.ReportEvent("Reporter - " + verificationName, ex.Message, Status.Failed, img);
            }
        }

        /// <summary>
        /// Description: Check if an object isn't null.
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="verificationName">Name given to the verification</param>
        /// <param name="verificationDescription">Description of the verification</param>
        static public void IsNotNull(Object obj, string verificationName, string verificationDescription)
        {
            bool success = false;
            try
            {
                if (obj != null)
                    success = true;

                Assert.IsTrue(success, verificationName + " : " + verificationDescription);
            }
            catch (Exception ex)
            {
                Reporter.ReportEvent("Reporter - " + verificationName, ex.Message, Status.Failed);
            }
        }

        /// <summary>
        /// Description: Checks if a string is null or empty.
        /// </summary>
        /// <param name="aString">String to check</param>
        /// <param name="verificationName">Name given to the verification</param>
        /// <param name="verificationDescription">Description of the verification</param>
        /// <param name="img">Snapshot of the browser after action</param>
        static public void IsNotNullOrEmpty(string aString, string verificationName, string verificationDescription, Image img)
        {
            if (img == null)
                verificationDescription += " No snapshot were taken.";

            try
            {
                Verify.IsNotNullOrEmpty(aString, "Verification - " + verificationName, verificationDescription, img);
                Assert.IsNotNull(aString, verificationName + " : " + verificationDescription);
            }
            catch (Exception ex)
            {
                Reporter.ReportEvent("Reporter - " + verificationName, ex.Message, Status.Failed, img);
            }
        }
    }
}
