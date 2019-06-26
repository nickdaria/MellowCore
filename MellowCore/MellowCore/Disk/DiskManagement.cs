using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Management;

namespace MellowCore.Disk
{
    /// <summary>
    /// Disk and drive management functions
    /// </summary>
    public class DiskManagement
    {
        /// <summary>
        /// Converts DriveInfo to readable string for listings
        /// </summary>
        /// <returns>List of type string containing readable partition info</returns>
        public static List<string> GetDrivesAsFormattedStrings()
        {
            List<DriveInfo> drives = GetDriveInfoAsList();
            List<string> formatted = null;
            foreach(DriveInfo d in drives)
            {
                string driveName = d.Name;
                string driveLetter = d.VolumeLabel;
                string driveFormat = d.DriveFormat;
                formatted.Add(driveLetter + " | " + driveName + " | " + driveFormat);
            }
            return formatted;
        }

        /// <summary>
        /// Converts DriveInfo array to DriveInfo list for application use
        /// </summary>
        /// <returns>List of type DriveInfo</returns>
        public static List<DriveInfo> GetDriveInfoAsList()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<DriveInfo> driveList = null;
            foreach (DriveInfo d in drives)
            {
                driveList.Add(d);
            }
            return driveList;
        }
    }
}
