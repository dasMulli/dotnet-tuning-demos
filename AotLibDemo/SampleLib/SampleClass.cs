using System.Runtime.InteropServices;

namespace SampleLib;
public static class SampleClass
{
    [UnmanagedCallersOnly(EntryPoint = "greeting")]
    public static IntPtr Greeting(IntPtr name)
    {
        var nameString = Marshal.PtrToStringAnsi(name);
        var greeting = $"Hello {nameString}!";
        return Marshal.StringToHGlobalAnsi(greeting);
    }
}
