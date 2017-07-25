using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdvancedSystemManager
{
    public class DiskCleanUp
    {

        public DiskCleanUp()
        {

        }

        public static void FindFiles(String path,String filter)
        {
            try
            {
                //Directory.EnumerateFiles is not available in .NET 2.0
                string[] files = Directory.GetFiles(path, filter);
                //string[] files = Directory.GetFiles(@"C:\Windows", "*.dmp");

                foreach (string file in files)
                {
                    Console.WriteLine(file);
                    //DeleteFile(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static void DeleteFile(String filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        //firefox & chrome profile delete!


    }

}

