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
        /// Animates this page
        /// </summary>
        public async Task AnimateIn()
        {
            //If the animation is set to none dont animate,just return
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    var sb = new Storyboard();
                    var slideAnimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                        From = new Thickness(this.WindowWidth, 0,-this.WindowWidth,0 ),
                        To = new Thickness(0),
                        DecelerationRatio=0.9f
                    };
                    Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                    sb.Children.Add(slideAnimation);

                    sb.Begin(this);

                    this.Visibility = Visibility.Visible;

                    //Since this is an async task it will fire the animation and move to the next line of code .
                    //But as we see ,the animation runs in for SlideSeconds time.Hence we need to await for that much time before we move from this position

                    await Task.Delay((int)this.SlideSeconds * 1000);


                    break;
            }
            
        }


        #endregion

    }
}
