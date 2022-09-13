using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace FasettoWord
{
    /// <summary>
    /// Contains all the storyboard helpers through the application.
    /// By this approach we can created any animation once and can reuse it in any storyboards for any number of times
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Adds a slide from right animation to any storyboard passed
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="duration"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        ///<param name="keepMargin">whether to keep the element at the same width during the animation</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float duration, double offset, float decelerationRatio = 0.9f,bool keepMargin=true)
        {

            //create the margin animation from right
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = 0.9f
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin")); //Changing the margin thickness is basically responsible for slide animation

            //add the created animation to the storyboard on which this animation (should occur)/ is called
            storyboard.Children.Add(slideAnimation);

        }


        /// <summary>
        /// Adds a slide from Left - animation to any storyboard passed
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="duration"></param>
        /// <param name="offset">The distance from the left to start from</param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin">whether to keep the element at the same width during the animation</param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float duration, double offset, float decelerationRatio = 0.9f,bool keepMargin = true)
        {

            //create the margin animation from left
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(-offset, 0,keepMargin ?  offset :0 , 0),
                To = new Thickness(0),
                DecelerationRatio = 0.9f
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin")); //Changing the margin thickness is basically responsible for slide animation

            //add the created animation to the storyboard on which this animation (should occur)/ is called
            storyboard.Children.Add(slideAnimation);

        }

        /// <summary>
        /// Adds a slide to left animation to any storyboard passed
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="duration"></param>
        /// <param name="offset">The distance to the left to end at</param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin">whether to keep the element at the same width during the animation</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float duration, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {

            //create the margin animation from right
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = 0.9f
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin")); //Changing the margin thickness is basically responsible for slide animation

            //add the created animation to the storyboard on which this animation (should occur)/ is called
            storyboard.Children.Add(slideAnimation);

        }

        /// <summary>
        /// Adds a slide to Right animation to any storyboard passed
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="duration"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepMargin">whether to keep the element at the same width during the animation</param>
        public static void AddSlideToRight(this Storyboard storyboard, float duration, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {

            //create the margin animation to right
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness( keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = 0.9f
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin")); //Changing the margin thickness is basically responsible for slide animation

            //add the created animation to the storyboard on which this animation (should occur)/ is called
            storyboard.Children.Add(slideAnimation);

        }


        /// <summary>
        /// Adds a fade in animation to any storyboard passed
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="duration"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddFadeInAnimation(this Storyboard storyboard, float duration)
        {

            //create the Double animation which is responsible for the fade in
            var fadeInAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = 0,
                To = 1
            };

            //set the target property name
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity")); //Changing the Opacity property from 0 to 1 is basically fade in.

            //add the created animation to the storyboard on which this animation (should occur)/ is called
            storyboard.Children.Add(fadeInAnimation);

        }


        /// <summary>
        /// Adds a fade out animation to any storyboard passed
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="duration"></param>
        /// <param name="offset"></param>
        /// <param name="decelerationRatio"></param>
        public static void AddFadeOutAnimation(this Storyboard storyboard, float duration)
        {

            //create the Double animation which is responsible for the fade in
            var fadeInAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = 1,
                To = 0
            };

            //set the target property name
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity")); //Changing the Opacity property from 0 to 1 is basically fade in.

            //add the created animation to the storyboard on which this animation (should occur)/ is called
            storyboard.Children.Add(fadeInAnimation);

        }
    }
}
