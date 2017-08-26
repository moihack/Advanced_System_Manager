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

        public static String GetStartupPrograms()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetValueNames())
                {
                    Console.WriteLine(v);
                    //rk.OpenSubKey(v);
                    String regVal = rk.GetValue(v).ToString();
                    // Console.WriteLine(rk.ToString());
                    if (regVal != "")
                    {
                        StartupItem sItem = new StartupItem(v, rk.GetValue(v).ToString(), true, rk.ToString());
                        PackageManager.startupPrograms.Add(sItem);
                        //     Console.WriteLine("eee: " + v + regVal);
                    }
                    else
                    {
                        Console.WriteLine("dn mphka");
                    }
                }
            }
            catch { return ""; }

            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetValueNames())
                {
                    Console.WriteLine(v);
                    //rk.OpenSubKey(v);
                    String regVal = rk.GetValue(v).ToString();
                    // Console.WriteLine(rk.ToString());
                    if (regVal != "")
                    {
                        StartupItem sItem = new StartupItem(v, rk.GetValue(v).ToString(), true, rk.ToString());
                        PackageManager.startupPrograms.Add(sItem);
                        //Console.WriteLine("loc is: " + rk.ToString());
                        // Console.WriteLine("eee: " + v + regVal);
                    }
                    else
                    {
                        Console.WriteLine("dn mphka");
                    }
                }
            }
            catch { return ""; }

            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetValueNames())
                {
                    Console.WriteLine(v);
                    //rk.OpenSubKey(v);
                    String regVal = rk.GetValue(v).ToString();
                    // Console.WriteLine(rk.ToString());
                    if (regVal != "")
                    {
                        StartupItem sItem = new StartupItem(v, rk.GetValue(v).ToString(), true, rk.ToString());
                        PackageManager.startupPrograms.Add(sItem);
                        //  Console.WriteLine("eee: " + v + regVal);
                    }
                    else
                    {
                        Console.WriteLine("dn mphka");
                    }
                }
            }
            catch { return ""; }

            return "";

        }

        public static String GetDisabledStartupPrograms()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Shared Tools\\MSConfig\\startupreg");
                if (rk == null) return "";
                //return (string)rk.GetValue(key);

                foreach (string v in rk.GetSubKeyNames())
                {
                    Console.WriteLine(v);
                    RegistryKey productKey = rk.OpenSubKey(v);
                    //Console.WriteLine(rk.GetValue(v));

                    String command = productKey.GetValue("command", "noval").ToString();
                    String hkey = productKey.GetValue("hkey", "noval").ToString();
                    String itemName = productKey.GetValue("item", "noval").ToString();
                    String keyName = productKey.GetValue("key", "noval").ToString();
                    String location = hkey + "\\" + keyName;

                    //Console.WriteLine(location);
                    if (!( command.Equals("noval") || hkey.Equals("noval") || itemName.Equals("noval") || keyName.Equals("noval") ))
                    {
                        StartupItem sItem = new StartupItem(itemName, command, false, location);
                        PackageManager.startupPrograms.Add(sItem);
                    }                   
                    // Console.WriteLine(rk.ToString());
                    /*  if (regVal!="")
                      {
                          StartupItem sItem = new StartupItem(v, rk.GetValue(v).ToString(), true);
                          PackageManager.startupPrograms.Add(sItem);
                        //  Console.WriteLine("eee: " + v + regVal);
                      }
                      else
                      {
                          Console.WriteLine("dn mphka");
                      } */

                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "";
        }

        public static void MoveKey()
        {

        }

        public static void EnableKeyStartup(StartupItem si)
        {            
            if ( si.Location.StartsWith("HKLM") || si.Location.StartsWith("HKEY_LOCAL_MACHINE"))
            {
                //rk3 = Registry.LocalMachine.OpenSubKey(si.Location,true);
                //Registry.SetValue(si.)
                //si.Location = si.Location.Replace("HKLM", "HKEY_LOCAL_MACHINE");

                //String loc = si.Location.Remove(0, 5);

                String hkey = si.Location.Split('\\')[0];
                //Console.WriteLine("hkey is::: " + hkey);

                String loc = si.Location.Trim(hkey.ToCharArray());
                loc = loc.Substring(1);
                //Console.WriteLine("new loc is: " + loc);

                RegistryKey rk3 = Registry.LocalMachine.OpenSubKey(loc, true);
                rk3.SetValue(si.Name, si.Command);
                rk3.Close();

                //Registry.SetValue(si.Location, si.Name, si.Command);
            }
            if (si.Location.StartsWith("HKCU") || si.Location.StartsWith("HKEY_CURRENT_USER"))
            {
                //rk3 = Registry.CurrentUser.OpenSubKey(si.Location, true);
                //rk3.SetValue(si.Name, si.Command);
                //si.Location = si.Location.Replace("HKCU", "HKEY_CURRENT_USER");

                // String loc = si.Location.Remove(0, 5);
                //si.Location = "HKEY_CURRENT_USER" + si.Location;
                //Console.WriteLine(loc);

                String hkey = si.Location.Split('\\')[0];
                //Console.WriteLine("hkey is::: " + hkey);

                String loc = si.Location.Trim(hkey.ToCharArray());
                loc = loc.Substring(1);
                //Console.WriteLine("new loc is: " + loc);

                //Registry.SetValue(si.Location, si.Name, si.Command);
                RegistryKey rk3 = Registry.CurrentUser.OpenSubKey(loc, true);
                // Console.WriteLine(rk3.ToString());
                //rk3.SetValue("test", "auhfaf789823982e898jefge.exe -ana8f8faf -effe");
                rk3.SetValue(si.Name, si.Command);
                rk3.Close();
            }

            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Shared Tools\\MSConfig\\startupreg", true);
            rk.DeleteSubKey(si.Name);
        }

        public static void DisableKeyStartup(StartupItem si)
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Shared Tools\\MSConfig\\startupreg",true);
            rk.CreateSubKey(si.Name);

            RegistryKey rk2 = rk.OpenSubKey(si.Name, true);

            RegistryKey rk3;

            rk2.SetValue("command", si.Command);
            rk2.SetValue("item", si.Name);
            //rk2.SetValue("command", si.Command);
            //rk2.SetValue("location", si.Location);

            String hkey = si.Location.Split('\\')[0];
            Console.WriteLine("hkey is::: " + hkey);

            String loc = si.Location.Trim(hkey.ToCharArray());
            loc = loc.Substring(1);
            Console.WriteLine("new loc is: " + loc);

            if (hkey.ToLower().Contains("local") || hkey.ToLower().Contains("hklm"))
            {
                hkey = "HKLM";
                rk3 = Registry.LocalMachine.OpenSubKey(loc,true);
                rk3.DeleteValue(si.Name);
              
               // Console.WriteLine(rk3.ToString() + "\\" + si.Name + "   FFFF " ) ;
            }
            if (hkey.ToLower().Contains("user") || hkey.ToLower().Contains("hkcu") )
            {
                hkey = "HKCU";
                //rk3 = Registry.CurrentUser;
                Console.WriteLine("SI IS :  " + si.Location);
                Console.WriteLine("my loc is:::: " + loc);
                rk3 = Registry.CurrentUser.OpenSubKey(loc, true);
                rk3.DeleteValue(si.Name);
            }

            rk2.SetValue("hkey", hkey);
            rk2.SetValue("key", loc);
            rk2.SetValue("inimapping", "0");

           // rk3.OpenSubKey(loc);
           // Console.WriteLine(rk3.ToString());
           
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
