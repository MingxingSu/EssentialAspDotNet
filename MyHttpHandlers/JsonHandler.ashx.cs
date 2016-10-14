using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHttpHandlers
{
    /// <summary>
    /// Summary description for JsonHandler
    /// </summary>
    public class JsonHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var type = typeof(Result);

            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer
                    = new System.Runtime.Serialization.Json.DataContractJsonSerializer(type);

            serializer.WriteObject(context.Response.OutputStream, new Result());
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public class Result
        {

            public int Percent
            {
                get;
                set;
            }
        }
    }
}