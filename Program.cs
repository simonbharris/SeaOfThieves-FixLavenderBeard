using FixSeaOfThievesLavenderBeard.Interop.Advapi32;
using FixSeaOfThievesLavenderBeard.Interop.Advapi32.Native;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

void DeleteSeaOfThievesWindowsCredentials()
{
    Console.WriteLine("Find and Deleting Sea of Thieves related credentials...");
    ManagedCredentialUtilities.FindAndDeleteCredentialsByPrefix("Xbl_Ticket|1717113201");
}

DeleteSeaOfThievesWindowsCredentials();

