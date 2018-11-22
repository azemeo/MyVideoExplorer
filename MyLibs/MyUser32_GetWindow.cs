using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace MyVideoExplorer
{
    class MyUser32_GetWindow
    {
        // http://www.pinvoke.net/default.aspx/user32.getwindowlong
        const int GWL_HWNDPARENT = (-8);

        const int GWL_ID = (-12);
        const int GWL_STYLE = (-16);
        const int GWL_EXSTYLE = (-20);

        // Window Styles
        const UInt32 WS_OVERLAPPED = 0;
        const UInt32 WS_POPUP = 0x80000000;
        const UInt32 WS_CHILD = 0x40000000;
        const UInt32 WS_MINIMIZE = 0x20000000;
        const UInt32 WS_VISIBLE = 0x10000000;
        const UInt32 WS_DISABLED = 0x8000000;
        const UInt32 WS_CLIPSIBLINGS = 0x4000000;
        const UInt32 WS_CLIPCHILDREN = 0x2000000;
        const UInt32 WS_MAXIMIZE = 0x1000000;
        const UInt32 WS_CAPTION = 0xC00000;      // WS_BORDER or WS_DLGFRAME  
        const UInt32 WS_BORDER = 0x800000;
        const UInt32 WS_DLGFRAME = 0x400000;
        const UInt32 WS_VSCROLL = 0x200000;
        const UInt32 WS_HSCROLL = 0x100000;
        const UInt32 WS_SYSMENU = 0x80000;
        const UInt32 WS_THICKFRAME = 0x40000;
        const UInt32 WS_GROUP = 0x20000;
        const UInt32 WS_TABSTOP = 0x10000;
        const UInt32 WS_MINIMIZEBOX = 0x20000;
        const UInt32 WS_MAXIMIZEBOX = 0x10000;
        const UInt32 WS_TILED = WS_OVERLAPPED;
        const UInt32 WS_ICONIC = WS_MINIMIZE;
        const UInt32 WS_SIZEBOX = WS_THICKFRAME;

        // Extended Window Styles
        const UInt32 WS_EX_DLGMODALFRAME = 0x0001;
        const UInt32 WS_EX_NOPARENTNOTIFY = 0x0004;
        const UInt32 WS_EX_TOPMOST = 0x0008;
        const UInt32 WS_EX_ACCEPTFILES = 0x0010;
        const UInt32 WS_EX_TRANSPARENT = 0x0020;
        const UInt32 WS_EX_MDICHILD = 0x0040;
        const UInt32 WS_EX_TOOLWINDOW = 0x0080;
        const UInt32 WS_EX_WINDOWEDGE = 0x0100;
        const UInt32 WS_EX_CLIENTEDGE = 0x0200;
        const UInt32 WS_EX_CONTEXTHELP = 0x0400;
        const UInt32 WS_EX_RIGHT = 0x1000;
        const UInt32 WS_EX_LEFT = 0x0000;
        const UInt32 WS_EX_RTLREADING = 0x2000;
        const UInt32 WS_EX_LTRREADING = 0x0000;
        const UInt32 WS_EX_LEFTSCROLLBAR = 0x4000;
        const UInt32 WS_EX_RIGHTSCROLLBAR = 0x0000;
        const UInt32 WS_EX_CONTROLPARENT = 0x10000;
        const UInt32 WS_EX_STATICEDGE = 0x20000;
        const UInt32 WS_EX_APPWINDOW = 0x40000;
        const UInt32 WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        const UInt32 WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        const UInt32 WS_EX_LAYERED = 0x00080000;
        const UInt32 WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
        const UInt32 WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
        const UInt32 WS_EX_COMPOSITED = 0x02000000;
        const UInt32 WS_EX_NOACTIVATE = 0x08000000;

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);


        public static bool IsWindowTopMost(IntPtr Handle)
        {
            try 
            { 
                return (GetWindowLong(Handle, GWL_EXSTYLE) & WS_EX_TOPMOST) != 0;
            }
            catch (Exception)
            {
                
            }
            return false;
        }

        public static bool IsHorizontalScrollbarVisible(IntPtr Handle)
        {
            try 
            { 
                return (GetWindowLong(Handle, GWL_STYLE) & WS_HSCROLL) != 0;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public static bool IsVerticalScrollbarVisible(IntPtr Handle)
        {
            try
            {
                return (GetWindowLong(Handle, GWL_STYLE) & WS_VSCROLL) != 0;
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
}
