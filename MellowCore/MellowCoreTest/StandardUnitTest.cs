using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MellowCoreTest
{
    [TestClass]
    public class StandardUnitTest
    {
        [TestMethod]
        public void GetCallingExecutableName()
        {
            string Expected = "MellowCoreTest";
            var Result = MellowCore.MellowCoreTools.GetCallingExecutableName();
            Assert.AreEqual(Expected, Result);
        }

        [TestMethod]
        public void StringToURI()
        {
            string Input = "http://google.com";
            Uri Expected = new Uri(Input);
            Uri Result = MellowCore.ConversionTools.StringToURI(Input);
            Assert.AreEqual(Expected, Result);
        }

        
        [TestMethod]
        public void StringDownload()
        {
            string Expected = "Success";
            string Result = MellowCore.WebInterface.DownloadString("https://gist.githubusercontent.com/nickdaria/5ed516e7c55131f613909340c9f1afbc/raw/14b1ff50fe0f067f2a66e46b1075b95551034a10/success.txt");
            Assert.AreEqual(Expected, Result);
        }
    }
}
