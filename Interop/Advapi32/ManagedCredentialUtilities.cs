using FixSeaOfThievesLavenderBeard.Interop.Advapi32.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FixSeaOfThievesLavenderBeard.Interop.Advapi32
{
    public class ManagedCredentialUtilities
    {
        public static List<ManagedCredential> GetCredentialByFilter(string filter)
        {
            List<ManagedCredential> credentials = new();

            if (CredentialManagementApi.CredEnumerate(filter, 0, out int count, out nint pCredentials) && pCredentials != nint.Zero)
            {
                nint[] credentialPtrs = new nint[count];
                for (int i = 0; i < count; i++)
                {
                    credentialPtrs[i] = Marshal.ReadIntPtr(pCredentials, i * nint.Size);
                }

                for (int i = 0; i < count; i++)
                {
                    Credential credential = Marshal.PtrToStructure<Credential>(credentialPtrs[i]);
                    credentials.Add(new ManagedCredential
                    {
                        TargetName = Marshal.PtrToStringUni(credential.targetName),
                        Comment = Marshal.PtrToStringUni(credential.comment),
                        Type = (ManagedCredential.CredentialType)credential.type
                    });
                }

                CredentialManagementApi.CredFree(pCredentials);
            }
            else
            {
                InteropUtilities.HandleError();
            }

            return credentials;
        }

        public static List<ManagedCredential> GetCredentialByPrefixFilter(string prefixFilter)
        {
            return GetCredentialByFilter($"{prefixFilter}*");
        }

        public static bool DeleteCredential(string credentialName)
        {
            if (CredentialManagementApi.CredDelete(credentialName, 1, 0))
            {
                return true;
            } 
            else
            {
                InteropUtilities.HandleError(); 
                return false;
            }
        }

        public static void FindAndDeleteCredentialsByPrefix(string prefixFilter)
        {
            var creds = GetCredentialByPrefixFilter(prefixFilter);

            if (creds.Count == 0 || creds.First() == null)
            {
                Console.WriteLine("No credentials found!");
            }
            foreach (var credential in creds)
            {
                Console.WriteLine($"{credential} | {credential.Type} ({(uint)credential.Type})");
            }

            Console.WriteLine("Delete all of the above credentials found?\n Put Y and hit enter to confirm.");

            var response = Console.ReadLine();
            if (response == "Y")
            {
                foreach (var credential in creds)
                {
                    Console.WriteLine("Deleting: " + credential.ToString());
                    ManagedCredentialUtilities.DeleteCredential(credential.TargetName);
                }
            }
            else
            {
                Console.WriteLine("Terminating. No credentials were deleted.");
            }
        }
    }
}
