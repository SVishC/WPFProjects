using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FasettoWord
{
    /// <summary>
    /// A base attached property that inturn is a wrapper around WPF attached propeties.
    /// This approach is followed to reduce the type error by creating attached properies manually 
    /// </summary>
    /// <typeparam name="Parent">The parent class to be the attached property</typeparam>
    /// <typeparam name="Property">The type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent,Property>
        where Parent: BaseAttachedProperty<Parent, Property>, new() //says parent is of its own type (so that we can use the Instance of the inherited class for calling OnValueChanged)and newable
    {

        #region Public Events

        /// <summary>
        /// Fired when the value changes in the control
        /// </summary>
       // public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region public Properties

        //A singleton instance of the parent
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        //Here we will create or define Attached property once with the Name 'Value'(can be anything else)
        //and for all the attached propereties that inherit this base will access the attached properties using ".Value". 



        public static Property GetValue(DependencyObject obj) => (Property)obj.GetValue(ValueProperty);

        public static void SetValue(DependencyObject obj, Property value) => obj.SetValue(ValueProperty, value);
        
        /// <summary>
        /// The attached property for this base class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", 
                typeof(Property), 
                typeof(BaseAttachedProperty<Parent,Property>), 
                new PropertyMetadata(
                    default(Property),
                    new PropertyChangedCallback(OnValuePropertyChanged),
                    new CoerceValueCallback(OnValuePropertyUpdated) //This CoerceValueCallback is used to tweak the value thats set to this attached property,
                                                                    //here we use it to our convinience to get notified whenever value is set to the attached property,even when OnProperty changed doesnt fire
                    ));

  

        /// <summary>
        /// The callback that is fired when <see cref="ValueProperty" is changed/>
        /// </summary>
        /// <param name="d">The UI element that had its property changed</param>
        /// <param name="e">The arguements for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //call the parent function

            Instance.OnValueChanged(d, e);

            //call event Listeners
           // Instance.ValueChanged(d, e);
           
        }


        /// <summary>
        /// The callback that is fired when <see cref="ValueProperty"/> is changed,even if it is the same value
        /// </summary>
        /// <param name="d">The UI element that had its property changed</param>
        /// <param name="e">The arguements for the event</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            //call the parent function

            Instance.OnValueUpdated(d, value);

            //call event Listeners
            // Instance.ValueChanged(d, e);

            //return the value
            return value;

        }


        #endregion

        #region Event Methods

        /// <summary>
        /// This Method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        { }


        /// <summary>
        /// This Method that is called when any attached property of this type is set,even when the value doesn't change
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public virtual void OnValueUpdated(DependencyObject d, object e)
        { }

        #endregion
    }
}
