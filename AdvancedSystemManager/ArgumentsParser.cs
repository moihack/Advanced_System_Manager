﻿using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;

namespace AdvancedSystemManager
{
    class ArgumentsParser
    {
        static bool willGetSysInfo = false;
        static bool willGetProgramsList = false;
        static bool willTweakEffects = false;
        static bool willDoUnattendedInstall = false;
        static bool willDoMassiveUninstall = false;
        static bool willCleanDisk = false;
        static bool willSetCPU = false;

        internal static void ParseArguments(string[] arguments)
        {
            for(int i = 1; i<arguments.Length; i++)
            {
                CheckArg(arguments[i]);
            }

            RunArgs();
        }

        private static void CheckArg(string argX)
        {
            switch (argX)
            {
                case ("-sysinfo"):
                    if (!willGetSysInfo)
                    {
                        willGetSysInfo = true;                   
                    }
                    break;

                case ("-getprograms"):
                    if (!willGetProgramsList)
                    {
                        willGetProgramsList = true;
                    }
                    break;

                case ("-effects"):
                    if (!willTweakEffects)
                    {
                        willTweakEffects = true;
                    }
                    break;

                case ("-remove"):
                    if (!willDoMassiveUninstall)
                    {
                        willDoMassiveUninstall = true;
                    }
                    break;

                case ("-install"):
                    if (!willDoUnattendedInstall)
                    {
                        willDoUnattendedInstall = true;
                    }
                    break;

                case ("-clean"):
                    if (!willCleanDisk)
                    {
                        willCleanDisk = true;
                    }
                    break;

                case ("-setcpu"):
                    if (!willSetCPU)
                    {
                        willSetCPU = true;
                    }
                    break;

                default:
                {
                        Console.WriteLine("Unkown argument detected: " + argX);
                        Console.WriteLine("Program will now exit...");
                    //    System.Threading.Thread.Sleep(3500);
                        //Application.Exit();
                    //    Environment.Exit(-1);
                        break;
                }
            }
        }

        private static void RunArgs()
        {
            try
            {
                //optimize for speed first
                if (willSetCPU)
                {
                    CPUPower.SetCPUStates();
                }

                if (willGetSysInfo)
                {
                    SystemInfo sysinfo = new SystemInfo();
                    MyLogger.WriteSystemInfo(sysinfo.ToString());
                }

                if(willGetProgramsList)
                {
                    SystemInfo sysinfo = new SystemInfo();
                    PackageManager.GetAllProgramsList();
                    PackageManager.WriteAllSoftware();
                }

                if(willTweakEffects)
                {
                    VisualEffects.ApplySettings();
                    RegistryParser.ApplyVisualEffects();
                }

                if (willDoMassiveUninstall)
                {
                    PackageManager.GetAllProgramsList();
                    PackageManager.ManagePrograms();
                }

                if (willDoUnattendedInstall)
                {
                    PackageManager.UnattendedInstall();
                }

                if(willCleanDisk)
                {
                    RegistryParser.GetVolumeCaches();
                }
            }
            catch(Exception ex)
            {
                MyLogger.WriteErrorLog(ex.Message);
            }
        }
    }
}
