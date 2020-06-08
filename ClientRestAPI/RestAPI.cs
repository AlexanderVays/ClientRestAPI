using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestAPI
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestAPI
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestAPI() 
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string MakeRequest() 
        {
            string strResponse = string.Empty;
            //performing URI check

            if (Uri.IsWellFormedUriString(endPoint, UriKind.Absolute) && (endPoint.StartsWith("http") || endPoint.StartsWith("https")))
            {
                WebRequest request = WebRequest.Create(endPoint);
                request.Timeout = 5000; //request timeout limit 5000 millisec (5 sec)
                request.Method = httpMethod.ToString();
                request.ContentType = "application/json";
                try
                {
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
                }
                catch (System.Net.WebException ex) //catch WebException like (401 Unauthorized error)
                {
                    strResponse = ex.Message;
                }
                
            } else
            {
                strResponse = "Fail: invalid input URI string";
            }
            return strResponse;


        /* var request = System.Net.WebRequest.Create(endpoint);
        request.Timeout = 5000;
        request.Method = "GET";
        request.Headers.Add("api-key", "asdf@1234");
        request.Credentials = new NetworkCredential("UserName", "Password");
        request.ContentType = "application/json";
        try
        {
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    textBox1.Text = reader.ReadToEnd();
                }
            }
        }
        catch (System.Net.WebException ex)
        {
            textBox1.Text = ex.Message;
        } */
        }
    }
}
