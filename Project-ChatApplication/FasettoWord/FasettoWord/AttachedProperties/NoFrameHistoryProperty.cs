
using System;
using System.Windows;
using System.Windows.Controls;

namespace FasettoWord
{

    /// <summary>
    /// Base attached property approach made defining the attached properties in the application simple in one line ,otherwise we have to register,setter and getters for every attached properties that we create
    /// This attached peoperty NoFrameHistoryProperty removes the Navigation UI Page History and HIdes the navigation bar in frame
    /// </summary>
    public class NoFrameHistoryProperty : BaseAttachedProperty<NoFrameHistoryProperty, bool>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Get the frame whose navigation bar needs to be removed
            var frame = d as Frame;

            //Hide the navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;


            //Remove the previous entry (clear history) so that there wont be anything to navigate back to.which will prevent using of Alt+arrow keys to navigate
            frame.Navigated += (ss, ee) =>
            {
                (ss as Frame).NavigationService.RemoveBackEntry();
            };
        }

    }




}
