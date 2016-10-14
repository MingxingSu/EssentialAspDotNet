using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineUserModule
{
    public class OnlineUser
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime ListVisitTime { get; set; }
        public int Count { get; set; }



        //User is checking in, notify check-in manager
        public delegate void CheckInEventHandler(object sender, OnlineUserCheckInEventArgs e);

        public event CheckInEventHandler CheckIn;

        public void OnCheckIn(OnlineUserCheckInEventArgs args)
        {
            if (this.CheckIn != null)
            {
                this.CheckIn(this, args);
            }
        }
    }
}