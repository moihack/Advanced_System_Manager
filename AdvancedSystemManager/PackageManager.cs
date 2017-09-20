using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AdvancedSystemManager
{
    class PackageManager
    {
        public static List<Package> installedProgramsList = new List<Package>();
        public static List<StartupItem> startupProgramsList = new List<StartupItem>();

        public static Boolean doUnattendedInstall = false;
        public static Boolean hasAntiVirus = false;

        public static void RemoveSystemComponents()
        {
            for (int i = installedProgramsList.Count - 1; i >= 0; i--)
            {
                if (installedProgramsList[i].IsSystemComponent || installedProgramsList[i].PackageName.Equals("noDisplayName"))
                {
                    installedProgramsList.RemoveAt(i);
                }
            }
        }

        public static void RemoveUpdates()
        {
            for (int i = installedProgramsList.Count - 1; i >= 0; i--)
            {
                if (installedProgramsList[i].PackageName.Contains("KB"))
                {
                    installedProgramsList.RemoveAt(i);
                }
            }
        }

        public static void MarkPackages()
        {
            for (int i = 0; i < installedProgramsList.Count; i++)
            {
                installedProgramsList[i].isSafeToRemove = PackageSafeToRemove(installedProgramsList[i].PackageName);
                //MyLogger.WriteLog(installedProgramsList[i].PackageName);
            }
        }

        public static void SortPackages()
        {
            PackageComparer comp = new PackageComparer();
            installedProgramsList.Sort(comp);
        }

        public static Boolean PackageSafeToRemove(String pack)
        {
            bool retVal = false;

            // string pat = @"\b(visual|open)\b";

            //virus gets antivirus, anti-virus, anti virus etc
            string pat = @"(virus|trial|free|toolbar|search|download|tune|clean)";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(pack);

            if (m.Success)
            {
                //MyLogger.WriteLog(m.Value);
                if (!hasAntiVirus)
                {
                    if (m.Value.ToLower().Contains("virus"))
                    {
                        // keeep the first antivirus we found - mark all others
                        hasAntiVirus = true;
                        return false;
                    }
                }
                return true;
            }
            return retVal;
        }

        public static void MarkFromText()
        {
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\remove.list");

            while ((line = file.ReadLine()) != null)
            {
                //if line is not a comment - comments start with # as noted in remove.list
                if (!line.StartsWith("#"))
                {
                    foreach (Package pack in installedProgramsList)
                    {
                        if (pack.PackageName.Contains(line))
                        {
                            //MyLogger.WriteLog(line);
                            pack.isSafeToRemove = true;
                            pack.ToRemove = true;
                        }
                    }
                }
            }

            file.Close();
        }

        public static void GetAllProgramsList()
        {
            if (SystemInfo.is64BitOS)
            {
                RegistryParser.GetWin64Programs();
            }

            RegistryParser.GetPrograms();

            RegistryParser.GetCurrentUserPrograms();

            PackageManager.RemoveSystemComponents();
            PackageManager.RemoveUpdates();
            PackageManager.SortPackages();
            PackageManager.MarkPackages();
            PackageManager.MarkFromText();
        }

        public static void MSI_Install(String filePath)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "MsiExec.exe";
                myProcess.StartInfo.Arguments = "/I " + '"' + filePath + '"' + " /qn "; // /li+ C:\\install.log";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.Start();
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Error installing : " + filePath + " via Windows Installer");
                MyLogger.WriteErrorLog(ex.Message);

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
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Error uninstalling : " + productCode + " via Windows Installer");
                MyLogger.WriteErrorLog(ex.Message);
            }
        }

        public static void EXE_Install(String inEXEpath)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = inEXEpath;
                myProcess.StartInfo.Arguments = "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-"; //arg may be /S , /SILENT and other??
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;

                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();

                    // this means the setup file was created using InstallBuilder
                    if (line.Contains("There has been an error."))
                    {
                        myProcess.Close();
                        myProcess.StartInfo.Arguments = "--mode unattended";
                        myProcess.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Error uninstalling : " + inEXEpath);
                MyLogger.WriteErrorLog(ex.Message);
            }
        }

        public static void EXE_Uninstall(String uniEXEpath, String arg)
        {
            Process myProcess = new Process();
            MyLogger.WriteLog("Uninstalling EXE: " + uniEXEpath + " with args: " + arg);

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
                    if (line.Contains("There has been an error."))
                    {
                        myProcess.Close();

                        myProcess.StartInfo.Arguments = "--mode unattended";
                        myProcess.Start();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void UninstallNoArgs(String args)
        {
            MyLogger.WriteLog("UnuninstallNoArguments: " + args);
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + args;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.Start();

                while (!myProcess.StandardOutput.EndOfStream)
                {
                    string line = myProcess.StandardOutput.ReadLine();

                    //we have to deal with InstallBuilder! 
                    //They changed this recently - before it would normally consume any unknown parameters
                    //if the first one was an accepted one

                    if (line.Contains("There has been an error."))
                    {
                        string oldargs = " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                        args = args.TrimEnd(oldargs.ToCharArray());
                        args = args + " --mode unattended --unattendedmodeui none";
                        //MyLogger.WriteLog(args);

                        UninstallNoArgs(args);
                    }
                }
            }
            catch (Exception e)
            {
                MyLogger.WriteLog(e.Message + " Error on executing: " + args);
                MyLogger.WriteErrorLog(e.Message + " Error on executing: " + args);
            }
        }

        public static void CheckUninstallationMethod(Package pack)
        {
            //check if package has no silent uninstall string
            if (pack.QuietUninstallString.Contains("noQuiet"))
            {
                String uniString = pack.UninstallString;

                //if UninstallString really exists - sanity check
                if (!uniString.Contains("noUnString"))
                {
                    //MyLogger.WriteLog(uniString);
                    if (uniString.StartsWith("MsiExec.exe "))
                    {
                        //replace /* no matter what, with /X + append /qn
                        uniString = uniString.Remove(0, 14);
                        uniString = "MsiExec.exe /X" + uniString + " /qn";

                        PackageManager.UninstallNoArgs(uniString);
                    }
                    else
                    {
                        //check if uninstall string is within " "
                        if (uniString.StartsWith("\"") && uniString.EndsWith("\""))
                        {
                            if (uniString.EndsWith(".exe\""))
                            {
                                string args = "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                                PackageManager.EXE_Uninstall(uniString, args);
                            }
                            else 
                            // this one probably never happens since a "uninstall_file_path.exe arg1 arg2" type string will result
                            // in cmd trying to find the whole file contained within the quotes
                            // however we leave this here in case it is more something like this "uninstall_file_path.exe" arg1 arg2="some value"
                            {
                                uniString = uniString + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                                PackageManager.UninstallNoArgs(uniString);
                            }
                        }

                        //enquoted exe path only - parameters unquoted
                        if (uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                        {
                            uniString = uniString + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                            PackageManager.UninstallNoArgs(uniString);
                        }

                        //unquoted from here on            
                        if (!uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                        {
                            if (uniString.EndsWith(".exe"))
                            {
                                string args = "\"/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-\"";
                                PackageManager.EXE_Uninstall(uniString, args);
                            }
                            else // we build quotes around the uninstall .exe and concat our custom parameters with the existing ones
                            {
                                string args = " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                                int position = uniString.IndexOf(".exe ");
                                if (position != -1)
                                {
                                    position = position + 3; //exe
                                    uniString = uniString.Insert(position + 1, "\"");
                                    uniString = "\"" + uniString + args;
                                    //MyLogger.WriteLog("TEST: " + uniString);
                                    PackageManager.UninstallNoArgs(uniString);
                                }
                            }

                        }
                        //if it only ends with a quote - photoshop workaround
                        //uninstall string is like : uninstall_path.exe arg1 arg2="some value"
                        if (!uniString.StartsWith("\"") && uniString.EndsWith("\""))
                        {
                            string args = " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                           
                            //uniString = uniString.Replace("\"", ""); //replace quotes with nothing

                            int position = uniString.IndexOf(".exe ");
                            if (position != -1)
                            {
                                position = position + 3; //exe
                                uniString = uniString.Insert(position + 1, "\" ");
                                uniString = "\"" + uniString + args;
                                //MyLogger.WriteLog("TEST: " + uniString);
                                PackageManager.UninstallNoArgs(uniString);
                            }
                        }
                    }
                }
            }
            else
            {
                //some silent uninstall strings still show some dialogs waiting for user input
                //that's why we again examine the string and append our custom parameters

                String uniString = pack.QuietUninstallString;
                //MyLogger.WriteLog(uniString);
                if (uniString.StartsWith("MsiExec.exe "))
                {
                    PackageManager.UninstallNoArgs(uniString);
                }
                else
                {
                    //if uninstall string is within " "
                    if (uniString.StartsWith("\"") && uniString.EndsWith("\""))
                    {
                        if (uniString.EndsWith(".exe\""))
                        {
                            string args = '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                            PackageManager.EXE_Uninstall(uniString, args);
                        }
                        else
                        {
                            // this one probably never happens since a "uninstall_file_path.exe arg1 arg2" type string will result
                            // in cmd trying to find the whole file contained within the quotes
                            // however we leave this here in case it is more something like this "uninstall_file_path.exe" arg1 arg2="some value"
                            uniString = uniString + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                            PackageManager.UninstallNoArgs(uniString);
                        }
                    }

                    if (uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                    {
                        //enquoted exe path only - parameters unquoted
                        uniString = uniString + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                        PackageManager.UninstallNoArgs(uniString);
                    }

                    //unquoted from here on
                    if (!uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                    {
                        if (uniString.EndsWith(".exe"))
                        {
                            string args = "\"/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-\"";
                            PackageManager.EXE_Uninstall(uniString, args);
                        }
                        else // we build quotes around the uninstall .exe and concat our custom parameters with the existing ones
                        {
                            string args = " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                            int position = uniString.IndexOf(".exe ");
                            if (position != -1)
                            {
                                position = position + 3; //exe
                                uniString = uniString.Insert(position + 1, "\"");
                                uniString = "\"" + uniString + args;
                                //MyLogger.WriteLog("TEST: " + uniString);
                                PackageManager.UninstallNoArgs(uniString);
                            }
                        }

                    }
                    //if it only ends with a quote - photoshop workaround
                    //uninstall string is like : uninstall_path.exe arg1 arg2="some value"
                    if (!uniString.StartsWith("\"") && uniString.EndsWith("\""))
                    {
                        string args = " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";

                        //uniString = uniString.Replace("\"", "");

                        int position = uniString.IndexOf(".exe ");
                        if (position != -1)
                        {
                            position = position + 3; //exe
                            uniString = uniString.Insert(position + 1, "\"");
                            uniString = "\"" + uniString + args;
                            //MyLogger.WriteLog("TEST: " + uniString);
                            PackageManager.UninstallNoArgs(uniString);
                        }
                    }
                }
            }
        }

        public static void UnattendedInstall()
        {
            if (Directory.Exists(Application.StartupPath + @"\apps_deploy"))
            {
                try
                {
                    //Directory.EnumerateFiles is not available in .NET 2.0
                    string[] files = Directory.GetFiles(Application.StartupPath + @"\apps_deploy");

                    foreach (string file in files)
                    {
                        if (file.EndsWith(".exe"))
                        {
                            PackageManager.EXE_Install(file);
                        }
                        if (file.EndsWith(".msi"))
                        {
                            PackageManager.MSI_Install(file);
                        }
                        else
                        {
                            //pass
                        }
                    }
                }
                catch (Exception ex)
                {
                    MyLogger.WriteErrorLog("Exception occured while performing Unattended Installation");
                    MyLogger.WriteErrorLog(ex.Message);
                }
            }
            else
            {
                MyLogger.WriteErrorLog("Directory apps_deploy does not exist!");
            }
        }

        public static void ManagePrograms()
        {
            for (int i = 0; i < PackageManager.installedProgramsList.Count; i++)
            {
                if (PackageManager.installedProgramsList[i].ToRemove)
                {
                    //MyLogger.WriteLog("package is :" + PackageManager.installedProgramsList[i].PackageName + " " + i);
                    PackageManager.CheckUninstallationMethod(PackageManager.installedProgramsList[i]);
                }
            }
        }

        internal static void WriteAllSoftware()
        {
            MyLogger.WriteAllSoftware("========INSTALLED SOFTWARE========");
            foreach (Package pack in installedProgramsList)
            {
                MyLogger.WriteAllSoftware(pack.PackageName);
            }
            MyLogger.WriteAllSoftware("========INSTALLED SOFTWARE========");
        }
    }
}