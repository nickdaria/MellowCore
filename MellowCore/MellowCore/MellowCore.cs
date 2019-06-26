using System.Reflection;

namespace MellowCore.Library
{
    /// <summary>
    /// MellowCore Library version information and update checking
    /// </summary>
    public class Versioning
    {
        /// <summary>
        /// Fetches the current running version of MellowCore
        /// </summary>
        /// <returns>MellowCore Version as string</returns>
        public static string GetMellowCoreVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}