using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UseSqlCacheDependency
{
    public class Users
    {
        public Users() { }
        public Int64 ID { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}