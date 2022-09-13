using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FasettoWord.Core
{
    /// <summary>
    /// View Model to style the window and have the sizes customizable
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Private Members

        //private bool isRegisterRunning = false;
        #endregion

        #region Public Members


        /// <summary>
        /// The Email entered by the user in login page
        /// </summary>
        public string Email { get; set; }


        //The Secure Password entered by the user
        public SecureString Password { get; set; }



        public bool RegisterIsRunning { get; set; }

        #endregion


        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }


        #endregion


        #region Constructor

        public RegisterViewModel()
        {

            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());


        }



        #endregion

        #region Public Methods


        /// <summary>
        /// The Command Execute method for Login Command
        /// </summary>
        /// <param name="parameter">The secure string that is passed on from the View/Page</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {


            await RunCommand(() => this.RegisterIsRunning,
                async () =>
                {
                    await Task.Delay(5000);

                }
               );

        }


        private async Task LoginAsync()
        {
            IoC.Get<ApplicationViewModel>().GotoPage(ApplicationPage.Login);
            await Task.Delay(1);

        }

        #endregion

    }
}
