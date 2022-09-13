using FasettoWord.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FasettoWord
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>,IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Store the SecurePassword for this page as an element that implements <see cref="IHavePassword"/> so that this can be accessed in viewmodel
        /// </summary>
        public SecureString MySecurePassword => PassWordText.SecurePassword;
    }
}
