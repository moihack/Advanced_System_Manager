using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    static class CastConverts
    {
        public static Int64 StringToInt64(String castingString)
        {
            Int64 retVal = 0;
            retVal = Int64.Parse(castingString);
            return retVal;
        }
    }
}
