using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestAPI
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum ResponseFormat
    {
        HTML,
        JSON,
        XML,
    }

    class RestAPI
    {
        public string endPoint { get; set; }
        public static HttpVerb httpMethod { get; set; }
        public static ResponseFormat responseFormat {get; set;}

        public RestAPI() 
        {
            endPoint = string.Empty;
        }

        public string MakeWebRequest() 
        {
            StringBuilder sb = new StringBuilder();
            //performing URI check

            if (Uri.IsWellFormedUriString(endPoint, UriKind.Absolute) && (endPoint.StartsWith("http") || endPoint.StartsWith("https")))
            {
                HttpWebRequest request = WebRequest.Create(endPoint) as HttpWebRequest;
                request.Timeout = 5000; //request timeout limit 5000 millisec (5 sec)
                request.Method = httpMethod.ToString() != null ? httpMethod.ToString() : HttpVerb.GET.ToString(); 
                request.Headers.Add("Key", "Value");
                request.Accept = responseFormat == ResponseFormat.HTML ? $"text/{responseFormat.ToString().ToLower()}" : $"application/{responseFormat.ToString().ToLower()}";
                request.ContentType = responseFormat == ResponseFormat.HTML ? $"text/{responseFormat.ToString().ToLower()}; charset=UTF-8" : $"application/{responseFormat.ToString().ToLower()}; charset=UTF-8"; 
                sb.Append("\r\nRequest Information:\r\n" + "Method: " + request.Method + "\r\nRequestURI: " + request.RequestUri + "\r\nHost Header: " 
                    + request.Host + "\r\nAccept: " + request.Accept + "\r\nContentType: " + request.ContentType + "\r\nTimeout: " + request.Timeout + 
                    "\r\n\r\n");
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
                                    sb.Append("Response Information: \r\n" + streamReader.ReadToEnd());
                                } // end of StreamReader
                            }
                        } //end of using responseStream
                    } // end of using response
                }
                catch (System.Net.WebException ex) //catch WebException like (401 Unauthorized error)
                {
                    return ex.Message;
                }
                
            } else
            {
                return "Fail: invalid input URI string";
            }
            return sb.ToString();

        }

        public string MakeLocalRequest() 
        {
            string strResponse = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost/ClientRestAPI/");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
            HttpResponseMessage response = client.GetAsync("api/Values").Result;  // Blocking call!    
            if (response.IsSuccessStatusCode)
            {
                strResponse = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                strResponse =  $"{(int)response.StatusCode} ({response.ReasonPhrase})";
            }
            return strResponse;
        }
    }
}

