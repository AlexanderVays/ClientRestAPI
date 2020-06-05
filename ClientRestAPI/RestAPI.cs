using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestAPI
{
    public enum httpEnum
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestAPI
    {
        public string endPoint { get; set; }
        public httpEnum httpMethod { get; set; }

        public RestAPI() 
        {
            endPoint = string.Empty;
            httpMethod = httpEnum.GET;
        }

        public string MakeRequest() 
        {
            string strResponse = string.Empty;
            //performing URI check

            if (Uri.IsWellFormedUriString(endPoint, UriKind.Absolute) && (endPoint.StartsWith("http") || endPoint.StartsWith("https")))
            {
                WebRequest request = WebRequest.Create(endPoint);
                request.Method = httpMethod.ToString();

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("Error: " + response.StatusCode.ToString());
                    }

                    //process the response stream (could be JSON, XML, HTML, etc)
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader streamReader = new StreamReader(responseStream))
                            {
                                strResponse = streamReader.ReadToEnd();
                            } // end of StreamReader
                        }
                    } //end of using responseStream
                } // end of using response
                
            } else
            {
                strResponse = "Fail: invalid input URI string";
            }
            return strResponse;
        }
    }
}
