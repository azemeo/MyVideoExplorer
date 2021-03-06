﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO;

namespace MyVideoExplorer
{
    /// <summary>
    /// intent is to use this to show system icons in file list
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
    }

    class MyFileTypeIcon
    {
        public static System.Drawing.Icon Get(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            IntPtr hImgSmall; //the handle to the system image list
            //IntPtr hImgLarge; //the handle to the system image list
            System.Drawing.Icon fileTypeIcon = null;

            try
            {

                SHFILEINFO shinfo = new SHFILEINFO();

                //Use this to get the small Icon
                hImgSmall = Win32.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);

                //Use this to get the large Icon
                //hImgLarge = SHGetFileInfo(fName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 	Win32.SHGFI_ICON |in32.SHGFI_LARGEICON);

                //The icon is returned in the hIcon member of the shinfo struct
                if (shinfo.hIcon.ToInt32() > 0)
                {
                    fileTypeIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                }
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                fileTypeIcon = null;
            }

            return fileTypeIcon;
        }
    }

	
}
