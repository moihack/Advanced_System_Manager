using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AdvancedSystemManager
{
    class CPUPower
    {
   /*     struct PROCESSOR_POWER_POLICY_INFO
        {
            public uint TimeCheck;
            public uint DemoteLimit;
            public uint PromoteLimit;
            public byte DemotePercent;
            public byte PromotePercent;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Spare;
            public uint AllowBits;
        }

        struct PROCESSOR_POWER_POLICY
        {
            public uint Revision;
            public byte DynamicThrottle;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Spare;
            public uint Reserved;
            public uint PolicyCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public PROCESSOR_POWER_POLICY_INFO[] Policy;
        }

        struct MACHINE_PROCESSOR_POWER_POLICY
        {
            public uint Revision;                   // ULONG
            public PROCESSOR_POWER_POLICY ProcessorPolicyAc;
            public PROCESSOR_POWER_POLICY ProcessorPolicyDc;
        }

          [DllImport("powrprof.dll", SetLastError = true)]
          private static extern bool SetActivePwrScheme(uint uiID, IntPtr lpGlobalPowerPolicy, IntPtr lpPowerPolicy);
          static extern bool WriteProcessorPwrScheme(uint uiID, MACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy);

        //  static extern bool ReadProcessorPwrScheme(uint uiID, out MACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy);
        //[DllImport("powrprof.dll", SetLastError = true)]
          static extern bool ReadProcessorPwrScheme(uint uiID, out MACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy);

        public void ReadProcessorPowerScheme()
        {
            MACHINE_PROCESSOR_POWER_POLICY machinep = new MACHINE_PROCESSOR_POWER_POLICY();
            uint scheme = 0;

            if (ReadProcessorPwrScheme(scheme, out machinep))
            {

                //Then loop through machinep.ProcessorPolicyAc.Policy[]; array
                //Use:  PROCESSOR_POWER_POLICY_INFO processorPolicyInfoAc = mppp.ProcessorPolicyAc.Policy[i];
                //Use: processorPolicyInfoAc.DemotePercent;
                //Use: processorPolicyInfoAc.PromotePercent;

                //And don't forget to do the same for Dc (Dc is battery)
            }
        } */

        public static void SetCPUStates()
        {
            string windowsVer = RegistryParser.WindowsVersion();
            string output = "";
            string args = "";

            if (windowsVer.Contains("XP"))
            { //untested!!
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
                catch (Exception e)
                {
                    MyLogger.WriteLog(e.Message + " Error on executing: " + args);
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
                }
                catch (Exception e)
                {
                    MyLogger.WriteLog(e.Message + " Error on executing: " + args);
                }

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

        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
