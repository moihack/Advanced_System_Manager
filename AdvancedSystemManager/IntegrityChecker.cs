using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace AdvancedSystemManager
{
    //a class for checking the integrity of files via MD5 & SHA-1 algorithms 
    //Windows do not provide a way to do this via built-in tools
    public static class IntegrityChecker
    {
        public static String MD5Check(String filename)
        {
            String checksum = "";

            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    checksum = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
            return checksum;
        }
        public static String SHA1Check(String filename)
        {
            String checksum = "";

            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    checksum = BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
            return checksum;
        }
    }
}
