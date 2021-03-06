﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;

namespace AdvancedSystemManager
{
    class SystemInfo
    {
        internal static Boolean is64BitOS = false;
        internal String HOSTNAME { get; }
        internal String USERNAME { get; }
        internal String OSVERSION { get; }
        internal String OSBITNESS { get; }
        internal String MB { get; }
        internal String CPU { get; }
        internal String RAM { get; set; }
        internal String GPU { get; }
        internal String VRAM { get; set; }
        internal String HDD { get; set; }
        internal String HDDModel { get; }
        internal SystemInfo()
        {
            this.HOSTNAME = Environment.MachineName;
            this.USERNAME = Environment.UserName;
            this.OSVERSION = RegistryParser.WindowsVersion();
            this.OSBITNESS = WMIFinder("OSArchitecture", "Win32_OperatingSystem");
            this.MB = WMIFinder("Product", "Win32_BaseBoard");
            this.CPU = WMIFinder("Name", "Win32_Processor");
            this.RAM = WMIFinder("TotalPhysicalMemory", "Win32_ComputerSystem");
            this.GPU = WMIFinder("Name", "Win32_VideoController");
            this.VRAM = WMIFinder("AdapterRAM", "Win32_VideoController");
            this.HDD = WMIFinder("Size", "Win32_DiskDrive");
            this.HDDModel = WMIFinder("Model", "Win32_DiskDrive");

            if(this.OSBITNESS.Contains("64"))
            {
                is64BitOS = true;
            }

            ConvertFieldValues();
        }
       
        private static String WMIFinder(String propertyName,String wmiClass)
        {
            string retVal = "0";

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + propertyName + " FROM " + wmiClass);

                foreach (ManagementObject mo in searcher.Get())
                {
                    foreach (PropertyData property in mo.Properties)
                    {
                        retVal = property.Value.ToString();
                    }
                    break; //do not return any other found values
                }
                return retVal;
            }
            catch(Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured while gathering System Info");
                MyLogger.WriteErrorLog(ex.Message);
            }

            return retVal;
        }

        public override string ToString()
        {
            string res = "========SYSTEM INFO========" + "\r\n";
            res += "\r\n" + "Hostname: " + this.HOSTNAME + "\r\n";
            res += "\r\n" + "Operating System: " + this.OSVERSION + " - " + this.OSBITNESS + "\r\n";
            res += "\r\n" + "Motherboard: " + this.MB + "\r\n";
            res += "\r\n" + "CPU: " + this.CPU + "\r\n";
            res += "\r\n" + "RAM: " + this.RAM + "\r\n";
            res += "\r\n" + "GPU: " + this.GPU + " with "  + this.VRAM + "\r\n";
            res += "\r\n" + "HDD: " + this.HDDModel + " with " + this.HDD + "\r\n";
            res += "\r\n" + "========SYSTEM INFO========" + "\r\n";

            return res;
        }

        internal void ConvertFieldValues()
        {
            this.RAM = Convert.ToUInt64(this.RAM) / 1024 / 1024 + " MB";
            this.VRAM = Convert.ToUInt64(this.VRAM) / 1024 / 1024 + " MB of VRAM";
            this.HDD = Convert.ToUInt64(this.HDD) / 1000 / 1000 / 1000 + " GB of storage";
        }

    }
}
