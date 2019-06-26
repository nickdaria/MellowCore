using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace MellowCore.Windows
{
    /// <summary>
    /// Functions pertaining to the Windows operating system
    /// </summary>
    public class WinInterface
    {
        /// <summary>
        /// Fetches the username of the current user
        /// </summary>
        /// <returns>Windows Username as string</returns>
        public static string GetWindowsUserName()
        {
            return WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// Fetches PC Name of machine
        /// </summary>
        /// <returns>PC Name as string</returns>
        public static string GetPCName()
        {
            return Environment.MachineName;
        }
    }
}
