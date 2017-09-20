using System;
using System.Collections.Generic;
using System.IO;
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

        public static void WriteErrorLog(Object messageLog)
        {
            //true is append - create if not exists!
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Application.StartupPath + "\\error_log.txt", true))
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

        public static void WriteProgramList(Object messageLog)
        {
            //true is append - create if not exists!
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Application.StartupPath + "\\programs.txt", true))
            {
                file.WriteLine(messageLog);
            }
        }

        public static void WriteSystemInfo(String info)
        {
            //false is overwrite - create if not exists!
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Application.StartupPath + "\\info.txt", false))
            {
                file.WriteLine(info);
            }
        }

        public static void WriteAllSoftware(String program)
        {
            //false is overwrite - create if not exists!
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(Application.StartupPath + "\\info.txt", true))
            {
                file.WriteLine(program);
            }
        }

        public static void DeleteLogs()
        {
            try
            {
                //Directory.EnumerateFiles is not available in .NET 2.0
                string[] files = Directory.GetFiles(Application.StartupPath,"*.txt");

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
