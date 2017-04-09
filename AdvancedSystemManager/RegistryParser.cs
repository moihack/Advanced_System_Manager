using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    public class RegistryParser
    {
        private static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public static string getPrograms()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetSubKeyNames())
                {
                    //Console.WriteLine(v);

                    RegistryKey productKey = rk.OpenSubKey(v);
                    if (productKey != null)
                    {
                        //string value1 = productKey.GetValue("DisplayName").ToString();

                        foreach (string value in productKey.GetValueNames())
                        {
                            if (value.Equals("DisplayName"))
                            {
                                string productName = Convert.ToString(productKey.GetValue("DisplayName"));
                                Console.WriteLine(productName);
                                //if (productName.Contains("QB"))
                                //{
                                //    Console.WriteLine(productName);
                                //}
                            }

                            if (value.Equals("UninstallString"))
                            {
                                string unString = Convert.ToString(productKey.GetValue("UninstallString"));
                                //Console.WriteLine(productName);
                            }
                        }
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        public static string getPrograms2()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Installer\\UserData\\S-1-5-18\\Products");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetSubKeyNames())
                {
                    RegistryKey productKey = rk.OpenSubKey(v).OpenSubKey("InstallProperties");
                    if (productKey != null)
                    {
                        //Console.WriteLine(productKey);
                        //string value1 = productKey.GetValue("DisplayName").ToString();
                        foreach (string value in productKey.GetValueNames())
                        {
                            if (value.Equals("DisplayName"))
                            {
                                string productName = Convert.ToString(productKey.GetValue("DisplayName"));
                                //if (productName.Contains("QB"))
                                //{
                                //    Console.WriteLine(productName);
                                //}                               
                            }

                            if (value.Equals("UninstallString"))
                            {
                                string unString = Convert.ToString(productKey.GetValue("UninstallString"));
                             //   Console.WriteLine(productName);
                            }
                        }
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        public static string getWin64Programs()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetSubKeyNames())
                {
                    //Console.WriteLine(v);

                    RegistryKey productKey = rk.OpenSubKey(v);
                    if (productKey != null)
                    {
                        //string value1 = productKey.GetValue("DisplayName").ToString();

                        foreach (string value in productKey.GetValueNames())
                        {
                            if (value.Equals("DisplayName"))
                            {
                                string productName = Convert.ToString(productKey.GetValue("DisplayName"));
                                Console.WriteLine(productName);
                                //if (productName.Contains("QB"))
                                //{
                                //    Console.WriteLine(productName);
                                //}
                            }

                            if (value.Equals("UninstallString"))
                            {
                                string unString = Convert.ToString(productKey.GetValue("UninstallString"));
                                //Console.WriteLine(productName);
                            }
                        }
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        public static String WindowsVersion()
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
