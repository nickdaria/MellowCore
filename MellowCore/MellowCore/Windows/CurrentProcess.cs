using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Reflection;

namespace MellowCore.Windows
{
    /// <summary>
    /// Functions involving the application's host process
    /// </summary>
    public class CurrentProcess
    {
        /// <summary>
        /// Checks if the executing user is an Admin
        /// </summary>
        /// <returns>Boolean. True = Admin</returns>
        public static bool IsAdmin()
        {
            var stat = (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);

            if (stat) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Gets the name of the application running MellowCore
        /// </summary>
        /// <returns>Application Name as string</returns>
        public static string GetCallingExecutableName()
        {
            return Assembly.GetCallingAssembly().GetName().Name.ToString();
        }
    }
}
