using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    class ProcessManager
    {

        public static void UninstallTest()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "MsiExec.exe /X{23170F69-40C1-2702-1604-000001000000} /q";
            //startInfo.Verb = "runas";

            startInfo.FileName = "MsiExec.exe";
            startInfo.Arguments = "/X{23170F69-40C1-2702-1604-000001000000} /q";
            process.StartInfo = startInfo;
            process.Start();
        }

        public static void InstallTest()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "MsiExec.exe /i \"D:\\7z1604-x64.msi\" /q";
            //startInfo.Verb = "runas";

            startInfo.FileName = "MsiExec.exe";
            startInfo.Arguments = "/i \"D:\\7z1604-x64.msi\" /q";

            process.StartInfo = startInfo;
            process.Start();
        }

    }
}
