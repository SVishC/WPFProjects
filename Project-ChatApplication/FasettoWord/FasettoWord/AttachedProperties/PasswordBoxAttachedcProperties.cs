
using System;
using System.Windows;
using System.Windows.Controls;

namespace FasettoWord
{
    /// <summary>
    /// Base attached property approach made defining the attached properties in the application simple in one line ,otherwise we have to register,setter and getters for every attached properties that we create
    /// </summary>

    public class MonitorPassWordProperty : BaseAttachedProperty<MonitorPassWordProperty, bool>
    {

        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;


            if (passwordBox == null)
                return;


            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValue((PasswordBox)d);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }


        /// <summary>
        /// Fired when Password is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }


    }


    /// <summary>
    /// Base attached property approach made defining the attached properties in the application simple in one line ,otherwise we have to register,setter and getters for every attached properties that we create
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(object sender)
        {
            SetValue(sender as PasswordBox, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }


    

}
