using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OnlineUserModule
{
    public class OnlineUserConfigurationSection:ConfigurationSection
    {
        [ConfigurationProperty("period",DefaultValue="10000",IsRequired=true, IsKey=false)]
        public long Period {
            get {
                return (long)this["period"];
            }
        }

        [ConfigurationProperty("dueTime", DefaultValue = "60000", IsRequired = true, IsKey = false)]
        [LongValidator(MinValue=1000,MaxValue=1000000,ExcludeRange=false)]
        public long DueTime
        {
            get
            {
                return (long)this["dueTime"];
            }
        }

        [ConfigurationProperty("timeout", DefaultValue = "10000", IsRequired = true, IsKey = false)]
        [IntegerValidator(MinValue=1000,MaxValue=1000000,ExcludeRange=false)]
        public int Timeout
        {
            get
            {
                return (int)this["timeout"]/1000;
            }
        }
    }
}