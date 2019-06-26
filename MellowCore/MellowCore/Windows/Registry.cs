using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MellowCore.Windows
{
    public class Registry
    {
        //  Initialize Registry Object At Current User/Software/AppName
        public static RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\" + MellowCore.MellowCoreTools.GetCallingExecutableName());

        //  Retrieve RegistryKey value for application to use
        public static RegistryKey GetRegistryKeyObject()
        {
            return rk;
        }

        //  Quickly get path to application registry as a string
        public static string GetRegistryPath()
        {
            return rk.ToString();
        }

        //  Retrieve Registry Value, Returns null if Object does not exist
        public static dynamic GetRegistryValue(string KeyName)
        {
            try { return rk.GetValue(KeyName); }
            catch (Exception e) { return e; }
        }

        //  Set Registry Value
        public static dynamic SetRegistryValue(string KeyName, dynamic KeyValue)
        {
            try { return rk.SetValue(KeyName, KeyValue); }
            catch (Exception e) { return e; }
        }

        //  Delete Registry Value, Returns true if successful, error if unsuccessful
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
