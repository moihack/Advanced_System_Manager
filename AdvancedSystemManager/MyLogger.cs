using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    class MyLogger
    {
        MyLogger()
        {

        }

        public static void WriteLog(Object messageLog)
        {
            //true is append - create if not exists!
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Application.StartupPath + "\\log.txt", true))
            {
                file.WriteLine(messageLog);
            }
        }

        public static void CleanLog()
        {
            //false is overwrite - create if not exists!
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Application.StartupPath + "\\log.txt", false))
            {
                file.Write("");
            }
        }
    }
}
