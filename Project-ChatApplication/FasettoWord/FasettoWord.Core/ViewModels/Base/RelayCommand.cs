using System;
using System.Windows.Input;

namespace FasettoWord.Core
{
    /// <summary>
    /// A basic command that runs an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// An action to run by the command.
        /// </summary>
        private Action mAction;

        #endregion


        #region Public Methods

        #region Constructor

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion


        #region ICommand Implementation
        /// <summary>
        /// Event thats triggered when <see cref="CanExecute(object)"/> value is changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// For now always returns true which means whenever the command is triggered it will execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// method that executes the command thats carried by the action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion


        #endregion
    }
}
