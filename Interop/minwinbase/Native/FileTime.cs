using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct FileTime
{
    public uint dwLowDateTime;
    public uint dwHighDateTime;
}