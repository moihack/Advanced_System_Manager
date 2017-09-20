using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    public class RegistryParser
    {        
        public static string GetPrograms()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                if (rk == null) return "";

                foreach (string v in rk.GetSubKeyNames())
                {
                    RegistryKey productKey = rk.OpenSubKey(v);
                    if (productKey != null)
                    {
                        // https://msdn.microsoft.com/en-us/library/kk88y0s0(v=vs.110).aspx
                        // GetValue("value to search", "default value to return if the previous is not found")

                        string productName = Convert.ToString(productKey.GetValue("DisplayName", "noDisplayName"));
                        string unString = Convert.ToString(productKey.GetValue("UninstallString", "noUnString"));
                        string quietUnString = Convert.ToString(productKey.GetValue("QuietUninstallString", "noQuiet"));
                        string dispVersion = Convert.ToString(productKey.GetValue("DisplayVersion", ""));
                        //read value is in KB and is UInt since size is always >= 0
                        bool sysComp = Convert.ToBoolean(productKey.GetValue("SystemComponent", 0));

                        UInt32 estSize = Convert.ToUInt32(productKey.GetValue("EstimatedSize", "0"));
                        string publisher = Convert.ToString(productKey.GetValue("Publisher", "Unknown Publisher"));

                        Package pack = new Package(productName, publisher, sysComp, estSize, unString, quietUnString,dispVersion);
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
                
        public static string GetWin64Programs()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                if (rk == null) return "";

                foreach (string v in rk.GetSubKeyNames())
                {
                    RegistryKey productKey = rk.OpenSubKey(v);
                    if (productKey != null)
                    {                       
                        string productName = Convert.ToString(productKey.GetValue("DisplayName", "noDisplayName"));
                        string unString = Convert.ToString(productKey.GetValue("UninstallString", "noUnString"));
                        string quietUnString = Convert.ToString(productKey.GetValue("QuietUninstallString", "noQuiet"));
                        string dispVersion = Convert.ToString(productKey.GetValue("DisplayVersion", ""));

                        //read value is in KB and is UInt since size is always >= 0
                        bool sysComp = Convert.ToBoolean(productKey.GetValue("SystemComponent", 0));

                        UInt32 estSize = Convert.ToUInt32(productKey.GetValue("EstimatedSize", "0"));
                        string publisher = Convert.ToString(productKey.GetValue("Publisher", "Unknown Publisher"));

                        Package pack = new Package(productName, publisher, sysComp, estSize, unString, quietUnString,dispVersion);
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

                foreach (string v in rk.GetSubKeyNames())
                {
                    RegistryKey productKey = rk.OpenSubKey(v);
                    if (productKey != null)
                    {                       
                        string productName = Convert.ToString(productKey.GetValue("DisplayName", "noDisplayName"));
                        string unString = Convert.ToString(productKey.GetValue("UninstallString", "noUnString"));
                        string quietUnString = Convert.ToString(productKey.GetValue("QuietUninstallString", "noQuiet"));
                        string dispVersion = Convert.ToString(productKey.GetValue("DisplayVersion", ""));

                        //read value is in KB and is UInt since size is always >= 0
                        bool sysComp = Convert.ToBoolean(productKey.GetValue("SystemComponent", 0));

                        UInt32 estSize = Convert.ToUInt32(productKey.GetValue("EstimatedSize", "0"));
                        string publisher = Convert.ToString(productKey.GetValue("Publisher", "Unknown Publisher"));

                        Package pack = new Package(productName, publisher, sysComp, estSize, unString, quietUnString,dispVersion);
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
                    String regVal = rk.GetValue(v).ToString();
                    if (regVal != "")
                    {
                        StartupItem sItem = new StartupItem(v, rk.GetValue(v).ToString(), true, rk.ToString());
                        PackageManager.startupProgramsList.Add(sItem);
                    }
                    else
                    {
                        //pass
                    }
                }
            }
            catch { return ""; }

            if (SystemInfo.is64BitOS)
            {
                try
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run");
                    if (rk == null) return "";

                    foreach (string v in rk.GetValueNames())
                    {
                        String regVal = rk.GetValue(v).ToString();

                        if (regVal != "")
                        {
                            StartupItem sItem = new StartupItem(v, rk.GetValue(v).ToString(), true, rk.ToString());
                            PackageManager.startupProgramsList.Add(sItem);
                        }
                        else
                        {
                            //pass
                        }
                    }
                }
                catch { return ""; }
            }

            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (rk == null) return "";

                foreach (string v in rk.GetValueNames())
                {
                    String regVal = rk.GetValue(v).ToString();

                    if (regVal != "")
                    {
                        StartupItem sItem = new StartupItem(v, rk.GetValue(v).ToString(), true, rk.ToString());
                        PackageManager.startupProgramsList.Add(sItem);
                    }
                    else
                    {
                        //pass
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

                foreach (string v in rk.GetSubKeyNames())
                {
                    RegistryKey productKey = rk.OpenSubKey(v);

                    String command = productKey.GetValue("command", "noval").ToString();
                    String hkey = productKey.GetValue("hkey", "noval").ToString();
                    String itemName = productKey.GetValue("item", "noval").ToString();
                    String keyName = productKey.GetValue("key", "noval").ToString();
                    String location = hkey + "\\" + keyName;

                    if (!( command.Equals("noval") || hkey.Equals("noval") || itemName.Equals("noval") || keyName.Equals("noval") ))
                    {
                        StartupItem sItem = new StartupItem(itemName, command, false, location);
                        PackageManager.startupProgramsList.Add(sItem);
                    }                   
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return "";
        }


        public static void EnableKeyStartup(StartupItem si)
        {            
            if ( si.Location.StartsWith("HKLM") || si.Location.StartsWith("HKEY_LOCAL_MACHINE"))
            {
                String hkey = si.Location.Split('\\')[0];

                String loc = si.Location.Trim(hkey.ToCharArray());
                loc = loc.Substring(1);

                RegistryKey rk3 = Registry.LocalMachine.OpenSubKey(loc, true);
                rk3.SetValue(si.Name, si.Command);
                rk3.Close();
            }
            if (si.Location.StartsWith("HKCU") || si.Location.StartsWith("HKEY_CURRENT_USER"))
            {
                String hkey = si.Location.Split('\\')[0];

                String loc = si.Location.Trim(hkey.ToCharArray());
                loc = loc.Substring(1);

                RegistryKey rk3 = Registry.CurrentUser.OpenSubKey(loc, true);

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

            String hkey = si.Location.Split('\\')[0];

            String loc = si.Location.Trim(hkey.ToCharArray());
            loc = loc.Substring(1);

            if (hkey.ToLower().Contains("local") || hkey.ToLower().Contains("hklm"))
            {
                hkey = "HKLM";
                rk3 = Registry.LocalMachine.OpenSubKey(loc,true);
                rk3.DeleteValue(si.Name);             
            }
            if (hkey.ToLower().Contains("user") || hkey.ToLower().Contains("hkcu") )
            {
                hkey = "HKCU";

                rk3 = Registry.CurrentUser.OpenSubKey(loc, true);
                rk3.DeleteValue(si.Name);
            }

            rk2.SetValue("hkey", hkey);
            rk2.SetValue("key", loc);
            rk2.SetValue("inimapping", "0");
        }

        public static void ApplyVisualEffects()
        {
            try
            {
                //http://stackoverflow.com/questions/4463706/cannot-write-to-registry-key-getting-unauthorizedaccessexception open the key to be writeable
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects", true);

                rk.SetValue("VisualFXSetting", 3); //custom visual effect settings option

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
                                //MyLogger.WriteLog(folder + " volumecaches " + fileList);
                                DiskCleanUp.FindFiles(folder, fileList);
                        }
                        if (folder.Equals("noFolder") && fileList.Equals("noFileList"))
                        {
                            //SetupDirectories
                            string setupDirs = Convert.ToString(productKey.GetValue("SetupDirectories", "noSetupDirectories"));

                            if( !setupDirs.Equals("noSetupDirectories"))
                            {
                                DiskCleanUp.FindDirs(setupDirs);
                            }
                        }
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        public static void CreateStartupReg()
        {
            //Make sure startupreg exists! - otherwise exception occurs!
            //the key is normally created when the user disables a startup item via msconfig
            RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Shared Tools\\MSConfig\\startupreg");
            rk.Close();
        }
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
