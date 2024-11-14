using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    /// <summary>
    /// 系统API类型
    /// </summary>
    public class SystemMetricsType
    {
        public const int SM_CXSCREEN = 0;//屏幕宽度
        public const int SM_CYSCREEN = 1;//屏幕高度
        public const int SM_CXVSCROLL = 2;//垂直滚动条的宽度
        public const int SM_CYHSCROLL = 3;//水平滚动条的宽度
        public const int SM_CYCAPTION = 4;//Height of windows caption 实际标题高度加上SM_CYBORDER
        public const int SM_CXBORDER = 5;//Width of no-sizable borders 无法测量的窗口框架宽度
        public const int SM_CYBORDER = 6;//Height of non-sizable borders 无法测量的窗口框架高度
        public const int SM_CXDLGFRAME = 7;//Width of dialog box borders
        public const int SM_CYDLGFRAME = 8;//Height of dialog box borders
        public const int SM_CYHTHUMB = 9;//Height of scroll box on horizontal scroll bar 水平滚动条上滑块的高度
        public const int SM_CXHTHUMB = 10;// Width of scroll box on horizontal scroll bar 水平滚动条上滑块的宽度
        public const int SM_CXICON = 11;//Width of standard icon 图标宽度
        public const int SM_CYICON = 12;//Height of standard icon 图标高度
        public const int SM_CXCURSOR = 13;//Width of standard cursor 光标宽度
        public const int SM_CYCURSOR = 14;//Height of standard cursor 光标高度
        public const int SM_CYMENU = 15;//Height of menu 以像素计算的单个菜单条的高度
        public const int SM_CXFULLSCREEN = 16;//Width of client area of maximized window
        public const int SM_CYFULLSCREEN = 17;//Height of client area of maximized window
        public const int SM_CYKANJIWINDOW = 18;//Height of Kanji window
        public const int SM_MOUSEPRESENT = 19;//True is a mouse is present 如果为TRUE或不为0的值则安装了鼠标，否则没有安装。
        public const int SM_CYVSCROLL = 20;//Height of arrow in vertical scroll bar
        public const int SM_CXHSCROLL = 21;//Width of arrow in vertical scroll bar
        public const int SM_DEBUG = 22;//True if deugging version of windows is running
        public const int SM_SWAPBUTTON = 23;//True if left and right buttons are swapped.
        public const int SM_CXMIN = 28;//Minimum width of window
        public const int SM_CYMIN = 29;//Minimum height of window
        public const int SM_CXSIZE = 30;//Width of title bar bitmaps
        public const int SM_CYSIZE = 31;//height of title bar bitmaps
        public const int SM_CXMINTRACK = 34;//Minimum tracking width of window
        public const int SM_CYMINTRACK = 35;//Minimum tracking height of window
        public const int SM_CXDOUBLECLK = 36;//double click width
        public const int SM_CYDOUBLECLK = 37;//double click height
        public const int SM_CXICONSPACING = 38;//width between desktop icons
        public const int SM_CYICONSPACING = 39;//height between desktop icons
        public const int SM_MENUDROPALIGNMENT = 40;//Zero if popup menus are aligned to the left of the memu bar item. True if it is aligned to the right.
        public const int SM_PENWINDOWS = 41;//The handle of the pen windows DLL if loaded.
        public const int SM_DBCSENABLED = 42;//True if double byte characteds are enabled
        public const int SM_CMOUSEBUTTONS = 43;//Number of mouse buttons.
        public const int SM_CMETRICS = 44;//Number of system metrics
        public const int SM_CLEANBOOT = 67;//Windows 95 boot mode. 0 = normal; 1 = safe; 2 = safe with network
        public const int SM_CXMAXIMIZED = 61;//default width of win95 maximised window
        public const int SM_CXMAXTRACK = 59;//maximum width when resizing win95 windows
        public const int SM_CXMENUCHECK = 71;//width of menu checkmark bitmap
        public const int SM_CXMENUSIZE = 54;//width of button on menu bar
        public const int SM_CXMINIMIZED = 57;//width of rectangle into which minimised windows must fit.
        public const int SM_CYMAXIMIZED = 62;//default height of win95 maximised window
        public const int SM_CYMAXTRACK = 60;//maximum width when resizing win95 windows
        public const int SM_CYMENUCHECK = 72;//height of menu checkmark bitmap
        public const int SM_CYMENUSIZE = 55;//height of button on menu bar
        public const int SM_CYMINIMIZED = 58;//height of rectangle into which minimised windows must fit.
        public const int SM_CYSMCAPTION = 51;//height of windows 95 small caption
        public const int SM_MIDEASTENABLED = 74;//Hebrw and Arabic enabled for windows 95
        public const int SM_NETWORK = 63;//bit o is set if a network is present.
        public const int SM_SECURE = 44;//True if security is present on windows 95 system
        public const int SM_SLOWMACHINE = 73;//true if machine is too slow to run win95.
    }
}
