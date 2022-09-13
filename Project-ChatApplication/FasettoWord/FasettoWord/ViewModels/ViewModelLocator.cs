using FasettoWord.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord
{
    /// <summary>
    /// Locates viewmodels from the IoC container for using it in binding in xaml files
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        /// sindleton instance ofg the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model instance from which we can get the current page in xaml
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

    }
}
