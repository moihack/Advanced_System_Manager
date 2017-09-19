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

            //args[0] always exists and is the app.exe full path
            if(arguments.Length > 0 && arguments.Length < 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                ArgumentsParser.ParseArguments(arguments);
            }
        }
    }
}
