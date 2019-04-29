using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models
{
    public class Result : Page.Page
    {
        protected ITable ResultsTable
        {
            get
            {
                return Browser.Describe<ITable>(new TableDescription
                {
                    Id = @"ctl04_rpTopResults_ctl00_ctTop_lsProducts",
                    TagName = @"TABLE"
                });
            }
        }

        private ILink firstProductTopResults
        {
            get
            {
                return SolutionBrowser._browser.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    Id = @"ctl04_rpTopResults_ctl00_ctTop_lsProducts_ctl00_mProduct_lnkTitle"
                });
            }
        }

        private ILink firstProductResultsList
        {
            get
            {
                return SolutionBrowser._browser.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    Id = @"ctl04_rpResultsList_ctl00_p_lnkTitle"
                });
            }
        }

        //private ILink firstProductTopResults = SolutionBrowser._browser.Describe<ILink>(new LinkDescription
        //{
        //    TagName = @"A",
        //    Id = @"ctl04_rpTopResults_ctl00_ctTop_lsProducts_ctl00_mProduct_lnkTitle"
        //});

        //private ILink firstProductResultsList = SolutionBrowser._browser.Describe<ILink>(new LinkDescription
        //{
        //    TagName = @"A",
        //    Id = @"ctl04_rpResultsList_ctl00_p_lnkTitle"
        //});

        public void FirstProductClick()
        {
            if (firstProductResultsList.Exists())
                firstProductResultsList.Click();
            else if (firstProductTopResults.Exists())
                firstProductTopResults.Click();
            else
                throw new Exception("No result found.");
        }

        public ILink FirstProductLink
        {
            get
            {
                return ResultsTable.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    Id = @"ctl04_rpTopResults_ctl00_ctTop_lsProducts_ctl00_mProduct_lnkTitle"
                    //ctl04_rpResultsList_ctl00_p_lnkTitle // Lorsqu'il y a un seul produit
                });
            }
        }

        public ILink AddToCartLink
        {
            get
            {
                return ResultsTable.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    Id = @"ctl04_rpResultsList_ctl00_p_ctl00_lnkCart"
                });
            }
        }
    }
}
