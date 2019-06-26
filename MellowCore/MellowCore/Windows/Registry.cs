using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MellowCore.Windows
{
    /// <summary>
    /// Interaction with the Windows Registry Key
    /// </summary>
    public class Registry
    {
        /// <summary>
        /// Initialize Registry Key at Current User/Software/AppName
        /// </summary>
        public static RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\" + MellowCore.Windows.CurrentProcess.GetCallingExecutableName());

        /// <summary>
        /// Returns RegistryKey object at app location for further use
        /// </summary>
        /// <returns>RegistryKey object</returns>
        public static RegistryKey GetRegistryKeyObject()
        {
            return rk;
        }

        /// <summary>
        /// Quickly get path to application registry as a string
        /// </summary>
        /// <returns>Path as string</returns>
        public static string GetRegistryPath()
        {
            return rk.ToString();
        }

        /// <summary>
        /// Fetch registry value from application registry key
        /// </summary>
        /// <param name="KeyName">Key name as string to fetch</param>
        /// <returns>Dynamic value of registry object, null if nonexistent</returns>
        public static dynamic GetRegistryValue(string KeyName)
        {
            try { return rk.GetValue(KeyName); }
            catch (Exception e) { return e; }
        }

        /// <summary>
        /// Set registry value from application registry key
        /// </summary>
        /// <param name="KeyName">Key name as string to set</param>
        /// <param name="KeyValue">Value to assign to key</param>
        /// <returns>Dynamic value of registry object, null if unable to modify</returns>
        public static dynamic SetRegistryValue(string KeyName, dynamic KeyValue)
        {
            try { return rk.SetValue(KeyName, KeyValue); }
            catch (Exception e) { return e; }
        }

        /// <summary>
        /// Delete registry value from application registry key
        /// </summary>
        /// <param name="KeyName">Key name as string to delete</param>
        /// <returns>True if successful, error if failed</returns>
        public static dynamic DeleteRegistryValue(string KeyName)
        {
            try
            {
                rk.DeleteValue(KeyName);
                return true;
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}
