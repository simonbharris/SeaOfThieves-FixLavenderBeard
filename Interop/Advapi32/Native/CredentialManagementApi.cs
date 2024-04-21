using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FixSeaOfThievesLavenderBeard.Interop.Advapi32.Native
{
    internal class CredentialManagementApi
    {
        [DllImport("Advapi32.dll", EntryPoint = "CredEnumerateW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool CredEnumerate(string filter, int flags, out int count, out nint credentials);

        [DllImport("Advapi32.dll", EntryPoint = "CredDeleteW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool CredDelete(string target, int type, int flags);

        [DllImport("Advapi32.dll", EntryPoint = "CredFree", SetLastError = true)]
        public static extern void CredFree(nint buffer);
    }
}
