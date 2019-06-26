using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MellowCore.Web
{
    /// <summary>
    /// Network adapter functions and info
    /// </summary>
    public class Adapter
    {
        /// <summary>
        /// Fetches adapter hostname
        /// </summary>
        /// <returns></returns>
        public static string GetHostname()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// Gets the local IP address from the default adapter
        /// </summary>
        /// <returns>IP Address as string</returns>
        public static string GetLocalIP()
        {
            return Dns.GetHostEntry(GetHostname()).AddressList[0].ToString();
        }
    }
}
