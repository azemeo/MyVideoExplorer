using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management; // add via Project -> Add Reference

namespace MyVideoExplorer
{
    class MyWin32_OperatingSystem
    {

        /*
        http://msdn.microsoft.com/en-us/library/aa394239%28v=vs.85%29.aspx
        [Provider("CIMWin32")]class Win32_OperatingSystem : CIM_OperatingSystem
        {
          string   BootDevice;
          string   BuildNumber;
          string   BuildType;
          string   Caption;
          string   CodeSet;
          string   CountryCode;
          string   CreationClassName;
          string   CSCreationClassName;
          string   CSDVersion;
          string   CSName;
          sint16   CurrentTimeZone;
          boolean  DataExecutionPrevention_Available;
          boolean  DataExecutionPrevention_32BitApplications;
          boolean  DataExecutionPrevention_Drivers;
          uint8    DataExecutionPrevention_SupportPolicy;
          boolean  Debug;
          string   Description;
          boolean  Distributed;
          uint32   EncryptionLevel;
          uint8    ForegroundApplicationBoost;
          uint64   FreePhysicalMemory;
          uint64   FreeSpaceInPagingFiles;
          uint64   FreeVirtualMemory;
          datetime InstallDate;
          uint32   LargeSystemCache;
          datetime LastBootUpTime;
          datetime LocalDateTime;
          string   Locale;
          string   Manufacturer;
          uint32   MaxNumberOfProcesses;
          uint64   MaxProcessMemorySize;
          string   MUILanguages[];
          string   Name;
          uint32   NumberOfLicensedUsers;
          uint32   NumberOfProcesses;
          uint32   NumberOfUsers;
          uint32   OperatingSystemSKU;
          string   Organization;
          string   OSArchitecture;
          uint32   OSLanguage;
          uint32   OSProductSuite;
          uint16   OSType;
          string   OtherTypeDescription;
          Boolean  PAEEnabled;
          string   PlusProductID;
          string   PlusVersionNumber;
          boolean  PortableOperatingSystem;
          boolean  Primary;
          uint32   ProductType;
          string   RegisteredUser;
          string   SerialNumber;
          uint16   ServicePackMajorVersion;
          uint16   ServicePackMinorVersion;
          uint64   SizeStoredInPagingFiles;
          string   Status;
          uint32   SuiteMask;
          string   SystemDevice;
          string   SystemDirectory;
          string   SystemDrive;
          uint64   TotalSwapSpaceSize;
          uint64   TotalVirtualMemorySize;
          uint64   TotalVisibleMemorySize;
          string   Version;
          string   WindowsDirectory;
        };
         */
        public static long Get(string param)
        {
            long ret = -1;



            ObjectQuery winQuery = new ObjectQuery("SELECT " + param + " FROM Win32_OperatingSystem");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);
            foreach (ManagementObject item in searcher.Get())
            {
                var val = item[param];
                if (val != null)
                {
                    ret = Convert.ToInt64(val);
                }
            }

            if (ret > 0)
            {
                // convert value to bytes, if needed
                switch (param)
                {
                    case "FreePhysicalMemory":
                    case "TotalVisibleMemorySize":
                        ret *= 1024;
                        break;
                }
            }
            return ret;
        }
    }
}
