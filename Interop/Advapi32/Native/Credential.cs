using System.Runtime.InteropServices;

namespace FixSeaOfThievesLavenderBeard.Interop.Advapi32.Native
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct Credential
    {
        public uint flags;
        public uint type;
        public IntPtr targetName;
        public IntPtr comment;
        public FileTime lastWritten;
        public uint credentialBlobSize;
        public IntPtr credentialBlob;
        public uint persist;
        public uint attributeCount;
        public IntPtr attributes;
        public IntPtr targetAlias;
        public IntPtr userName;
    }
}
