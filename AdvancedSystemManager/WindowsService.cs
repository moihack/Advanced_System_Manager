using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    class WindowsService
    {
        internal String DisplayName { get; }
        internal String ServiceName { get; }
        internal int StartType { get; }
        internal String Status { get; }

        internal WindowsService(String dispName,String serName,int start,String status)
        {
            this.DisplayName = dispName;
            this.ServiceName = serName;
            this.StartType = start;
            this.Status = status;
        }
    }
}
