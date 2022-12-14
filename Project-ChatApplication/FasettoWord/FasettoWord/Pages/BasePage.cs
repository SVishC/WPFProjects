using FasettoWord.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FasettoWord

{
    /// <summary>
    /// A Base Page for all the pages ,without view model support and only animation support
    /// </summary>
    public class BasePage : Page
    {

        #region Public Properties
        /// <summary>
        /// The animation that plays when  the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;


        /// <summary>
        /// THe animation that plays when the page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The duration for which the animation will happen
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate if this page should animate out on load
        /// Useful , when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }


        #endregion

        #region Constructor

        public BasePage()
        {

            //Listen out for the page loading

            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += BasePage_Loaded;

        }
        #endregion

        #region Animation Load /Unload 

        /// <summary>
        /// Once the page is loaded ,perform any required animation in this method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // if we are  setup to animate out on load animate out else animiate in
            if (ShouldAnimateOut)
                await AnimateOut();
            else
                await AnimateIn();

        }


        /// <summary>
        /// Animates in this page
        /// </summary>
        public async Task AnimateIn()
        {
            //If the animation is set to none dont animate,just return
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    await this.SlideAndFadeinFromRight(this.SlideSeconds);
                    break;
            }

        }


        /// <summary>
        /// Animates out this page
        /// </summary>
        public async Task AnimateOut()
        {
            //If the animation is set to none dont animate,just return
            if (this.PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
                    break;
            }

        }

        #endregion

    }



    /// <summary>
    /// A base page with view model support
    /// </summary>
    public class BasePage<VM> : BasePage
            where VM : BaseViewModel, new()
    {

        #region Private Members

        private VM mViewModel;

        #endregion

        #region Public Properties

        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                if (mViewModel == value)
                    return;

                mViewModel = new VM();


                //Set this Pages's data context to the view model that is passed in 
                this.DataContext = mViewModel;
            }
        }
        #endregion


        #region Constructor

        public BasePage():base()
        {


            //when the page loads for the first time create a new VM and store it for future use(in turn sets the data context)

            this.ViewModel = new VM();
        }


        #endregion


    }
}

