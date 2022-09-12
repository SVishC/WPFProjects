using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord.Core
{
    /// <summary>
    /// A base viewmodel for each chat list item in the Chat List Menu
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {


        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The display name of the chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message for this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The RGB values (in hex ) for the background color of the profile picture
        /// For example FF00FF ..We will use value converter to convert this stricg to actual SOlidbrush in View
        /// </summary>
        public string ProfilePictureRGB { get; set; }


        /// <summary>
        /// True when the the messages are unread for a particular item/chat
        /// </summary>
        public bool IsNewMessageAvailable { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
