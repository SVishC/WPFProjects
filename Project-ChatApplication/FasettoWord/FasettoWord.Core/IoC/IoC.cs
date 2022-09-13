using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord.Core
{

    /// <summary>
    /// The Inversion of Control COntainer for our Application
    /// </summary>
    public static class IoC
    {

        #region Public Properties

     

        /// <summary>
        /// The Kernel for our IoC Container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();


        #endregion


        /// <summary>
        /// Gets a service from the IoC Container of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #region Setup Construction

        
        /// <summary>
        /// Sets up the IoC Container.This method binds all the information required and is ready for use
        /// NOTE:Needs to be called as soon as the application starts , so that the information is available any time in the container when the application needs it
        /// </summary>
        public static void Setup()
        {
            //Bind all required view models

            BindViewModels();
            
        }

        /// <summary>
        /// Binds all Singleton View Models
        /// </summary>
        private static void BindViewModels()
        {
            //Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();
            //or

            //This syntax allows to pass anything to application view model in contructor or initialize properties using property initialization syntax
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel()); 
            
        }
        #endregion



    }
}
