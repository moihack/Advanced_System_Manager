using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using Microsoft.Win32;
namespace AdvancedSystemManager
{
    class ServiceManager
    {
        public static List<WindowsService> servicesList = new List<WindowsService>();
        public static void GetServices()
        {
            // get list of Windows services
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController service in services)
            {              
                try
                {                    
                    RegistryKey regKey1 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services\\" + service.ServiceName);
                    String imgPath = regKey1.GetValue("ImagePath").ToString();

                    String desc = regKey1.GetValue("Description","noDescription").ToString(); //exception fix

                    int startType =  Convert.ToInt32(regKey1.GetValue("Start"));

                    regKey1.Close();

                    //do not add system services to the list
                    if (!(imgPath.Contains("System32") || imgPath.Contains("system32") || imgPath.Contains("Microsoft") || imgPath.Contains("Windows")))
                    {
                        WindowsService winServ = new WindowsService(service.DisplayName, service.ServiceName, startType, service.Status.ToString());
                        servicesList.Add(winServ);
                    }
                }
                catch (Exception ex)
                {
                    MyLogger.WriteErrorLog("Exception occured while getting list of services....");
                    MyLogger.WriteErrorLog("service: " + service.DisplayName);
                    MyLogger.WriteErrorLog(ex.Message);

                }
            }   
        }
    }
}
