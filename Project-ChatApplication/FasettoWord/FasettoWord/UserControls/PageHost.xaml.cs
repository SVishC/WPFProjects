using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FasettoWord
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Constructor
        
        /// <summary>
        /// Default Constructor for the user control
        /// </summary>
        public PageHost()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// DEPENDENCY PROPERTY: Generally we use Dependency poroperty to be able to set value for any property in xaml via binding or animation etc.,
        /// </summary>

        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        ///The CurrentPage Depependency Property
        /// </summary>
        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));


        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Logic to push current page to old page and add new page as current page

            //Get the 2 frames defined in the Page Host
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;


            //Store the current Page content as the old page 
            var oldPageContent = newPageFrame.Content;

            //Copy the Previous Page (Current Page) content into the old page frame
            oldPageFrame.Content = oldPageContent;

            //Remove the current Page from new page frame
            newPageFrame.Content = null;

            //Animate  out the old page when the Page loaded event fires
            //right after this call basepage load even will be automatically fired by UI as we move the frames from one to another
            if (oldPageContent is BasePage oldPage) //during the first load the old page is null so it wont go inside this if statement
                oldPage.ShouldAnimateOut = true;

            //Set the newpage content

            newPageFrame.Content = e.NewValue; 

        }



        #endregion
    }
}
