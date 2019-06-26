using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MellowCore.Web
{
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

            //  Create WebClient and begin download. Does not use Async thread
            using (var webClient = new System.Net.WebClient())
            {
                return webClient.DownloadString(WebLocation).ToString();
            }
        }
    }
}
