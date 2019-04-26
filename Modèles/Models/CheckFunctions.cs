using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modèles.Models
{
    public static class CheckFunctions
    {
        /// <summary>
        /// Checks if the a specific element of a product matches the search.
        /// </summary>
        /// <param name="search">Searched string</param>
        /// <param name="result">WebElement result</param>
        /// <returns></returns>
        public static bool CompareSearchResult(string search, IWebElement result)
        {
            bool success = true;

            if (search != null && result != null)
            {
                string innerText = result.InnerText;

                var match = Regex.Match(innerText, search, RegexOptions.IgnoreCase);

                if (!match.Success)
                    success = false;
            }

            return success;
        }

        public static bool CompareReleaseDate(int startMonth, int startYear, int endMonth, int endYear, IWebElement resultDate)
        {
            bool success = true;

            if (startMonth > 0 && startYear > 0 && endMonth > 0 && endYear > 0 && resultDate != null)
            {
                string innerText = resultDate.InnerText;

                Regex regMonth = new Regex(@"(?<Month>[a-zA-Z]{3,10})");
                Regex regYear = new Regex(@"(?<Year>[0-9]{4})");

                Match matchMonth = regMonth.Match(innerText);
                Match matchYear = regYear.Match(innerText);
                int year = int.Parse(matchYear.Value);

                if (matchMonth.Success && matchYear.Success)
                {
                    if (year >= startYear && year <= endYear)
                    {
                        int convertedMonth = Functions.ConvertMonthToInt(matchMonth.Value);

                        if (!(convertedMonth >= startMonth && convertedMonth <= startYear))
                            success = false;
                    }
                    else
                        success = false;
                }
            }
            return success;
        }
    }
}
