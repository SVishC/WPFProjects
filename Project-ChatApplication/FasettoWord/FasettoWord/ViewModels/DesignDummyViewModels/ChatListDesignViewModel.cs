using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord
{
    public class ChatListDesignViewModel : ChatListViewModel
    {

        #region Singleton

        /// <summary>
        /// A singleton instance of the design view model
        /// </summary>
        public static ChatListDesignViewModel Instance => new ChatListDesignViewModel();

        #endregion

        #region Constructor


        public ChatListDesignViewModel()
        {
            Items = new List<ChatListItemViewModel>()
            {
                new ChatListItemViewModel
                {
                      Name = "Dummy1",
                      Initials = "DY",
                      Message = "This is an awsome looking chat application ! I bet this will be fast too",
                      ProfilePictureRGB = "34910c"
                      ,IsNewMessageAvailable=true
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy2",
                      Initials = "DY2",
                      Message = "Hey dude,Here are the new Icons",
                      ProfilePictureRGB = "fe4503"
                      
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy3",
                      Initials = "DY3",
                      Message = "Machan , did you see the instagram Post,It's awesome !!",
                      ProfilePictureRGB = "3099c5"
                },

                 new ChatListItemViewModel
                {
                      Name = "Dummy1",
                      Initials = "DY",
                      Message = "This is an awsome looking chat application ! I bet this will be fast too",
                      ProfilePictureRGB = "34910c",
                      IsSelected=true
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy2",
                      Initials = "DY2",
                      Message = "Hey dude,Here are the new Icons",
                      ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy3",
                      Initials = "DY3",
                      Message = "Machan , did you see the instagram Post,It's awesome !!",
                      ProfilePictureRGB = "3099c5"
                },
                 new ChatListItemViewModel
                {
                      Name = "Dummy1",
                      Initials = "DY",
                      Message = "This is an awsome looking chat application ! I bet this will be fast too",
                      ProfilePictureRGB = "34910c"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy2",
                      Initials = "DY2",
                      Message = "Hey dude,Here are the new Icons",
                      ProfilePictureRGB = "fe4503"
                      
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy3",
                      Initials = "DY3",
                      Message = "Machan , did you see the instagram Post,It's awesome !!",
                      ProfilePictureRGB = "3099c5"
                },
                 new ChatListItemViewModel
                {
                      Name = "Dummy1",
                      Initials = "DY",
                      Message = "This is an awsome looking chat application ! I bet this will be fast too",
                      ProfilePictureRGB = "34910c"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy2",
                      Initials = "DY2",
                      Message = "Hey dude,Here are the new Icons",
                      ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy3",
                      Initials = "DY3",
                      Message = "Machan , did you see the instagram Post,It's awesome !!",
                      ProfilePictureRGB = "3099c5"
                },

                 new ChatListItemViewModel
                {
                      Name = "Dummy1",
                      Initials = "DY",
                      Message = "This is an awsome looking chat application ! I bet this will be fast too",
                      ProfilePictureRGB = "34910c"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy2",
                      Initials = "DY2",
                      Message = "Hey dude,Here are the new Icons",
                      ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy3",
                      Initials = "DY3",
                      Message = "Machan , did you see the instagram Post,It's awesome !!",
                      ProfilePictureRGB = "3099c5"
                },
                 new ChatListItemViewModel
                {
                      Name = "Dummy1",
                      Initials = "DY",
                      Message = "This is an awsome looking chat application ! I bet this will be fast too",
                      ProfilePictureRGB = "34910c"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy2",
                      Initials = "DY2",
                      Message = "Hey dude,Here are the new Icons",
                      ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                      Name = "Dummy3",
                      Initials = "DY3",
                      Message = "Machan , did you see the instagram Post,It's awesome !!",
                      ProfilePictureRGB = "3099c5"
                },


            };
        }

        #endregion
    }
}
