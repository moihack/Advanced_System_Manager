using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    class Package
    {
        String DisplayName { set; get; }
        String DisplayVersion { set; get; }
        String Publisher { set; get; }
        String UninstallString { set; get; }
        String QuietUninstallString { set; get; }
        UInt32 EstimatedSizeInKB { set; get; }

        Package(String dispName,String dispVer,String pub,String uniString,String quietUniString,UInt32 size)
        {
            this.DisplayName = dispName;
            this.DisplayVersion = dispVer;
            this.Publisher = pub;
            this.UninstallString = uniString;
            this.QuietUninstallString = quietUniString;
            this.EstimatedSizeInKB = size;
        }

    }
}
