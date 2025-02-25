﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    /// <summary>
    /// GetDeviceCaps 的 nidex值
    /// </summary>
    public class DeviceCapsType
    {
        public const int DRIVERVERSION = 0;
        public const int TECHNOLOGY = 2;
        public const int HORZSIZE = 4;//以毫米为单位的显示宽度
        public const int VERTSIZE = 6;//以毫米为单位的显示高度
        public const int HORZRES = 8;
        public const int VERTRES = 10;
        public const int BITSPIXEL = 12;
        public const int PLANES = 14;
        public const int NUMBRUSHES = 16;
        public const int NUMPENS = 18;
        public const int NUMMARKERS = 20;
        public const int NUMFONTS = 22;
        public const int NUMCOLORS = 24;
        public const int PDEVICESIZE = 26;
        public const int CURVECAPS = 28;
        public const int LINECAPS = 30;
        public const int POLYGONALCAPS = 32;
        public const int TEXTCAPS = 34;
        public const int CLIPCAPS = 36;
        public const int RASTERCAPS = 38;
        public const int ASPECTX = 40;
        public const int ASPECTY = 42;
        public const int ASPECTXY = 44;
        public const int SHADEBLENDCAPS = 45;
        public const int LOGPIXELSX = 88;//像素/逻辑英寸（水平）
        public const int LOGPIXELSY = 90; //像素/逻辑英寸（垂直）
        public const int SIZEPALETTE = 104;
        public const int NUMRESERVED = 106;
        public const int COLORRES = 108;
        public const int PHYSICALWIDTH = 110;
        public const int PHYSICALHEIGHT = 111;
        public const int PHYSICALOFFSETX = 112;
        public const int PHYSICALOFFSETY = 113;
        public const int SCALINGFACTORX = 114;
        public const int SCALINGFACTORY = 115;
        public const int VREFRESH = 116;
        public const int DESKTOPVERTRES = 117;//垂直分辨率
        public const int DESKTOPHORZRES = 118;//水平分辨率
        public const int BLTALIGNMENT = 119;
    } 
}
