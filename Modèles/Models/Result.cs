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

        public ILink FirstProductLink
        {
            get
            {
                return ResultsTable.Describe<ILink>(new LinkDescription
                {
                    TagName = @"A",
                    Id = @"ctl04_rpTopResults_ctl00_ctTop_lsProducts_ctl00_mProduct_lnkTitle"
                });
            }
        }
    }
}
