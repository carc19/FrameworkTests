using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models.Page
{
    public class SearchPage : Result
    {
        #region Propriétés
        public IEditField SearchEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    Id = @"pageSearch_txtSearch",
                    TagName = @"INPUT",
                    Type = @"text"
                });
            }
        }

        public IButton SearchButton
        {
            get
            {
                return Browser.Describe<IButton>(new ButtonDescription
                {
                    Id = @"pageSearch_btnSearch",
                    TagName = @"INPUT",
                    ButtonType = @"submit"
                });
            }
        }

        public IWebElement SearchCategories
        {
            //get
            //{
            //    return Browser.Describe<IEditField>(new EditFieldDescription
            //    {
            //        TagName = @"INPUT",
            //        Type = @"text",
            //        Id = @"pageSearch_rcbCategory_Input"
            //    });
            //}

            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"INPUT",
                    Id = @"pageSearch_rcbCategory_Input",
                });
            }
        }
        #endregion

        #region Méthodes
        public IWebElement CheckSearchResultAuthor()
        {
            IWebElement firstResultLink = ResultsTable.Describe<IWebElement>(new WebElementDescription
            {
                TagName = @"SPAN",
                Id = @"ctl04_rpTopResults_ctl00_ctTop_lsProducts_ctl00_mProduct_lblAuthor"
            });

            return firstResultLink;
        }
        #endregion
    }
}
