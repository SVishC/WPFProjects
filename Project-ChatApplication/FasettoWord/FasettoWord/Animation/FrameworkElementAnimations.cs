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
    /// Contains the helpers for the framework animations
    /// </summary>
    public static class FrameworkElementAnimations
    {

        /// <summary>
        /// Method to create story board for the framework that is passed-in,which in turn calls for animation creation (A storyboard can contain number of animations combined together)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeinFromRight(this FrameworkElement element, float duration=0.3f,bool keepMargin=true)
        {
            //create a stroryboard for the framework element to animate.Story board is nothing but a holder which can hold number of animations for same control
            var storyboard = new Storyboard();


            //add the thickness animation for the created storyboard
            storyboard.AddSlideFromRight(duration, element.ActualWidth,keepMargin:keepMargin);

            //Add the fade in animation for the same storyboard
            storyboard.AddFadeInAnimation(duration);

            //start the animation
            storyboard.Begin(element);

            //Make the framework element visible
            element.Visibility = Visibility.Visible;



            //Since this is an async task it will fire the animation and move to the next line of code .
            //But as we see ,the animation runs in for SlideSeconds time.Hence we need to await for that much time before we move from this position
            await Task.Delay((int)duration * 1000);

        }


        /// <summary>
        /// Method to create story board for the framework that is passed-in,which in turn calls for animation creation (A storyboard can contain number of animations combined together)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeinFromLeft(this FrameworkElement element, float duration=0.3f,bool keepMargin=true)
        {
            //create a stroryboard for the framework element to animate.Story board is nothing but a holder which can hold number of animations for same control
            var storyboard = new Storyboard();


            //add the thickness animation for the created storyboard
            storyboard.AddSlideFromLeft(duration, element.ActualWidth, keepMargin: keepMargin);

            //Add the fade in animation for the same storyboard
            storyboard.AddFadeInAnimation(duration);

            //start the animation
            storyboard.Begin(element);

            //Make the framework element visible
            element.Visibility = Visibility.Visible;



            //Since this is an async task it will fire the animation and move to the next line of code .
            //But as we see ,the animation runs in for SlideSeconds time.Hence we need to await for that much time before we move from this position
            await Task.Delay((int)duration * 1000);

        }

        /// <summary>
        /// Method to create story board for the framework element that is passed-in,which in turn calls for animation creation (A storyboard can contain number of animations combined together)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float duration=0.3f,bool keepMargin=true)
        {
            //create a stroryboard for the element to animate.Story board is nothing but a holder which can hold number of animations for same control
            var storyboard = new Storyboard();


            //add the thickness animation for the created storyboard
            storyboard.AddSlideToLeft(duration, element.ActualWidth,keepMargin:keepMargin);

            //Add the fade out animation for the same storyboard
            storyboard.AddFadeOutAnimation(duration);

            //start the animation
            storyboard.Begin(element);

            //Make the page visible
            element.Visibility = Visibility.Visible;



            //Since this is an async task it will fire the animation and move to the next line of code .
            //But as we see ,the animation runs in for SlideSeconds time.Hence we need to await for that much time before we move from this position
            await Task.Delay((int)duration * 1000);

        }

        /// <summary>
        /// Method to create story board for the framework element that is passed-in,which in turn calls for animation creation (A storyboard can contain number of animations combined together)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float duration = 0.3f,bool keepMargin=true)
        {
            //create a stroryboard for the element to animate.Story board is nothing but a holder which can hold number of animations for same control
            var storyboard = new Storyboard();


            //add the thickness animation for the created storyboard
            storyboard.AddSlideToRight(duration, element.ActualWidth, keepMargin: keepMargin);

            //Add the fade out animation for the same storyboard
            storyboard.AddFadeOutAnimation(duration);

            //start the animation
            storyboard.Begin(element);

            //Make the page visible
            element.Visibility = Visibility.Visible;



            //Since this is an async task it will fire the animation and move to the next line of code .
            //But as we see ,the animation runs in for SlideSeconds time.Hence we need to await for that much time before we move from this position
            await Task.Delay((int)duration * 1000);

        }
    }
}
