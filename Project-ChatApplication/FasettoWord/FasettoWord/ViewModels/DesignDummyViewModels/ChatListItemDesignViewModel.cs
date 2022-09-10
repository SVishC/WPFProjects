using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord
{
    /// <summary>
    /// Design time datacontext for ChatListItemControl
    /// </summary>
    public class ChatListItemDesignViewModel : ChatListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// Singleton for the class that is used in view
        /// </summary>
        public static ChatListItemDesignViewModel Instance => new ChatListItemDesignViewModel();

        #endregion

        #region Constructor


        public ChatListItemDesignViewModel()
        {
            Name = "Dummy";
            Initials = "DY";
            Message = "This is an awsome looking chat application ! I bet this will be fast too";
            ProfilePictureRGB = "3ba1d4";

        }

        #endregion
    }
}
