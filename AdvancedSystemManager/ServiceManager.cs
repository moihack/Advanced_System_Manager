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
                    //String serviceName = service.ServiceName;
                    
                    RegistryKey regKey1 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services\\" + service.ServiceName);
                    String imgPath = regKey1.GetValue("ImagePath").ToString();
                    //String desc = "";
                    String desc = regKey1.GetValue("Description","noDescription").ToString(); //fix exception
                    //Console.WriteLine(imgPath);
                    int startType =  Convert.ToInt32(regKey1.GetValue("Start"));
                    //int serviceType = Convert.ToInt32(regKey1.GetValue("Type"));
                    //Console.WriteLine(serviceType);
                    regKey1.Close();
                    //Console.WriteLine(service.DisplayName + " " + service.Status.ToString());

                    if (!(imgPath.Contains("System32") || imgPath.Contains("system32") || imgPath.Contains("Microsoft") || imgPath.Contains("Windows")))
                    //{
                    //if (service.DisplayName.Contains("Driver"))
                    //if (!  (    (imgPath.Contains("Microsoft")) || (imgPath.Contains("svchost.exe"))      )     )
                   // if(serviceType==1 || serviceType==2 || serviceType == 4)
                    {
                        //Console.WriteLine(service.DisplayName);
                        WindowsService winServ = new WindowsService(service.DisplayName, service.ServiceName, startType, service.Status.ToString());
                        servicesList.Add(winServ);
                        //servicesList.Add(winServ); //for gridview not fitting form scrollbar test
                    }
                   // }

                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " exception occured for " + service.DisplayName);
                }                                                                        
            }   
        }
    }
}
