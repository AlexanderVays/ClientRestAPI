using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ClientRestAPI
{
    class ResponseController : ApiController
    {
        public List<string> Get()
        {
            List<string> list = new List<string>();
            list.Add("Alex");
            list.Add("Anton");
            list.Add("Andrew");
            return list;
        }
    }
}
