
using System;
using System.Windows;
using System.Windows.Controls;

namespace FasettoWord
{

    /// <summary>
    /// Base attached property approach made defining the attached properties in the application simple in one line ,otherwise we have to register,setter and getters for every attached properties that we create
    /// This attached peopert IsBusyProperty tells you if your control is already executing ,so you can show busy indicator
    /// </summary>
    public class IsBusyProperty : BaseAttachedProperty<IsBusyProperty, bool>
    {

    }




}
