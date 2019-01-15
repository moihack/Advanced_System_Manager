using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace AdvancedSystemManager
{
    class WindowsUpdates
    {
        internal static List<String> installedUpdatesList = new List<String>();

        internal void UpdatesFinder()
        {
            const string query = "SELECT HotFixID FROM Win32_QuickFixEngineering";
            var search = new ManagementObjectSearcher(query);
            var collection = search.Get();

            foreach (ManagementObject hotfix in collection)
                installedUpdatesList.Add(hotfix["HotFixID"].ToString());      
        }

        internal static String UpdateChecker(String updateID)
        {
            bool updateInstalled = false;
            String msg = "";

            foreach (String x in WindowsUpdates.installedUpdatesList)
            {
                if(x.Equals(updateID))
                {
                    updateInstalled = true;
                }
            }

            if (updateInstalled)
            {
                 msg = ("Update " + updateID + " is installed.");
            }
            else
            {
                msg = ("Update " + updateID + " is NOT installed");
            }

            return msg;
        }

    }
}
