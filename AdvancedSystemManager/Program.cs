using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MyLogger.DeleteLogs();

            string[] arguments = Environment.GetCommandLineArgs();
            //Console.WriteLine(arguments.Length);
            //args[0] always exists and is the app.exe full path
            if(arguments.Length > 0 && arguments.Length < 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                //Console.WriteLine(arguments[1]);
                // Console.WriteLine("test");
                // System.Threading.Thread.Sleep(5000);
                ArgumentsParser.ParseArguments(arguments);
            }
        }
    }
}
