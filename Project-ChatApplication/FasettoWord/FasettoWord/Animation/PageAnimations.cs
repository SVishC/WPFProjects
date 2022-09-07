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
    /// Contains the helpers for the Page animations
    /// </summary>
    public static class PageAnimations
    {

        /// <summary>
        /// Method to create story board for the page that is passed-in,which in turn calls for animation creation (A storyboard can contain number of animations combined together)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeinFromRight(this Page page, float duration)
        {
            //create a stroryboard for the page to animate.Story board is nothing but a holder which can hold number of animations for same control
            var storyboard = new Storyboard();


            //add the thickness animation for the created storyboard
            storyboard.AddSlideFromRight(duration, page.WindowWidth);

            //Add the fade in animation for the same storyboard
            storyboard.AddFadeInAnimation(duration);

            //start the animation
            storyboard.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;



            //Since this is an async task it will fire the animation and move to the next line of code .
            //But as we see ,the animation runs in for SlideSeconds time.Hence we need to await for that much time before we move from this position
            await Task.Delay((int)duration * 1000);

        }

        /// <summary>
        /// Method to create story board for the page that is passed-in,which in turn calls for animation creation (A storyboard can contain number of animations combined together)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float duration)
        {
            //create a stroryboard for the page to animate.Story board is nothing but a holder which can hold number of animations for same control
            var storyboard = new Storyboard();


            //add the thickness animation for the created storyboard
            storyboard.AddSlideToLeft(duration, page.WindowWidth);

            //Add the fade out animation for the same storyboard
            storyboard.AddFadeOutAnimation(duration);

            //start the animation
            storyboard.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;



            //Since this is an async task it will fire the animation and move to the next line of code .
            //But as we see ,the animation runs in for SlideSeconds time.Hence we need to await for that much time before we move from this position
            await Task.Delay((int)duration * 1000);

        }
    }
}
