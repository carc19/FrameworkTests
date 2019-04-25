using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models.Page
{
    public class AdvancedSearchPage : Page
    {
        public ILink AdvancedSearchLink
        {
            get
            {
                return Browser.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    Id = @"pageSearch_lnkAdvancedSearch"
                });
            }
        }

        public IEditField TitleEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    ClassName = @"textbox",
                    Id = @"searcher_txtTitle"
                });
            }
        }

        public IEditField AuthorEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    ClassName = @"textbox",
                    Id = @"searcher_txtAuthor"
                });
            }
        }

        public IEditField CollectionEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    ClassName = @"textbox",
                    Id = @"searcher_txtCollection"
                });
            }
        }

        public IEditField SubjectEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    ClassName = @"textbox",
                    Id = @"searcher_txtSubject"
                });
            }
        }

        public IEditField EditorEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    ClassName = @"textbox",
                    Id = @"searcher_txtEditor"
                });
            }
        }

        public IEditField ISBN_EAN13_EditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    ClassName = @"textbox",
                    Id = @"searcher_txtISBN"
                });
            }
        }

        public IEditField RBCodeEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    ClassName = @"textbox",
                    Id = @"searcher_txtCodeRB"
                });
            }
        }

        private IListBox ReleaseMonthStart
        {
            get
            {
                return Browser.Describe<IListBox>(new ListBoxDescription
                {
                    TagName = @"SELECT",
                    ClassName = @"dropdown",
                    Id = @"searcher_ddlOfficeStartMonth"
                });
            }
        }

        private IListBox ReleaseYearStart
        {
            get
            {
                return Browser.Describe<IListBox>(new ListBoxDescription
                {
                    TagName = @"SELECT",
                    ClassName = @"dropdown",
                    Id = @"searcher_ddlOfficeStartYear"
                });
            }
        }

        private IListBox ReleaseMonthEnd
        {
            get
            {
                return Browser.Describe<IListBox>(new ListBoxDescription
                {
                    TagName = @"SELECT",
                    ClassName = @"dropdown",
                    Id = @"searcher_ddlOfficeEndMonth"
                });
            }
        }

        private IListBox ReleaseYearEnd
        {
            get
            {
                return Browser.Describe<IListBox>(new ListBoxDescription
                {
                    TagName = @"SELECT",
                    ClassName = @"dropdown",
                    Id = @"searcher_ddlOfficeEndYear"
                });
            }
        }

        private IListBox CategoriesListBox
        {
            get
            {
                return Browser.Describe<IListBox>(new ListBoxDescription
                {
                    TagName = @"SELECT",
                    Id = @"searcher_ddlSearchCategories"
                });
            }
        }

        public ICheckBox CoupsCoeurCheckBox
        {
            get
            {
                return Browser.Describe<ICheckBox>(new CheckBoxDescription
                {
                    TagName = @"INPUT",
                    Type = @"checkbox",
                    Id = @"searcher_cbOnlyCC"
                });
            }
        }

        public ICheckBox ExcludeEnglishCheckBox
        {
            get
            {
                return Browser.Describe<ICheckBox>(new CheckBoxDescription
                {
                    TagName = @"INPUT",
                    Type = @"checkbox",
                    Id = @"searcher_cbExcludeEnglishBooks"
                });
            }
        }

        public IButton SearchButton
        {
            get
            {
                return Browser.Describe<IButton>(new ButtonDescription
                {
                    ButtonType = @"submit",
                    TagName = @"INPUT",
                    ClassName = @"btnSearch",
                    Id = @"searcher_btnSearch"
                });
            }
        }

        /// <summary>
        /// Set the start and end dates of the released for the search.
        /// </summary>
        /// <param name="startMonth">Month of the start date</param>
        /// <param name="startYear">Year of the start date</param>
        /// <param name="endMonth">Month of the end date</param>
        /// <param name="endYear">Year of the end date</param>
        public void SetDates(int startMonth, int startYear, int endMonth, int endYear)
        {
            ReleaseMonthStart.Select(ReleaseMonthStart.Items[startMonth]);
            ReleaseYearStart.Select(ReleaseYearStart.GetItem(startYear.ToString()));
            ReleaseMonthEnd.Select(ReleaseMonthEnd.Items[endMonth]);
            ReleaseYearEnd.Select(ReleaseYearEnd.GetItem(endYear.ToString()));
        }

        public void SelectCategory(int category)
        {
            CategoriesListBox.Select(CategoriesListBox.Items[category]);
        }
    }
}
