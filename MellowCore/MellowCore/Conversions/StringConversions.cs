using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MellowCore.Conversions
{
    /// <summary>
    /// Functions to convert strings
    /// </summary>
    public class StringConversions
    {
        /// <summary>
        /// Converts a URL string to a URI object
        /// </summary>
        /// <param name="Url">String of the URL to convert</param>
        /// <returns>URI Object</returns>
        public static Uri ToURI(string Url)
        {
            return new Uri(Url);
        }
    }
}
