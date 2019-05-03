using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models.Page
{
    public class LoginPage : Page
    {
        public ILink LoginLink
        {
            get
            {
                return Browser.Describe<ILink>(new LinkDescription
                {
                    Id = @"pageHeader_loginView_lnkConnect",
                    TagName = @"A"
                });
                ;
            }
        }

        public IEditField UsernameEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    Id = @"loginCtrl_UcLoginConnect1_uiEditEmail"
                });
            }
        }

        public IEditField PasswordEditField
        {
            get
            {
                return Browser.Describe<IEditField>(new EditFieldDescription
                {
                    Id = @"loginCtrl_UcLoginConnect1_uiEditPassword",
                    TagName = @"INPUT",
                    Type = @"password"
                });
            }
        }

        public IButton LoginButton
        {
            get
            {
                return Browser.Describe<IButton>(new ButtonDescription
                {
                    Id = @"loginCtrl_UcLoginConnect1_uiSubmitButton",
                    TagName = @"BUTTON",
                    ButtonType = @"submit"
                });
            }
        }

        public IWebElement LoggedInLink
        {
            get
            {
                return Browser.Describe<IWebElement>(new LinkDescription
                {
                    ClassName = @"rmText rmExpandDown",
                    TagName = @"SPAN",
                    InnerText = @"Bonjour"
                });
            }
        }

        public ILink CheckLogIn(string firstName, string lastName)
        {
            ILink userWelcome = null;

            try
            {
                userWelcome = Browser.Describe<ILink>(new LinkDescription
                {
                    ClassName = @"rmLink rmRootLink",
                    TagName = @"A",
                    InnerText = @"Bonjour " + firstName + " " + lastName
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userWelcome;
        }
    }
}
