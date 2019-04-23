using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèles.Models
{
    public class LoginPage
    {
        private IBrowser _oBrowser;

        public ILink LoginLink
        {
            get { return _oBrowser.Describe<ILink>(new LinkDescription
            {
               Id = @"pageHeader_loginView_lnkConnect",
               TagName = @"A"
            });
            ;}
        }

        public IEditField UsernameEditField
        {
            get
            {
                return _oBrowser.Describe<IEditField>(new EditFieldDescription
                {
                    Id = @"loginCtrl_UcLoginConnect1_uiEditEmail"
                });
            }
        }

        public IEditField PasswordEditField
        {
            get
            {
                return _oBrowser.Describe<IEditField>(new EditFieldDescription
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
                return _oBrowser.Describe<IButton>(new ButtonDescription
                {
                    Id = @"loginCtrl_UcLoginConnect1_uiSubmitButton",
                    TagName = @"BUTTON",
                    ButtonType = @"submit"
                });
            }
        }

        public ILink CheckLogIn(string firstName, string lastName)
        {
            ILink userWelcome = _oBrowser.Describe<ILink>(new LinkDescription
            {
                ClassName = @"rmLink rmRootLink",
                TagName = @"A",
                InnerText = @"Bonjour " + firstName + " " + lastName
            });

            return userWelcome;
        }

        public ILink RegisteredUser
        {
            get
            {
                return _oBrowser.Describe<ILink>(new LinkDescription
                {
                    ClassName = @"rmLink rmRootLink",
                    TagName = @"A",
                    InnerText = @"^Bonjour\s"
                });
            }
        }

        /// <summary>
        /// IMPORTANT: Needs to be done before the properties are used.
        /// Gets the current browser from the tests.
        /// </summary>
        /// <param name="currentBrowser">Browser used for the tests</param>
        public void GetCurrentBrowser(IBrowser currentBrowser)
        {
            _oBrowser = currentBrowser;
        }
    }
}
