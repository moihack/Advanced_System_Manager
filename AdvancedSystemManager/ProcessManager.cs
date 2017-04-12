using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdvancedSystemManager
{
    class ProcessManager
    {

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
                myProcess.StartInfo.Arguments = "/X{23170F69-40C1-2702-1604-000001000000} /qn /li C:\\package.log ";
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

    }

}

