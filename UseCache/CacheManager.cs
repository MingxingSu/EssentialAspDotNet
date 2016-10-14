using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UseCache
{
    public class CacheManager
    {
        public static HttpContext ContextInstance
        {
            get;
            set;
        }
        public static  string Message 
        {
            get 
            {
                // No page, thus can use this.Context
                HttpContext context = HttpContext.Current;

                //get from cache firstly
                string message = context.Cache["Message"] as string;

                //not exists in cache
                if (message == null) 
                {
                    string path = context.Server.MapPath("~/TextFile.txt");
                    message = System.IO.File.ReadAllText(path);

                    context.Cache.Add("Message",
                        message,
                        new System.Web.Caching.CacheDependency(path),
                        System.Web.Caching.Cache.NoAbsoluteExpiration,
                        new TimeSpan(1, 0, 0),
                        System.Web.Caching.CacheItemPriority.Normal,
                        CacheCallback);
                }

                return message;
            }

        }

        private static void CacheCallback(string key,
            object value,
            System.Web.Caching.CacheItemRemovedReason reason) 
        {
            //No context, thus use 
            ContextInstance.Response.Write("Cached expired: key:" + key + ", value:" + value.ToString()+",reason:" + reason.ToString()); 
        }



    }
}