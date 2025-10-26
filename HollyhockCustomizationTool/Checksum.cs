using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

class Checksum
{
    public static bool Verify(string filePath, string hashString)
    {
        try
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] fileHash = md5.ComputeHash(stream);
                    string fileHashHex = BitConverter.ToString(fileHash).Replace("-", "").ToLower();

                    if (stream == null)
                    {
                        return false;
                    }

                    else if (fileHashHex == hashString.ToLower())
                    {
                        return true;
                    }
                }
            }
        }
        
        catch
        {
            //nothing, lol
        }
        return false;
    }
}