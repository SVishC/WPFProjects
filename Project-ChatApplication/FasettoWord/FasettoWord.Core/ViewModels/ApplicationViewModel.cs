using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// Carries the current application Page that is shown to user
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;


        /// <summary>
        /// True if side menu needs to be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// Method to navigate to the provided page and decide on sidemenu visibility
        /// </summary>
        /// <param name="page"></param>
        public void GotoPage(ApplicationPage page)
        {
            //Set the current page
            CurrentPage = page;

            //decide if we have to show the side menu

            SideMenuVisible = CurrentPage == ApplicationPage.Chat;
        }
    }
}
