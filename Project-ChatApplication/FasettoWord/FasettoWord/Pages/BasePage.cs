using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FasettoWord.Pages
{
    /// <summary>
    /// A base page from which all the other pages will inherit to gain the common functionalities like page animation etc.,
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
        public float SlideSeconds { get; set; } = 0.8f;
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
}
