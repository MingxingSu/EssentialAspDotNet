using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineUserModule
{
    public class OnlineUserCheckInEventArgs:EventArgs
    {

        public OnlineUser OnlineUser { get; set; }

        public OnlineUserCheckInEventArgs(OnlineUser onlineUser)
        {
            this.OnlineUser=onlineUser;
        }
     
    }
}