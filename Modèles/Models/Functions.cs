using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models
{
    public static class Functions
    {
        public static int ConvertMonthToInt(string month)
        {
            int convertedMonth = 0;

            switch (month.ToLower())
            {
                case "janvier":
                case "january":
                    convertedMonth = 1;
                    break;
                case "février":
                case "february":
                    convertedMonth = 2;
                    break;
                case "mars":
                case "march":
                    convertedMonth = 3;
                    break;
                case "avril":
                case "april":
                    convertedMonth = 4;
                    break;
                case "mai":
                case "may":
                    convertedMonth = 5;
                    break;
                case "juin":
                case "june":
                    convertedMonth = 6;
                    break;
                case "juillet":
                case "july":
                    convertedMonth = 7;
                    break;
                case "août":
                case "august":
                    convertedMonth = 8;
                    break;
                case "septembre":
                case "september":
                    convertedMonth = 9;
                    break;
                case "octobre":
                case "october":
                    convertedMonth = 10;
                    break;
                case "novembre":
                case "november":
                    convertedMonth = 11;
                    break;
                case "décembre":
                case "december":
                    convertedMonth = 12;
                    break;
            }

            return convertedMonth;
        }
    }
}
