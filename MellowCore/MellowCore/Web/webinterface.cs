using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MellowCore.Web
{
    /// <summary>
    /// Collections of functions to fetch files and strings from the internet
    /// </summary>
    public class WebInterface
    {
        /// <summary>
        /// Async File Download Function that accepts String or Uri input; returns null if input is incorrect
        /// </summary>
        /// <param name="URL">URL to file to download</param>
        /// <param name="DownloadLocation">Path to save download to when complete</param>
        /// <returns>Returns WebClient object once download is started for tracking progress and attaching events</returns>
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

        /// <summary>
        /// Fetches string from the web. Not asyncronous
        /// </summary>
        /// <param name="URL">URL to fetch string from</param>
        /// <returns>String fetched</returns>
        public static string DownloadString(dynamic URL)
        {
            //  Parse Input to accept type string or type Uri
            dynamic WebLocation;
            if (URL is string) { WebLocation = URL; }
            else if (URL is Uri) { WebLocation = new System.Uri(URL); }
            else { return null; }

            //  Create WebClient and begin download. Does not use Async thread
            using (var webClient = new System.Net.WebClient())
            {
                return webClient.DownloadString(WebLocation).ToString();
            }
        }
    }
}
