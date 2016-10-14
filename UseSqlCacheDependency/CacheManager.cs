using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace UseSqlCacheDependency
{
    public class CacheManager
    {
        public static List<Users> Users 
        {
            get {

                HttpContext context = HttpContext.Current;

                var list = context.Cache["Users"] as List<Users>;

                if (list == null) 
                {
                    string conntionString = ConfigurationManager.ConnectionStrings["TestSqlDependencyConnectionString"].ConnectionString;

                    string sql = "select ID,UserName, Age from dbo.Users ";

                    //Execute Reader to get data from DB, and construct user list;
                    using (var conn = new SqlConnection(conntionString)) 
                    {
                        conn.Open();
                        using (var command = new SqlCommand(sql, conn))
                        {
                            var reader = command.ExecuteReader();
                            list = new List<Users>();
                            while (reader.Read()) 
                            {
                                list.Add(new Users()
                                {
                                    ID =reader.GetInt64(0),
                                    UserName=reader.GetString(1),
                                    Age = reader.GetInt32(2)

                                });
                            }
                        }
                    }
                    //Save to caches

                    SqlCacheDependency userDep = new SqlCacheDependency("TestSqlDependency", "Users");
                    SqlCacheDependency roleDep = new SqlCacheDependency("TestSqlDependency", "Roles");

                    var acd = new AggregateCacheDependency();
                    acd.Add(userDep, roleDep);

                    context.Cache.Add("Users",
                        list,
                        acd,
                        Cache.NoAbsoluteExpiration,
                        new TimeSpan(1, 0, 0),
                        CacheItemPriority.Normal,
                        new CacheItemRemovedCallback(CacheCallback));
                
                }

                return list;
            
            }


        }

        private static void CacheCallback(string key,
    object value,
    System.Web.Caching.CacheItemRemovedReason reason)
        {
            //No context, thus use 
            //ContextInstance.Response.Write("Cached expired: key:" + key + ", value:" + value.ToString() + ",reason:" + reason.ToString());
        }


    }
}