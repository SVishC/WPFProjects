using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FasettoWord
{
    /// <summary>
    /// View Model to style the window and have the sizes customizable
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Members


        #endregion

        #region Public Members


        /// <summary>
        /// The Email entered by the user in login page
        /// </summary>
        public string Email { get; set; }


        //The Secure Password entered by the user
        public SecureString Password { get; set; }


        #endregion


        #region Commands

        public ICommand LoginCommand { get; set; }


        #endregion


        #region Constructor

        public LoginViewModel()
        {

            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));

       
        }


        #endregion

        #region Public Methods

        
        /// <summary>
        /// The Command Execute method for Login Command
        /// </summary>
        /// <param name="parameter">The secure string that is passed on from the View/Page</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            await Task.Delay(500);
        }

        #endregion

    }
}
