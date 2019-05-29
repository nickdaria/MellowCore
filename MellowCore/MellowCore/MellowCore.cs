using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Net;
using Microsoft.Win32;

namespace MellowCore
{
    public class Core
    {
        public static string GetMellowCoreVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static string GetCallingExecutableName()
        {
            return Assembly.GetCallingAssembly().GetName().Name.ToString();
        }
    }

    public class CurrentProcess
    {
        //  Detect if currently being run as administrator
        public static bool IsAdmin()
        {
            var stat = (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);

            if(stat) { return true; }
            else { return false; }
        }
    }

    public class FileInteraction
    {
        
    }

    public class RegistryInteraction
    {
        //  Initialize Registry Object At Current User/Software/AppName
        public static RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\" + Core.GetCallingExecutableName());

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

    public class ConversionTools
    {
        public static Uri StringToURI(string Url)
        {
            return new Uri(Url);
        }
    }

    public class WebInterface
    {
        //  Async File Download Function that accepts String or Uri input; returns null if input is incorrect
        public static WebClient DownloadFile(dynamic URL, string DownloadLocation)
        {
            //  Parse Input to accept type string or type Uri
            dynamic WebLocation;
            if (URL is string) { WebLocation = URL; }
            else if (URL is Uri) { WebLocation = new System.Uri(URL); }
            else { return null; }

            //  Create WebClient and begin Async download. Return WebClient to calling application 
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileAsync(WebLocation, DownloadLocation);
                return wc;
            }
        }

        //  Function that fetches string from the web. Currently not an async method, but I will implement one if need be.
        public static string DownloadString(dynamic URL)
        {
            //  Parse Input to accept type string or type Uri
            dynamic WebLocation;
            if (URL is string) { WebLocation = URL; }
            else if (URL is Uri) { WebLocation = new System.Uri(URL); }
            else { return null; }

            //  Create WebClient and begin download. Does not use Async 
            using (var webClient = new System.Net.WebClient())
            {
                return webClient.DownloadString(WebLocation).ToString();
            }
        }
    }
}
