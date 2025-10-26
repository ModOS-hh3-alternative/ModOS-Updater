using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

class OSUpdater
{
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr LoadLibrary(string dllToLoad);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool FreeLibrary(IntPtr hModule);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void OSUpdateDelegate(int hwnd_param1, int param2, string lpcwstr_param3);

    public static string InitOSUpdate()
    {
        try
        {
            string path = Directory.GetCurrentDirectory();

            StringBuilder buffer = new StringBuilder(1024);
            buffer.Append(path);

            IntPtr hModule = LoadLibrary("OSupdateDLL_original.dll");
            IntPtr procAddress = GetProcAddress(hModule, "OSUpdate");

            OSUpdateDelegate OSUpdate = (OSUpdateDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(OSUpdateDelegate));

            OSUpdate(0, 0, path);
        }
        
        catch (Exception e)
        {
            return e.ToString();
        }

        return null;
    }

    public static string InitModifiedOSUpdate()
    {
        try
        {
            string path = Directory.GetCurrentDirectory();

            StringBuilder buffer = new StringBuilder(1024);
            buffer.Append(path);

            IntPtr hModule = LoadLibrary("OSupdateDLL_modified.dll");
            IntPtr procAddress = GetProcAddress(hModule, "OSUpdate");

            OSUpdateDelegate OSUpdate = (OSUpdateDelegate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(OSUpdateDelegate));

            OSUpdate(0, 0, path);
        }

        catch (Exception e)
        {
            return e.ToString();
        }

        return null;
    }
}