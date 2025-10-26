using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;

class Resources
{
    const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
    static readonly IntPtr RT_RCDATA = new IntPtr(10);

    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

    [DllImport("kernel32", SetLastError = true)]
    static extern bool FreeLibrary(IntPtr hModule);

    [DllImport("kernel32", SetLastError = true)]
    static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);

    [DllImport("kernel32", SetLastError = true)]
    static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

    [DllImport("kernel32", SetLastError = true)]
    static extern IntPtr LockResource(IntPtr hResData);

    [DllImport("kernel32", SetLastError = true)]
    static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);

     [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern IntPtr BeginUpdateResource(string pFileName, bool bDeleteExistingResources);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool UpdateResource(IntPtr hUpdate, IntPtr lpType, IntPtr lpName, ushort wLanguage, byte[] lpData, uint cbData);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

    public static string DumpRcData(string dllPath, int resourceId)
    {
        try
        {
            var hModule = LoadLibraryEx(dllPath, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
            if (hModule == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());

            IntPtr hResInfo = FindResource(hModule, new IntPtr(resourceId), RT_RCDATA);
            if (hResInfo == IntPtr.Zero)
                throw new Exception($"Resource ID {resourceId} not found.");

            IntPtr hResData = LoadResource(hModule, hResInfo);
            IntPtr pData = LockResource(hResData);
            uint size = SizeofResource(hModule, hResInfo);

            if (size == 0)
                throw new Exception("Resource has zero size.");

            byte[] buffer = new byte[size];
            Marshal.Copy(pData, buffer, 0, (int)size);

            string outFile = $"RCDATA_{resourceId}.bin";
            File.WriteAllBytes(outFile, buffer);

            FreeLibrary(hModule);
        }
        
        catch (Exception e)
        {
            return e.ToString();
        }

        return null;
    }

    public static string DecompressFirmware()
    {
        byte[] res = File.ReadAllBytes("RCDATA_3070.bin");

        byte[] HEADER = new byte[10];
        Array.Copy(BitConverter.GetBytes(0x00088B1F), 0, HEADER, 0, 4);
        Array.Copy(BitConverter.GetBytes(0), 0, HEADER, 4, 4);
        Array.Copy(BitConverter.GetBytes((ushort)4), 0, HEADER, 8, 2);

        const int FIRST_CHUNK = 0x2FF6;
        const int MARKER_OFFSET = 0x3000;
        const int MARKER_POS_AFTER = 0x3001;

        int bufLength = MARKER_POS_AFTER + Math.Max(0, res.Length - FIRST_CHUNK);
        byte[] buf = new byte[bufLength];

        Array.Copy(HEADER, 0, buf, 0, HEADER.Length);

        int firstChunkLength = Math.Min(FIRST_CHUNK, res.Length);
        Array.Copy(res, 0, buf, HEADER.Length, firstChunkLength);

        if (res.Length > FIRST_CHUNK)
        {
            buf[MARKER_OFFSET] = 0xEF;
            Array.Copy(res, FIRST_CHUNK, buf, MARKER_POS_AFTER, res.Length - FIRST_CHUNK);
        }

        try
        {
            using (var ms = new MemoryStream(buf))
            using (var gzipStream = new GZipStream(ms, CompressionMode.Decompress))
            using (var outFile = new FileStream("decompressed.bin", FileMode.Create, FileAccess.Write))
            {
                gzipStream.CopyTo(outFile);
            }
        }
        catch (Exception e)
        {
            return e.ToString();
        }

        return null;
    }

    public static string RecompressFirmware()
    {
        try
        {
            const int FIRST_CHUNK = 0x2FF6;
            const int MARKER_OFFSET = 0x3000;
            const int MARKER_POS_AFTER = 0x3001;
            const int MARKER_BYTE = 0xEF;

            byte[] data = File.ReadAllBytes("decompressed.bin");

            byte[] gz;
            using (var ms = new MemoryStream())
            {
                using (var gzStream = new GZipStream(ms, CompressionLevel.Optimal, true))
                    gzStream.Write(data, 0, data.Length);
                gz = ms.ToArray();
            }

            if (gz.Length > MARKER_OFFSET)
                gz[MARKER_OFFSET] = MARKER_BYTE;

            int aLen = Math.Max(0, Math.Min(FIRST_CHUNK, gz.Length - 10));
            byte[] a = new byte[aLen];
            if (aLen > 0)
                Buffer.BlockCopy(gz, 10, a, 0, aLen);

            byte[] rest = Array.Empty<byte>();
            if (gz.Length > MARKER_POS_AFTER)
            {
                int restLen = gz.Length - MARKER_POS_AFTER;
                rest = new byte[restLen];
                Buffer.BlockCopy(gz, MARKER_POS_AFTER, rest, 0, restLen);
            }

            using (var fs = File.Create("recompressed.bin"))
            {
                fs.Write(a, 0, a.Length);
                fs.Write(rest, 0, rest.Length);
            }
        }

        catch (Exception e)
        {
            return e.ToString();
        }

        return null;
    }

    public static string ReplaceRcData()
    {
        File.Copy("OSupdateDLL_original.dll", "OSupdateDLL_modified.dll", true);
        byte[] newData = File.ReadAllBytes("recompressed.bin");

        IntPtr hUpdate = BeginUpdateResource("OSupdateDLL_modified.dll", false);

        bool ok = UpdateResource(
             hUpdate,
             RT_RCDATA,
             new IntPtr(3070),
             1033,
             newData,
             (uint)newData.Length);


        EndUpdateResource(hUpdate, false);
        return null;
    }

    public static string ModifyFirmware(byte[] bytes, long startOffset)
    {
        try
        {
            using (var fs = new FileStream("decompressed.bin", FileMode.Open, FileAccess.Write))
            {
                fs.Seek(startOffset, SeekOrigin.Begin);
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
            }
        }

        catch (Exception e) 
        {
            return e.ToString();
        }

        return null;
    }
}
