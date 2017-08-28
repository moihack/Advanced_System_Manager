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
        public static List<StartupItem> startupPrograms = new List<StartupItem>();

        public static Boolean doUnattendedInstall = false;
        public static Boolean hasAntiVirus = false;

        public static void DuplicatesFinder()
        {          
            MyLogger.WriteLog("h lista einai " + installedProgramsList.Count);

            for (int i = 0; i <= installedProgramsList.Count - 1; i++)
            {
                for (int j = installedProgramsList.Count - 1; j >= 0; j--)
                {
                    if( installedProgramsList[i].PackageName.Equals(installedProgramsList[j].PackageName) && installedProgramsList[i].EstimatedSizeInKB.Equals(installedProgramsList[j].EstimatedSizeInKB))
                    {
                        if (i != j)
                        {
                            installedProgramsList.RemoveAt(j);
                        }
                    }
                }
            }

            MyLogger.WriteLog("h lista2 einai " + installedProgramsList.Count);
        }

        public static void RemoveSystemComponents()
        {
            for (int i = installedProgramsList.Count - 1; i >= 0; i--)
            {
                
                if(installedProgramsList[i].IsSystemComponent || installedProgramsList[i].PackageName.Equals("noDisplayName"))
                {
                    //Console.WriteLine(installedProgramsList.Count);
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

            SortPackages();

            //maybe we can do this without iterating the list again
            //  for (int i = installedProgramsList.Count - 1; i >= 0; i--)
            for (int i = 0; i < installedProgramsList.Count; i++)
            {
                MyLogger.WriteLog(installedProgramsList[i].PackageName);
                installedProgramsList[i].isSafeToRemove = PackageSafeToRemove(installedProgramsList[i].PackageName);
            }

            MarkFromText();

        }

        public static void MarkPackages()
        {
            for (int i = 0; i < installedProgramsList.Count; i++)
            {
                MyLogger.WriteLog(installedProgramsList[i].PackageName);
                installedProgramsList[i].isSafeToRemove = PackageSafeToRemove(installedProgramsList[i].PackageName);
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


            //string text = pack;
            // string pat = @"\b(visual|open)\b";
            //string pat = @"(visual|open)";
            string pat = @"(virus|trial|free|toolbar|search|clean|tune)"; //to free pianei k to freeware
            //string pat2 = @"(virus)"; //pianei ta anti-virus, antivirus, antivirus-free ktl
            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(pack);

            if (m.Success)
            {
                //Console.WriteLine(m.Value);
                //Console.WriteLine("test " + m.Groups[0].Captures[0].Value);
                if (!hasAntiVirus)
                {
                    if (m.Value.ToLower().Contains("virus"))
                    //if (m.Value.ToLower().Contains("visual"))
                    {
                        Console.WriteLine(m.Value.ToLower());
                        hasAntiVirus = true;
                        return false; // keeep the first antivirus we found - mark all others
                    }
                }

                return true;
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

        public static void MarkFromText()
        {
            string line;
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(Application.StartupPath + "\\remove.list");
            while ((line = file.ReadLine()) != null)
            {
                // Console.WriteLine(line);
                // counter++;
                foreach (Package pack in installedProgramsList)
                {
                    if (pack.PackageName.Contains(line))
                    {
                        pack.isSafeToRemove = true;
                        pack.ToRemove = true;
                    }
                }
            }

            file.Close();
        }

        public static void GetAllProgramsList()
        {
            RegistryParser.GetCurrentUserPrograms();

            if (SystemInfo.is64BitOS)
            {
                RegistryParser.GetWin64Programs();
            }

            RegistryParser.GetPrograms2();
            RegistryParser.GetPrograms();
            
            PackageManager.RemoveSystemComponents();
            PackageManager.RemoveUpdates();
            PackageManager.DuplicatesFinder();
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
                myProcess.StartInfo.Arguments = "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-"; //arg may be /S , /SILENT and other??
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
                        //string oldargs = " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                        myProcess.Close();
                        //myProcess.StartInfo.Arguments = myProcess.StartInfo.Arguments.TrimEnd(oldargs.ToCharArray());
                        //myProcess.StartInfo.Arguments = " --mode unattended --unattendedmodeui none";
                        myProcess.StartInfo.Arguments = "--mode unattended";
                        //MyLogger.WriteErrorLog(myProcess.StartInfo.Arguments);

                        myProcess.Start();
                    }
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
            MyLogger.WriteErrorLog("EXEUNI: " + uniEXEpath + " " + arg);
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
                        //myProcess.StartInfo.Arguments = myProcess.StartInfo.Arguments.TrimEnd(oldargs.ToCharArray());
                        //myProcess.StartInfo.Arguments = " --mode unattended --unattendedmodeui none";
                        myProcess.StartInfo.Arguments = "--mode unattended";
                        myProcess.Start();                      
                    }
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
            MyLogger.WriteErrorLog("UNA: " + args);
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

                    //we have to deal with InstallBuilder! 
                    //They changed this recently - before it would normally consume any unknown parameters
                    //if the first one was an accepted one

                    if (line.Contains("There has been an error."))
                    {
                        // uniString = '"' + uniString + '"' + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                        string oldargs = " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                        args = args.TrimEnd(oldargs.ToCharArray());
                        args = args + " --mode unattended --unattendedmodeui none";
                        MyLogger.WriteErrorLog(args);
                        
                        UninstallNoArgs(args);
                    }
                }
                //myProcess.WaitForExit();            
            }
            catch (Exception e)
            {
                MyLogger.WriteLog(e.Message + " Error on executing: " + args);
                MyLogger.WriteErrorLog(e.Message + " Error on executing: " + args);
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
                    MyLogger.WriteErrorLog(uniString);
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
                        if (uniString.StartsWith("\"") && uniString.EndsWith("\""))
                        {
                            if (uniString.EndsWith(".exe\""))
                            {
                                //string args = '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                                string args ="/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                                PackageManager.EXE_Uninstall(uniString, args);
                            }
                            else
                            {
                                //uniString = uniString.TrimEnd('"'); //la8os to kanw ena megalo arxeio na psaxnei me " "
                                uniString = uniString + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                                PackageManager.UninstallNoArgs(uniString);
                            }
                        }
                        if (uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                        {
                            //enquoted exe path only + parameters unquoted
                            uniString = uniString + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                            PackageManager.UninstallNoArgs(uniString);
                        }
                        //unquoted apo dw k pera                     
                        if ( !uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                        {
                            if (uniString.EndsWith(".exe"))
                            {
                                string args = "\"/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-\"";
                                PackageManager.EXE_Uninstall(uniString, args);
                            }
                            else
                            {
                                string args = " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                                int position = uniString.IndexOf(".exe ");
                                if(position != -1)
                                {
                                    position = position + 3; //exe
                                    uniString = uniString.Insert(position + 1, "\"");
                                    uniString = "\"" + uniString + args;
                                    MyLogger.WriteErrorLog("TEST: " + uniString);
                                    PackageManager.UninstallNoArgs(uniString);
                                }
                            }

                        }
                            /* else
                             {
                                 //uniString = uniString + " --mode unattended /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                                 //uniString = uniString + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";

                                 // kanw enquote gia na apofugw sthn cmd kena!
                                 uniString = '"' + uniString + '"' + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                                 PackageManager.UninstallNoArgs(uniString);
                             } */

                            //uniString = '"' + uniString + '"' + " --mode unattended /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                            //uniString = uniString + " --mode unattended /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                            // uniString = '"' + uniString + '"' + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                            // MyLogger.WriteErrorLog(uniString);
                            //  PackageManager.UninstallNoArgs(uniString);
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
                MyLogger.WriteErrorLog(uniString);
                if (uniString.StartsWith("MsiExec.exe "))
                {
                    PackageManager.UninstallNoArgs(uniString);
                }
                else
                {
                    if (uniString.StartsWith("\"") && uniString.EndsWith("\""))
                    {
                        if(uniString.EndsWith(".exe\""))
                        {
                            string args = '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                            PackageManager.EXE_Uninstall(uniString, args);
                        }
                        else
                        {
                            //uniString = uniString.TrimEnd('"'); //la8os to kanw ena megalo arxeio na psaxnei me " "
                            uniString = uniString + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                            PackageManager.UninstallNoArgs(uniString);
                        }
                    }
                    if (uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                    {
                        //enquoted exe path only + parameters unquoted
                        uniString = uniString + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                        PackageManager.UninstallNoArgs(uniString);
                    }
                    //unquoted apo dw k pera
                    if (!uniString.StartsWith("\"") && !uniString.EndsWith("\""))
                    {
                        if (uniString.EndsWith(".exe"))
                        {
                            string args = "\"/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-\"";
                            PackageManager.EXE_Uninstall(uniString, args);
                        }
                        else
                        {
                            string args = " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                            int position = uniString.IndexOf(".exe ");
                            if (position != -1)
                            {
                                position = position + 3; //exe
                                uniString = uniString.Insert(position + 1, "\"");
                                uniString = "\"" + uniString + args;
                                MyLogger.WriteErrorLog("TEST: " + uniString);
                                PackageManager.UninstallNoArgs(uniString);
                            }
                        }

                    }

                    //   if( !uniString.StartsWith("\"") && !uniString.EndsWith(".exe"))
                    // {
                    // 8a to kanw megalo arxeio an tou balw quotes - prp na trimmarw gurw apo th leksh .exe mpales apla append
                    //alla an exei kena 8a thn pa8w
                    //uniString = '"' + uniString + '"' + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                    //     PackageManager.UninstallNoArgs(uniString);
                    //  }
                    /* else
                     {
                         //uniString = uniString + " --mode unattended /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";
                         //uniString = uniString + " /S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-";

                         // kanw enquote gia na apofugw sthn cmd kena!
                         uniString = '"' + uniString + '"' + " " + '"' + "/S /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-" + '"';
                         PackageManager.UninstallNoArgs(uniString);
                     } */
                }

            }
        }

        public static void UnattendedInstall()
        {
            //packageName = "";
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
                        //packageName = file;
                        Console.WriteLine(file);
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

        public static void ManagePrograms()
        {
            //console write line does not help much here
            // we avoid accessing controls of the ui thread
            //Console.WriteLine(PackageManager.installedProgramsList[5].PackageName);
            for (int i = 0; i < PackageManager.installedProgramsList.Count; i++)
            {
                if (PackageManager.installedProgramsList[i].ToRemove)
                {
                    MyLogger.WriteLog("package is :" + PackageManager.installedProgramsList[i].PackageName + " " + i);
                    PackageManager.CheckUninstallationMethod(PackageManager.installedProgramsList[i]);
                    //MyLogger.WriteLog(i);
                }
            }

            //if sth true call
            if (PackageManager.doUnattendedInstall)
            {
                //   PackageManager.UnattendedInstall();
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

