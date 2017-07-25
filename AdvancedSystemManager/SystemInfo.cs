using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;

namespace AdvancedSystemManager
{
    class SystemInfo
    {
        public String HOSTNAME { get; }
        public String USERNAME { get; }
        public String OSVERSION { get; }
        public String OSBITNESS { get; }
        public String MB { get; }
        public String CPU { get; }
        public String RAM { get; }
        public String GPU { get; }
        public String VRAM { get; }
        public String HDD { get; }
        public String HDDModel { get; }
        public SystemInfo()
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
        }
       
        private static String WMIFinder(String propertyName,String wmiClass)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + propertyName + " FROM " + wmiClass);
            
            string retVal = "";
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    Console.WriteLine(property.Value);
                    MyLogger.WriteLog(property.Value);
                    retVal = property.Value.ToString();                   
                }
            }
            return retVal;
        }

        

        public void UpdatesFinder2()
        {
            string x = WMIFinder("HotFixID", "Win32_QuickFixEngineering");
            Console.WriteLine("test");
            //Console.WriteLine(x);
        }

    }
}
