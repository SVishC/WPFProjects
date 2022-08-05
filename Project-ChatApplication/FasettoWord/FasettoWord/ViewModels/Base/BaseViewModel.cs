using PropertyChanged;
using System.ComponentModel;


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
    }
}
