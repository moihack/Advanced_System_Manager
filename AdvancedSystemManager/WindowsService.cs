using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    class WindowsService
    {
        public String DisplayName { get; }
        public String ServiceName { get; }
        public int StartType { get; }
        public String Status { get; }

        public WindowsService(String dispName,String serName,int start,String status)
        {
            this.DisplayName = dispName;
            this.ServiceName = serName;
            this.StartType = start;
            this.Status = status;
        }
    }
}
