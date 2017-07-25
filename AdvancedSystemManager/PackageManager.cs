using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    class PackageManager
    {
        public static List<Package> installedProgramsList = new List<Package>();
        public static Boolean doUnattendedInstall = false;
        public static void DuplicatesFinder()
        {
            //Console.Out.Flush();
            //MyLogger.WriteLog("go::");
            /*foreach (Package p in installedProgramsList)
            {
                //MyLogger.WriteLog(p.PackageName);
                foreach (Package pa in installedProgramsList)
                {
                    //MyLogger.WriteLog(p.PackageName);
                    if (p.PackageName.Equals(pa.PackageName) || pa.PackageName.Equals("noDisplayName"))
                    {
                        installedProgramsList.Remove(pa);
                    }
                }
            }

            foreach (Package p in installedProgramsList)
            {
                //MyLogger.WriteLog(p.PackageName);
            }
            */

            MyLogger.WriteLog("h lista einai " + installedProgramsList.Count);
            for (int i = 0; i <= installedProgramsList.Count - 1; i++)
            {
                //MyLogger.WriteLog("mpainw" + i);
                for (int j = installedProgramsList.Count - 1; j >= 0; j--)
                {
                    //MyLogger.WriteLog("test"); 
                    //MyLogger.WriteLog("mpainw" + i + " to j omws einai" + j);
                    //MyLogger.WriteLog(installedProgramsList[j].PackageName);
                    //if (installedProgramsList[j].PackageName.Equals("noDisplayName"))
                    if (installedProgramsList[i].PackageName.Equals(installedProgramsList[j].PackageName) || installedProgramsList[j].PackageName.Equals("noDisplayName"))
                    {
                        if (i != j)
                        {
                            //MyLogger.WriteLog("mpainw sto if " + i + " " + j);
                            installedProgramsList.RemoveAt(j);
                        }
                    }
                }
            }
            MyLogger.WriteLog("h lista2 einai " + installedProgramsList.Count);
            foreach (Package p in installedProgramsList)
            {
                //MyLogger.WriteLog(p.PackageName);
            }
        }

        public static void ShowNormal()
        {
            //foreach (Package p in installedProgramsList)
            for (int i = installedProgramsList.Count - 1; i >= 0; i--)
            {
                //need to do the OR part with regex? 
                if (installedProgramsList[i].IsSystemComponent || installedProgramsList[i].PackageName.Contains("KB"))
                {
                    //MyLogger.WriteLog(p.PackageName);
                    installedProgramsList.RemoveAt(i);
                }
            }

            PackageComparer comp = new PackageComparer();
            installedProgramsList.Sort(comp);

            //maybe we can do this without iterating the list again
            for (int i = installedProgramsList.Count - 1; i >= 0; i--)
            {
                //MyLogger.WriteLog(installedProgramsList[i].PackageName);
                installedProgramsList[i].isSafeToRemove = PackageSafeToRemove(installedProgramsList[i].PackageName);
            }
        }

        public static Boolean PackageSafeToRemove(String pack)
        {
            bool retVal = false;

            if (pack.Contains("NVIDIA"))
            {
                //  return true;
            }

            //we need to regex this!
            if ((pack.Contains("Trial")) || (pack.Contains("trial")) || (pack.Contains("TRIAL")))
            {
                // return true;
            }

            //antivirus - we want to have only one antivirus! if detect there is one all else should returne true (a static global variable?)
            //toolbar
            //search
            //free
            //download
            //tune-up/tuneup/tune up
            //cleaner

            //list of bad programs in .txt??? (daemon-tools,utube downloader etc)

            return retVal;
        }

        public static void MSI_Install(String filePath)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "MsiExec.exe";
                myProcess.StartInfo.Arguments = " /I " + '"' + filePath + '"' + " /qn "; // /li+ C:\\install.log";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                //MyLogger.WriteLog(myProcess.StartInfo.Arguments);
                myProcess.Start();

                /*while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);                    
                } */
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void MSI_Uninstall(String productCode)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "MsiExec.exe";
                myProcess.StartInfo.Arguments = "/X " + productCode + " /qn /li+ C:\\uninstall.log";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                /*while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);                    
                } */
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void EXE_Install(String inEXEpath)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = inEXEpath;
                myProcess.StartInfo.Arguments = " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-"; //arg may be /S , /SILENT and other??
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void EXE_Uninstall(String uniEXEpath, String arg)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = uniEXEpath;
                myProcess.StartInfo.Arguments = arg; //arg may be /S , /SILENT and other??
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void UninstallTest()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "MsiExec.exe /X{23170F69-40C1-2702-1604-000001000000} /q";
            //startInfo.Verb = "runas";

            //process.StartInfo.RedirectStandardError = true;
            // process.StartInfo.RedirectStandardOutput = true;

            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardError = true;

            startInfo.FileName = "MsiExec.exe";
            startInfo.Arguments = "/X{23170F69-40C1-2702-1604-000001000000} /q";
            process.StartInfo = startInfo;
            process.Start();

            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }


        }

        public static void InstallTest()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "MsiExec.exe /i \"D:\\7z1604-x64.msi\" /q";
            //startInfo.Verb = "runas";

            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardError = true;

            startInfo.FileName = "MsiExec.exe";
            startInfo.Arguments = "/i \"D:\\7z1604-x64.msi\" /q";

            process.StartInfo = startInfo;
            process.Start();

            /* while (!process.StandardOutput.EndOfStream)
             {
                 string line = process.StandardOutput.ReadLine();
                 Console.WriteLine(line);
             } */

        }

        public static void InstallTestQ()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "MsiExec.exe /i \"D:\\7z1604-x64.msi\" /q";
            //startInfo.Verb = "runas";

            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardError = true;

            startInfo.FileName = "D:\\qbittorrent_3.3.12_x64_setup.exe";
            startInfo.Arguments = "/S";

            process.StartInfo = startInfo;
            process.Start();

            /* while (!process.StandardOutput.EndOfStream)
             {
                 string line = process.StandardOutput.ReadLine();
                 Console.WriteLine(line);
             } */

        }

        public static void NeoUni()
        {
            Process myProcess = new Process();
            //string cmd = "";

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "MsiExec.exe";
                myProcess.StartInfo.Arguments = "/X{23170F69-40C1-2702-1604-000001000000} /qn /li+ C:\\package.log ";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                /*while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);                    
                } */
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void NeoUniQbit()
        {
            Process myProcess = new Process();
            //string cmd = "";

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = @"C:\Program Files\qBittorrent\uninst.exe";
                myProcess.StartInfo.Arguments = "/S";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Uninstall(String fn)
        {
            //fn = @"C:\Program Files\qBittorrent\uninst.exe";
            Console.WriteLine(" fn is : " + fn);
            Process myProcess = new Process();
            //string cmd = "";
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = fn;
                myProcess.StartInfo.Arguments = "";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                MyLogger.WriteLog(e.Message + " Error on: " + myProcess.StartInfo.FileName);
            }
        }

        public static void UninstallNoArgs(String args)
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + args;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                MyLogger.WriteLog(myProcess.StartInfo.Arguments);
                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                MyLogger.WriteLog(e.Message + " Error on executing: " + args);
            }
        }

        public static void removeMPC()
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = @"C:\Program Files\MPC-HC\unins000.exe";
                myProcess.StartInfo.Arguments = "/SILENT";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                //myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                MyLogger.WriteLog(e.Message + " Error on executing: " + "MPC UNINSTALL TEST");
            }
        }

        public static void CheckUninstallationMethod(Package pack)
        {
            if (pack.QuietUninstallString.Contains("noQuiet"))
            {
                String uniString = pack.UninstallString;

                //if UninstallString really exists
                if (!uniString.Contains("noUnString"))
                {
                    if (uniString.StartsWith("MsiExec.exe "))
                    {
                        //replace /* no matter what, with /X + append /qn
                        uniString = uniString.Remove(0, 14);
                        uniString = "MsiExec.exe /X" + uniString + " /qn";

                        //Console.WriteLine(uniString);
                        //call silent uninstall at hidden cmd window with args h oxi? gt to msiexec dn einai param = uniString
                        //mhpws glutwnw mia enwsh? // dn aksizei trela gt 8elw xwristh me8odo na pernaw ta args sto msiexec meta
                        PackageManager.UninstallNoArgs(uniString);
                    }
                    else
                    { /*
                        if (uniString.EndsWith("/S") || uniString.EndsWith("/Silent") || uniString.EndsWith("/SILENT"))
                        {
                            //just execute the silent uninstall
                            // Console.WriteLine(uniString);
                            //maybe this one never happens!!!
                            PackageManager.UninstallNoArgs(uniString);
                        }
                        else
                        {
                            //Console.WriteLine(pack.PackageName + "\n" + uniString);
                            //just append a /S and hope everything goes well
                            if (uniString.EndsWith("\"")) //praktika k dw den me noiazei an teleiwnei me " - see example.jpg
                            {
                                //Console.WriteLine(uniString);
                                uniString = uniString + " /S";
                                //Console.WriteLine(uniString);
                                PackageManager.UninstallNoArgs(uniString);
                            }
                            else
                            {
                                uniString = uniString + " /S";
                                PackageManager.UninstallNoArgs(uniString);
                            }
                        } */

                        uniString = '"' + uniString + '"' + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                        PackageManager.UninstallNoArgs(uniString);

                    }

                }
            }
            else
            {
                // to GIMP exei silent uninstall string k otan to treksa fanhke!
                //8a kanw append se auta pou den exoun msiexec mesa ta klassika kolpa
                //MyLogger.WriteLog(pack.QuietUninstallString);
                //just execute the quiet uninstall string at a hidden cmd window
                /*if (pack.QuietUninstallString.Contains("ImageWriter"))
                {
                    PackageManager.UninstallNoArgs(pack.QuietUninstallString);
                } */
                String uniString = pack.QuietUninstallString;
                if (uniString.StartsWith("MsiExec.exe "))
                {
                    PackageManager.UninstallNoArgs(uniString);
                }
                else
                {
                    uniString = uniString + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                    PackageManager.UninstallNoArgs(uniString);
                }

            }
        }

        public static void UnattendedInstall()
        {
            //(Application.StartupPath + "\\log.txt", true)
            if (Directory.Exists(Application.StartupPath + @"\apps_deploy"))
            {
                Console.WriteLine("exists!");

                try
                {
                    //Directory.EnumerateFiles is not available in .NET 2.0
                    string[] files = Directory.GetFiles(Application.StartupPath + @"\apps_deploy");
                    //string[] files = Directory.GetFiles(@"C:\Windows", "*.dmp");

                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                        if(file.EndsWith(".exe"))
                        {
                            PackageManager.EXE_Install(file);
                        }
                        if(file.EndsWith(".msi"))
                        {
                            PackageManager.MSI_Install(file);
                        }
                        else
                        {
                            //pass
                        }
                        //DeleteFile(file);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }

            }
            else
            {
                Console.WriteLine("not exists!");
            }
        }

    }

}

