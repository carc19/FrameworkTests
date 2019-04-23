using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Modèles.Models
{
    public class Excel
    {
        private const string EMAIL = "Email";
        private const string PWD = "Pwd";
        private const string FIRSTNAME = "FirstName";
        private const string LASTNAME = "LastName";
        private const string SITE = "Site";

        private Application app;
        private Workbook workbook;
        private Worksheet worksheet;
        private Range range;

        private void OpenFile(string filePath)
        {
            app = new Application();
            workbook = app.Workbooks.Open(filePath);
            worksheet = workbook.Sheets[1];
            range = worksheet.UsedRange;
        }

        private void CloseFile()
        {
            workbook.Close();
            app.Quit();
        }

        public User GetUserFromName(string filePath, string site, string firstName, string lastName)
        {
            int colEmail = 0;
            int colPwd = 0;
            int colFirstName = 0;
            int colLastName = 0;
            int colSite = 0;
            int colCount = 0;
            int rowCount = 0;
            User user = new User();

            OpenFile(filePath);

            colCount = range.Columns.Count;
            rowCount = range.Rows.Count;

            string value = "";
            for (int i = 1; i <= colCount; i++)
            {
                value = range.Cells[1, i].Value2;
                switch (value)
                {
                    case EMAIL:
                        colEmail = i;
                        break;
                    case PWD:
                        colPwd = i;
                        break;
                    case FIRSTNAME:
                        colFirstName = i;
                        break;
                    case LASTNAME:
                        colLastName = i;
                        break;
                    case SITE:
                        colSite = i;
                        break;
                    default:
                        break;
                }
            }

            bool found = false;
            int cpt = 1;

            while (!found && cpt <= rowCount)
            {
                if (range.Cells[cpt, colSite].Value2 == site && range.Cells[cpt, colFirstName].Value2 == firstName && range.Cells[cpt, colLastName].Value2 == lastName)
                {
                    user.Email = range.Cells[cpt, colEmail].Value2;
                    user.Pwd = range.Cells[cpt, colPwd].Value2;
                    user.FirstName = range.Cells[cpt, colFirstName].Value2;
                    user.LastName = range.Cells[cpt, colLastName].Value2;
                    found = true;
                }
                else
                    cpt++;
            }

            CloseFile();

            return user;
        }

        private Array ConvertToStringArray(Array array)
        {
            throw new NotImplementedException();
        }
    }
}
