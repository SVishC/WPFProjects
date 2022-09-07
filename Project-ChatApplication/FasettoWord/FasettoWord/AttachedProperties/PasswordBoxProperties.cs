using System;
using System.Windows;
using System.Windows.Controls;

namespace FasettoWord
{
   public class PasswordBoxProperties
    {
        public static readonly DependencyProperty MonitorPasswordProperty =
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false,onMonitorPasswordChanged));

        private static void onMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) //acts like a constructor in this logic ( not generally) to subscribe to password changed event
        {
            PasswordBox passwordBox = d as PasswordBox;

            if (passwordBox == null)
                return;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged; //desuscribre otherwise same event will be hooked many times

            if ((bool)e.NewValue)
            {
                SetHasText(passwordBox); //First time the event would not have been subscribed (we subscribe it only after new value is available) hence setting the value manually by calling SetHasText
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }

        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
       {
            SetHasText((PasswordBox)sender);
        }

        public static void SetMonitorPassword(PasswordBox element,bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }


        public static readonly DependencyProperty HasTextProperty = 
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));

        public static void SetHasText(PasswordBox element )
        {
            element.SetValue(HasTextProperty, element.Password.Length > 0);
        }

        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }

    }
}
