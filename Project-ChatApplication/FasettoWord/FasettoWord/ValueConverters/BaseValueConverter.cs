using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace FasettoWord
{

    /// <summary>
    /// The base value converter that allows direct XAML usage 
    /// (The base converter is used to access any converters without creating a static resource in xaml .This way the xaml looks cleaner and avoids adding multiple converters in window resources)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members
        /// <summary>
        /// A Single static instance of the Value converter
        /// </summary>

        private static T mConverter = null;

        #endregion

        #region MarkupExtension Implementation

        /// <summary>
        /// whenever an instance of a child class is created it will hit this method and return the instance of child.
        /// So from the XAML you can directly access the converters without actually creating a static resource.
        /// In short this provides the Markup extension which is other wise provided by Static Resource in general
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        #endregion

        #region IValue Converter Implementation
        /// <summary>
        /// The child needs to implement its own convert and convertback method as this base is only to provide Markupextension to all the value converters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion

    }
}
