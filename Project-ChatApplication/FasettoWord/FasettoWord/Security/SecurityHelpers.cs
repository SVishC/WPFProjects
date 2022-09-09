using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FasettoWord
{

    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecurityHelpers
    {
        /// <summary>
        /// Unsecures / Decrypt the secure string /secure password by using Marshalling and unmanaged code
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {

            //Make sure there is a value for secure string that is passed
            if (secureString == null)
                return string.Empty;

            //Get a pointer for storing decrypted string in memory

            var unmanagedString = IntPtr.Zero;

            try
            {
                //Unsecures the  secure string
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                //return the string value from the pointer
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {

                //cleanup the unmanaged memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);

            }

        }
    }
}
