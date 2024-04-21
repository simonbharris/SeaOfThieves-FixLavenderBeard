using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixSeaOfThievesLavenderBeard.Interop.Advapi32
{
    public class ManagedCredential
    {
        string? targetName = null;

        [NotNull]
        public string? TargetName
        {
            get
            {
                ArgumentNullException.ThrowIfNull(targetName);
                return targetName;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                targetName = value;
            }
        }
        public string? Comment { get; set; }
        public CredentialType Type { get; set; }

        public enum CredentialType : uint
        {
            Generic = 1,
            DomainPassword = 2,
            DomainCertificate = 3,
            DomainVisiblePassword = 4, // No longer supported
            GenericCertificate = 5,
            DomainExtended = 6,
            MaxSupportedTypes = 7
        }

        public override string ToString()
        {
            if (TargetName == null)
                return "(null)";
            return TargetName;
        }
    }
}
