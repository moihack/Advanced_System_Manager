using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace AdvancedSystemManager
{
    public class DiskCleanUp
    {

        public DiskCleanUp()
        {

        }

        public static void FindFiles(String path, String filter)
        {
            string newPath = "";

            try
            {
                string[] paths = path.Split('|');
                string[] filters = filter.Split('|');

                for (int i = 0; i < paths.Length; i++)
                {
                    path = Environment.ExpandEnvironmentVariables(paths[i]);
                    
                    //MyLogger.WriteLog("path is : " + path);
                    if (path.StartsWith(@"?:\"))
                    {
                        foreach (DriveInfo x in DriveInfo.GetDrives())
                        {
                            if (x.DriveType.ToString().Equals("Fixed"))
                            {
                                newPath = path;
                                newPath = newPath.Replace(@"?:\", x.Name);
                            }
                        }
                        paths[i] = newPath;
                    }
                    MyLogger.WriteLog("path is : " + paths[i]);
                    for (int y = 0; y < filters.Length; y++)
                    {
                        //Directory.EnumerateFiles is not available in .NET 2.0
                        string[] files = Directory.GetFiles(paths[i], filters[y]);

                        //examples
                        //string[] files = Directory.GetFiles(@"C:\Windows", "*.dmp");
                        //string[] files = Directory.GetFiles(@"?:\msdownld.tmp", "*.tmp");

                        foreach (string file in files)
                        {
                            //MyLogger.WriteLog(file);
                            DeleteFile(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured while searching for files to delete");
                MyLogger.WriteErrorLog(ex.Message);
            }
        }

        public static void FindDirs(String path)
        {
            try
            {
                string[] paths = path.Split(';');

                for (int i = 0; i < paths.Length; i++)
                {
                    foreach (DriveInfo x in DriveInfo.GetDrives())
                    {
                        if (x.DriveType.ToString().Equals("Fixed"))
                        {
                            //MyLogger.WriteLog(x.Name + paths[i]);
                            DeleteDir(x.Name + paths[i]);
                        }
                    }
                }
                //MyLogger.WriteLog("path is : " + paths[i]);
            }

            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured while searching for directories to delete");
                MyLogger.WriteErrorLog(ex.Message);
            }
        }

        public static void DeleteFile(String filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured while deleting file: " + filePath);
                MyLogger.WriteErrorLog(ex.Message);
            }
        }

        public static void DeleteDir(String dirPath)
        {
            try
            {
                Directory.Delete(dirPath, true);
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured while deleting file: " + dirPath);
                MyLogger.WriteErrorLog(ex.Message);
            }
        }

        //firefox & chrome profile delete!

        public static void ChromeCleanup()
        {
            Process[] procar = Process.GetProcessesByName("chrome");
            foreach (Process proc in procar)
            {
                proc.Kill();
            }

            // C:\Users\<username>\AppData\Local\Google\Chrome\User Data\Default

            string topPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default";

            try
            {
                Directory.Delete(topPath, true);
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured while deleting Chrome Profile");
                MyLogger.WriteErrorLog(ex.Message);
            }
        }

        public static void FirefoxCleanup()
        {
            Process[] procar = Process.GetProcessesByName("firefox");
            foreach (Process proc in procar)
            {
                proc.Kill();
            }

            //wait for firefox to exit properly and unallocate all resources

            System.Threading.Thread.Sleep(5000);

            // %APPDATA%\Mozilla\Firefox\Profiles\

            string topPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mozilla\Firefox";

            try
            {
                Directory.Delete(topPath + @"\Profiles", true);
                DeleteFile(topPath + @"\profiles.ini");
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured while deleting Firefox Profile");
                MyLogger.WriteErrorLog(ex.Message);
            }
        }
    }
}