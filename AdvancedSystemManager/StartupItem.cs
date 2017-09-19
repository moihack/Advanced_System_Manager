using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    public class StartupItem
    {
        public String Name { set; get; }
        public String Command { set; get; }
        public Boolean IsEnabled { set; get; }
        public String Location { set; get; }

        public StartupItem(string argname,string cmd,bool state,string loc)
        {
            this.Name = argname;
            this.Command = cmd;
            this.IsEnabled = state;
            this.Location = loc;
        }
    }
}
