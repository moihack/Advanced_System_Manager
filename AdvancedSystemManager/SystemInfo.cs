using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace AdvancedSystemManager
{
    class SystemInfo
    {
        public String HOSTNAME { get; }
        public String USERNAME { get; }
        public String OSVERSION { get; }
        public String CPU { get; }
        public String RAM { get; }
        public String GPU { get; }

        public SystemInfo()
        {
            this.HOSTNAME = Environment.MachineName;
            this.USERNAME = Environment.UserName;
            this.OSVERSION = WindowsVersion();

            //ManagementObjectSearcher
        }

        private string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        private String WindowsVersion()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }

    }
}
