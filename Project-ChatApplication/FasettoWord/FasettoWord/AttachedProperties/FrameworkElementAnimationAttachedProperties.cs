using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FasettoWord
{

    /// <summary>
    /// AttachedProperty-Base :A base class to run any animation method when a boolean is set to true
    /// and a reverese animation when set to false.
    ///We have this class as abstract so that it can be used for any animation by just overriding <see cref="DoAnimation(FrameworkElement, bool)"/> method.
    ///otherwise if we have to have diferent animation then we should write so many methods for every animations in this same class
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent:BaseAttachedProperty<Parent,bool>,new()
    {

        #region Public Properties

        public bool FirstLoad { get; set; } = true;
        #endregion


        /// <summary>
        /// Instead of OnValueChanged we have onValueUpdated(Coerce approach) so that only during first load(even if the value doesnt change) we animate and after that we animate only when the value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //Get the framework element

            if (!(sender is FrameworkElement element))
                return;


            //Don't fire if the value is not changed , otherwise the same animation will happen twice
            //One exception is during first time load..First time even if the value is same we have to animate it,and that is why we have this OnValueUpdated in place

            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            //If it is the first time..Wait for the UI elements to load and then animate.otherwise animation will not be seen

            if (FirstLoad)
            {

                //create a single self-unhookable event-This event should be written in a way it just runs once (First load) and the unsubscribe itself
                RoutedEventHandler onLoaded = null;

                onLoaded = (s, e) =>
                           {
                               //Unhool ourselves
                               element.Loaded -= onLoaded;

                               //Do desired animation
                               DoAnimation(element, (bool)value);

                               //No longer in first load
                               FirstLoad = false;

                           };

                //Hooks into the Loaded event of the element
                element.Loaded += onLoaded;
            }
            else //if not first time we know all the UI elements are already loaded .Hence just animate
            {
                DoAnimation(element, (bool)value);
            }

        }

        /// <summary>
        /// The animation method that needs to be fired(by the child class) when the value changes
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
           //If this is not virtual we have to write switch-case statement for each animation type and seperately write logic to animate as specified 
        }

    }

    /// <summary>
    /// AttachedProperty : Animates a framework element sliding in from the left on show
    /// and sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) //Animate in
                await element.SlideAndFadeinFromLeft(FirstLoad ? 0: 0.3f,keepMargin:false);//Basically we just hide it during first time,so that during application load  we dont see animation,
                                                                                //after that we see the animation for 3 sec
                                                                                //KeepMargin=false because its similar to hidingthe side menu ,so we dont need to keep width
            else //Animate out
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f,keepMargin:false);
        }
    }
}
