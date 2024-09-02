using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kurtosys
{
    public class APITest
    {
        [Fact]
        public void CheckStatusResponseTimeAndServerTest()
        {
            string URI = "https://www.kurtosys.com/";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URI);
            httpWebRequest.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

        }
    }
}
