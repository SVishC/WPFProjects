using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FasettoWord
{
    /// <summary>
    /// View Model to style the window and have the sizes customizable
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private MainWindow mWindow;


        /// <summary>
        /// The Margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;


        /// <summary>
        /// Corner radius of the window
        /// </summary>
        private int mWindowRadius = 10;


        #endregion

        #region Public Members


        #region Commands
        public ICommand MenuCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }


        #endregion

        /// <summary>
        /// Property for the window's minimum width
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// Property for the window's minimum Height
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// Actual numerical value of the resize border (How far the <-> resize cursor can come inside from the margin)
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The thickness property that is bound to the window chrome's ResizeBorderThickness Property.
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } } 

        //When we only consider the ResizeBorder value we are going to have cursor starting from drop shadow(OuterMargin) and have 6 pixels inside.
        //Hence it may not reach the real border of application.So we consider the outer margin also so the <-> Resizecursor size will be equal to the outer margin + 6 here.

        /// <summary>
        /// The Margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; //When the screen is maximized we dont have the drop shadow so we can remove the outer margin
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The actual thickness object , which uses <see cref="OuterMarginSize"/> value and returns thickness which can be bound in the xaml
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get { return new Thickness(OuterMarginSize); }
        }

        /// <summary>
        ///Property that carries the COrner radius of the Window
        /// </summary>
        public int WindowRadiusSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; //When the screen is maximized we dont have to show the corner radius.
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The actual CornerRadius object , which uses <see cref="WindowRadiusSize"/> value and returns the corner radius which can be bound in the xaml
        /// </summary>
        public CornerRadius WindowCornerRadius
        {
            get { return new CornerRadius(WindowRadiusSize); }
        }

        /// <summary>
        /// The height of the title bar or caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength
        {
            get { return new GridLength(TitleHeight + ResizeBorder); }
        }

        #endregion

        #region Constructor

        public WindowViewModel(MainWindow window)
        {
            mWindow = window;

            //Listen out for window resizing
            mWindow.StateChanged += (sender, e) => 
            {
                //Fire off all the properties that are affected by resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadiusSize));
                OnPropertyChanged(nameof(WindowCornerRadius));

            };


            //Instantiate commands

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());

            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
        }

        #region Helpers

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);//This returns the mouse coordinates clicked at a distance from the topleft tip of the window.

            //we add the windows position fom the topleft edge of the screen to get the exact position.
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
            
        }

        #endregion

        #endregion
    }
}
