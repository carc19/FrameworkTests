using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models.Page
{
    public class ProductPage : Page
    {
        public ILink AuthorLink
        {
            get
            {
                return Browser.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    ClassName = @"lnkItem",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_repSearchSimilarAuthor_adv2_ctl00_lnkItem"
                });
            }
        }

        public IWebElement Title
        {
            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"SPAN",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_lblTitle2Info"
                });
            }
        }

        public IWebElement ReleaseDate
        {
            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"SPAN",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_lblDate"
                });
            }
        }

        public IWebElement Editor
        {
            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"SPAN",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_lblEditorInfo"
                });
            }
        }

        public IWebElement Collection
        {
            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"SPAN",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_lblCollectionInfo"
                });
            }
        }

        public IWebElement Subject
        {
            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"SPAN",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_lblSubjectInfo"
                });
            }
        }

        public IWebElement ISBN
        {
            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"SPAN",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_lblISBNInfo"
                });
            }
        }

        public IWebElement RBCode
        {
            get
            {
                return Browser.Describe<IWebElement>(new WebElementDescription
                {
                    TagName = @"SPAN",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_lblRerenceInfo"
                });
            }
        }

        public ILink AddToCart
        {
            get
            {
                return Browser.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_mc_lnkCart"
                });
            }
        }

        public IEditField Quantity
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    TagName = @"INPUT",
                    Type = @"text",
                    Id = @"ctl09_ctl01_mz1Div_ctl00_ctl00_mc_txtQty_adv2"
                });
            }
        }
    }
}
