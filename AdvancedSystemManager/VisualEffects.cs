using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AdvancedSystemManager
{
    public class VisualEffects
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, bool pvParam, uint fWinIni);

        //https://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx

        //private static UInt32 SPI_SETUIEFFECTS = 0x103F;
        //private static UInt32 SPI_SETFONTSMOOTHING = 0x004b;

        //private static UInt32 SPI_SETMENUFADE = 0x1013;

        //Show shadows under windows
        private static UInt32 SPI_SETDROPSHADOW = 0x1025;

        //private static UInt32 SPI_SETFONTSMOOTHING = 0x004B;

        private static UInt32 SPI_SETMENUFADE = 0x1013;

        private static UInt32 SPI_SETCOMBOBOXANIMATION = 0x1005;
        private static UInt32 SPI_SETCURSORSHADOW = 0x101B;
        private static UInt32 SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007;
        private static UInt32 SPI_SETMENUANIMATION = 0x1003;
        private static UInt32 SPI_SETSELECTIONFADE = 0x1015;
        private static UInt32 SPI_SETTOOLTIPANIMATION = 0x1017;
        private static UInt32 SPI_SETTOOLTIPFADE = 0x1019;
        //private static UInt32

        //private static UInt32 SPI_GETDROPSHADOW = 0x1024;

        public static void ApplySettings()
        {
            SystemParametersInfo(SPI_SETDROPSHADOW, 0, false, 0);
            //SystemParametersInfo(SPI_SETFONTSMOOTHING, 0, false, 0); //helps in the eye though
//
            SystemParametersInfo(SPI_SETMENUFADE, 0, false, 0);
            SystemParametersInfo(SPI_SETCOMBOBOXANIMATION, 0, false, 0);
            SystemParametersInfo(SPI_SETCURSORSHADOW, 0, false, 0);
            SystemParametersInfo(SPI_SETLISTBOXSMOOTHSCROLLING, 0, false, 0);
            SystemParametersInfo(SPI_SETMENUANIMATION, 0, false, 0);
            SystemParametersInfo(SPI_SETSELECTIONFADE, 0, false, 0);
            SystemParametersInfo(SPI_SETTOOLTIPANIMATION, 0, false, 0);
            SystemParametersInfo(SPI_SETTOOLTIPFADE, 0, false, 0);

            SystemParametersInfo(SPI_SETMENUFADE, 0, false, 0);
            //SystemParametersInfo(SPI_SETUIEFFECTS, 0, false, 0);
            //SystemParametersInfo(SPI_SETFONTSMOOTHING, 0, false, 0);
        }
    }

}
