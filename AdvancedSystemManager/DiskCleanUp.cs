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

        /* public static void FindFiles(String path,String filter)
         {
             try
             {
                 //Directory.EnumerateFiles is not available in .NET 2.0
                 path = Environment.ExpandEnvironmentVariables(path);
                 Console.WriteLine(path);
                 string[] files = Directory.GetFiles(path, filter);
                 //string[] files = Directory.GetFiles(@"C:\Windows", "*.dmp");
                 //string[] files = Directory.GetFiles(@"?:\msdownld.tmp", "*.tmp");
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
         } */

        public static void FindFiles(String path, String filter)
        {
            string newPath = "";
            //string newFilter = "";
            try
            {
                string[] paths = path.Split('|');
                string[] filters = filter.Split('|');

                for (int i = 0; i < paths.Length; i++)
                {
                    path = Environment.ExpandEnvironmentVariables(paths[i]);
                    //Console.WriteLine(path);
                    //MyLogger.WriteErrorLog("path is : " + path);
                    if (path.StartsWith(@"?:\"))
                    {
                        //Console.WriteLine("we enter here");
                        foreach (DriveInfo x in DriveInfo.GetDrives())
                        {
                            // Console.WriteLine(x.DriveType);
                            // Console.WriteLine(x.Name);
                            if (x.DriveType.ToString().Equals("Fixed"))
                            {
                                //Console.WriteLine("we are fixed");
                                newPath = path;
                                newPath = newPath.Replace(@"?:\", x.Name);

                                //Console.WriteLine(newPath);
                            }
                        }
                        paths[i] = newPath;
                    }
                    MyLogger.WriteErrorLog("path is : " + paths[i]);
                    for (int y = 0; y < filters.Length; y++)
                    {
                        //Console.WriteLine(filters[y]);
                        //Directory.EnumerateFiles is not available in .NET 2.0
                        string[] files = Directory.GetFiles(paths[i], filters[y]);
                        //string[] files = Directory.GetFiles(@"C:\Windows", "*.dmp");
                        //string[] files = Directory.GetFiles(@"?:\msdownld.tmp", "*.tmp");
                        foreach (string file in files)
                        {
                            //Console.WriteLine(file);
                            MyLogger.WriteErrorLog(file);
                            DeleteFile(file);
                        }
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static void FindDirs(String path)
        {
            //Console.WriteLine(path);
            //string newPath = "";
            //string newFilter = "";
            try
            {
                string[] paths = path.Split(';');

                for (int i = 0; i < paths.Length; i++)
                {
                    //path = Environment.ExpandEnvironmentVariables(paths[i]);

                    //Console.WriteLine("we enter here");
                    foreach (DriveInfo x in DriveInfo.GetDrives())
                    {
                        // Console.WriteLine(x.DriveType);
                        // Console.WriteLine(x.Name);
                        if (x.DriveType.ToString().Equals("Fixed"))
                        {
                            //Console.WriteLine("we are fixed");
                            // newPath = path;
                            // newPath = newPath.Replace(@"?:\", x.Name);

                            // Console.WriteLine(x.Name); //C:\ output
                            Console.WriteLine(x.Name + paths[i]);
                            DeleteDir(x.Name + paths[i]);
                        }
                    }
            //        paths[i] = newPath;
                }
                //MyLogger.WriteErrorLog("path is : " + paths[i]);
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

        public static void DeleteDir(String filePath)
        {
            try
            {
                Directory.Delete(filePath,true);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
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
            Console.WriteLine(topPath);
            try
            {
                Directory.Delete(topPath, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.Message);
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
            Console.WriteLine(topPath);
            try
            {
                Directory.Delete(topPath + @"\Profiles", true);
                DeleteFile(topPath + @"\profiles.ini");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.Message);
            }
        }

        public static void CleanMgr()
        {
            //cleanmgr /sagerun:555
            string output = "";
            string args = "";
            Process myProcess = new Process();
            try
            {
                args = " /sagerun:555";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cleanmgr.exe";
                myProcess.StartInfo.Arguments = args;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                MyLogger.WriteLog(myProcess.StartInfo.Arguments);
                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                    output = line;
                }
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                MyLogger.WriteLog(e.Message + " Error on executing: " + args);
            }
        }

    }

}

