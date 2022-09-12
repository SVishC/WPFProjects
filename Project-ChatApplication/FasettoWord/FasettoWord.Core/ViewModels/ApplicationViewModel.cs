using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// Carries the current application Page that is shown to user
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
    }
}
