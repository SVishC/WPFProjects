using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord
{

    /// <summary>
    /// An interface for the class that can provide a secure Password
    /// </summary>
    public interface IHavePassword
    {

        /// <summary>
        /// The securePassword
        /// </summary>
        SecureString MySecurePassword { get; }
    }
}
