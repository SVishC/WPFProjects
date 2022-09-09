using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FasettoWord
{

    /// <summary>
    /// A base view model that all view models implents .This view model has propety changed and hence fires the event as and when needed.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged=(sender,e)=> { };


        /// <summary>
        /// call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name">Property should pass on its name</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set
        /// if the flag is true ( indicating that the  function is already running) the action is not executed
        /// is the flag is false ( indicating the function is not run yet) the action will be executed
        /// </summary>
        /// <param name="updatingFlag">the expression that needs to be compiled to get the bool property flag defining is the command is already running or not"/></param>
        /// <param name="action">The action that needs to be executed based on the <see cref="updatingFlag"/> value </param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action) //This approach may take time to implement initially,but reusability is high.So saves time in future for all button usage
        {
            //Check if the flag is true (meaning is the action/function is already running)
            if (updatingFlag.GetPropertyValueOfExpression())
                return;

            //if the control reaches here it means the action is not already running.
            //Hence set the flag to indicate that we are running the action
            updatingFlag.SetPropertyValueOfExpression(true);

            try
            {
                //Run the action thats passed in
                await action();
            }
            finally 
            {
                //when the action is completed again set the property/flag to false so that its not affected when next time its triggered.
                updatingFlag.SetPropertyValueOfExpression(false);
            }

        }

        #endregion
    }
}
