using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AdvancedSystemManager
{
    class CPUPower
    {
        public static void SetCPUStates()
        {
            string windowsVer = RegistryParser.WindowsVersion();
            string output = "";
            string args = "";

            if (windowsVer.Contains("XP"))
            { //untested due to no XP machine available
                Process myProcess = new Process();
                try
                {
                    args = "powercfg /QUERY";
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
                        if (line.StartsWith("Name"))
                        {
                            output = line;
                            //break;
                        }
                    }
                    //myProcess.WaitForExit();
                    output = output.Remove(0, 3);

                    output = output.Trim();
                    Console.WriteLine(output);

                    // powercfg /CHANGE "Home/Office Desk" /PROCESSOR-THROTTLE-AC
                    args = "powercfg /CHANGE " + '"' + output + '"' + " /PROCESSOR-THROTTLE-AC NONE";
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();

                    args = "powercfg /CHANGE " + '"' + output + '"' + " /PROCESSOR-THROTTLE-DC NONE";
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();

                    args = "powercfg /SETACTIVE " + '"' + output + '"';
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();

                }
                catch (Exception ex)
                {
                    MyLogger.WriteErrorLog(ex.Message);
                    MyLogger.WriteErrorLog("Error while setting CPU State");
                }
            }
            else
            {
                Process myProcess = new Process();
                try
                {
                    args = "powercfg -getactivescheme";
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
                        output = line;
                    }
                    //myProcess.WaitForExit();

                    //example
                    //Power Scheme GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c  (High performance)
                    output = output.Remove(0, 19);
                    string[] ends = output.Split('(');
                    Console.WriteLine(ends[0]);

                    args = "powercfg /SETACVALUEINDEX " + ends[0] + " SUB_PROCESSOR PROCTHROTTLEMAX 100";
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();

                    args = "powercfg /SETACVALUEINDEX " + ends[0] + " SUB_PROCESSOR PROCTHROTTLEMIN 100";
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();

                    args = "powercfg /SETDCVALUEINDEX " + ends[0] + " SUB_PROCESSOR PROCTHROTTLEMAX 100";
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();

                    args = "powercfg /SETDCVALUEINDEX " + ends[0] + " SUB_PROCESSOR PROCTHROTTLEMIN 100";
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();

                    args = "powercfg /SETACTIVE " + ends[0];
                    myProcess.StartInfo.Arguments = "/c " + args;
                    myProcess.Start();
                }
                catch (Exception ex)
                {
                    MyLogger.WriteErrorLog(ex.Message);
                    MyLogger.WriteErrorLog("Error while setting CPU State");
                }
            }
        }
    }
}