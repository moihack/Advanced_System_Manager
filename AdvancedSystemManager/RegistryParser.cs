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

        public static string GetPrograms()
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
                        // https://msdn.microsoft.com/en-us/library/kk88y0s0(v=vs.110).aspx
                        // GetValue("value to search", "default value to return if the previous is not found")

                        string productName = Convert.ToString(productKey.GetValue("DisplayName", "noDisplayName"));
                        string unString = Convert.ToString(productKey.GetValue("UninstallString", "noUnString"));
                        string quietUnString = Convert.ToString(productKey.GetValue("QuietUninstallString", "noQuiet"));

                        //read value is in KB and is UInt since size is always >= 0
                        bool sysComp = Convert.ToBoolean(productKey.GetValue("SystemComponent", 0));
                        Console.WriteLine(sysComp + " " + productName);

                        UInt32 estSize = Convert.ToUInt32(productKey.GetValue("EstimatedSize", "0"));
                        string publisher = Convert.ToString(productKey.GetValue("Publisher", "Unknown Publisher"));
                        //Console.WriteLine(estSize);
                        Package pack = new Package(productName, publisher, sysComp, estSize, unString, quietUnString);
                        PackageManager.installedProgramsList.Add(pack);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " exception occured");
                return "";
            }
            return "";
        }

        public static string GetPrograms2()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Installer\\UserData\\S-1-5-18\\Products");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetSubKeyNames())
                {
                    //Console.WriteLine(v);
                    RegistryKey productKey = rk.OpenSubKey(v).OpenSubKey("InstallProperties");
                    if (productKey != null)
                    {
                        //Console.WriteLine(productKey);
                        //string value1 = productKey.GetValue("DisplayName").ToString();
                        /*foreach (string value in productKey.GetValueNames())
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
                        } */
                        string productName = Convert.ToString(productKey.GetValue("DisplayName", "noDisplayName"));
                        string unString = Convert.ToString(productKey.GetValue("UninstallString", "noUnString"));
                        string quietUnString = Convert.ToString(productKey.GetValue("QuietUninstallString", "noQuiet"));

                        //read value is in KB and is UInt since size is always >= 0
                        bool sysComp = Convert.ToBoolean(productKey.GetValue("SystemComponent", 0));
                        Console.WriteLine(sysComp + " " + productName);

                        UInt32 estSize = Convert.ToUInt32(productKey.GetValue("EstimatedSize", "0"));
                        string publisher = Convert.ToString(productKey.GetValue("Publisher", "Unknown Publisher"));
                        //Console.WriteLine(estSize);
                        Package pack = new Package(productName, publisher, sysComp, estSize, unString, quietUnString);
                        PackageManager.installedProgramsList.Add(pack);
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        public static string GetWin64Programs()
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

                        /*foreach (string value in productKey.GetValueNames())
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
                        } */
                        string productName = Convert.ToString(productKey.GetValue("DisplayName", "noDisplayName"));
                        string unString = Convert.ToString(productKey.GetValue("UninstallString", "noUnString"));
                        string quietUnString = Convert.ToString(productKey.GetValue("QuietUninstallString", "noQuiet"));

                        //read value is in KB and is UInt since size is always >= 0
                        bool sysComp = Convert.ToBoolean(productKey.GetValue("SystemComponent", 0));
                        Console.WriteLine(sysComp + " " + productName);

                        UInt32 estSize = Convert.ToUInt32(productKey.GetValue("EstimatedSize", "0"));
                        string publisher = Convert.ToString(productKey.GetValue("Publisher", "Unknown Publisher"));
                        //Console.WriteLine(estSize);
                        Package pack = new Package(productName, publisher, sysComp, estSize, unString, quietUnString);
                        PackageManager.installedProgramsList.Add(pack);
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        public static string GetCurrentUserPrograms()
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetSubKeyNames())
                {
                    //Console.WriteLine(v);

                    RegistryKey productKey = rk.OpenSubKey(v);
                    if (productKey != null)
                    {
                        //string value1 = productKey.GetValue("DisplayName").ToString();

                        /*foreach (string value in productKey.GetValueNames())
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
                        } */
                        string productName = Convert.ToString(productKey.GetValue("DisplayName", "noDisplayName"));
                        string unString = Convert.ToString(productKey.GetValue("UninstallString", "noUnString"));
                        string quietUnString = Convert.ToString(productKey.GetValue("QuietUninstallString", "noQuiet"));

                        //read value is in KB and is UInt since size is always >= 0
                        bool sysComp = Convert.ToBoolean(productKey.GetValue("SystemComponent", 0));
                        Console.WriteLine(sysComp + " " + productName);

                        UInt32 estSize = Convert.ToUInt32(productKey.GetValue("EstimatedSize", "0"));
                        string publisher = Convert.ToString(productKey.GetValue("Publisher", "Unknown Publisher"));
                        //Console.WriteLine(estSize);
                        Package pack = new Package(productName, publisher, sysComp, estSize, unString, quietUnString);
                        PackageManager.installedProgramsList.Add(pack);
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        public static void GetStartupPrograms()
        {

        }

        public static void ApplyVisualEffects()
        {
            try
            {
                //http://stackoverflow.com/questions/4463706/cannot-write-to-registry-key-getting-unauthorizedaccessexception open the key to be writeable
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", true);
                //Console.WriteLine(rk.GetValue("VisualFXSetting"));
                rk.SetValue("VisualFXSetting", 3); //custom visual effect settings

                rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
                rk.SetValue("ListviewShadow", 0);
                rk.SetValue("TaskbarAnimations", 0);

                rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\DWM", true);
                rk.SetValue("ColorizationOpaqueBlend", 1);
                rk.SetValue("EnableAeroPeek", 0);

                rk = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop\\WindowMetrics", true);
                rk.SetValue("MinAnimate", 0);

                rk = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);
                byte[] settings = new byte[] { 0x90, 0x12, 0x03, 0x80, 0x10, 0x00, 0x00, 0x00 };
                rk.SetValue("UserPreferencesMask", settings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " exception occured");
            }
        }

        public static String GetVolumeCaches()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VolumeCaches");
                if (rk == null) return "";

                foreach (string v in rk.GetSubKeyNames())
                {
                    RegistryKey productKey = rk.OpenSubKey(v);
                    if (productKey != null)
                    {
                        string folder = Convert.ToString(productKey.GetValue("Folder", "noFolder"));
                        string fileList = Convert.ToString(productKey.GetValue("FileList", "noFileList"));
                        if (!folder.Equals("noFolder") && !fileList.Equals("noFileList"))
                        {

                            if (System.IO.Directory.Exists(folder))
                            {
                               // Console.WriteLine(productKey);
                                DiskCleanUp.FindFiles(folder, fileList);
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
