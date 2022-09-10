using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord
{
    /// <summary>
    /// A base viewmodel for overall chat list(This will hold list of chatlistitemcontrols)
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// List of all the Messages / ChatListItemControlViewModel
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
