using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    internal class StartupItem
    {
        internal String Name { set; get; }
        internal String Command { set; get; }
        internal Boolean IsEnabled { set; get; }
        internal String Location { set; get; }

        internal StartupItem(string argname,string cmd,bool state,string loc)
        {
            this.Name = argname;
            this.Command = cmd;
            this.IsEnabled = state;
            this.Location = loc;
        }
    }
}
