using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FixSeaOfThievesLavenderBeard.Interop
{
    internal class InteropUtilities
    {
        static public void HandleError()
        {
            int errorCode = Marshal.GetLastPInvokeError();
            string errorMessage = Marshal.GetLastPInvokeErrorMessage();
            Console.WriteLine($"Failure during Interop P/Invoke. Error code: {errorCode} - {errorMessage}");

            errorCode = Marshal.GetLastWin32Error();
            errorMessage = new System.ComponentModel.Win32Exception(errorCode).Message;
            Console.WriteLine($"Failure during Interop Win32Exception. Error code: {errorCode} - {errorMessage}");
        }
    }
}
