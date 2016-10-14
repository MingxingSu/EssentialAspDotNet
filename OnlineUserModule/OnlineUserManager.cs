using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace OnlineUserModule
{
    public class OnlineUserManager
    {
        public static readonly string ApplicationKey = "ApplicationKey";

        private Dictionary<string, OnlineUser> onlineUserDict;
        private System.Threading.Timer timer;
        public OnlineUserManager() 
        {
            onlineUserDict = new Dictionary<string, OnlineUser>();
            timer = new System.Threading.Timer(TimerCallback,
                null,
                section.DueTime,
                section.Period);

            //Register User check-in event

            
        }

        public static OnlineUserManager Current 
        {
            get {
                return HttpContext.Current.Application[ApplicationKey] as OnlineUserManager;
            }
        }

        private static OnlineUserConfigurationSection section = HttpContext.Current.GetSection("OnlineUser")
                                                                as OnlineUserConfigurationSection;

        private void TimerCallback(object state)
        {
            lock (this.onlineUserDict) 
            {
                string[] keys = new string[this.onlineUserDict.Count];
                this.onlineUserDict.Keys.CopyTo(keys, 0);

                //过期则移除
                DateTime now = DateTime.Now;
                TimeSpan timeout = new TimeSpan(0, 0, section.Timeout);
                foreach (var key in keys) {
                    if ((now - this.onlineUserDict[key].ListVisitTime) > timeout)
                    {
                        this.onlineUserDict.Remove(key);
                    }
                }
            }
        }

        public bool Register(OnlineUser user)
        {
            bool isNew = true;
            lock (this.onlineUserDict)
            {
                if (onlineUserDict.ContainsKey(user.Name))
                {
                    OnlineUser existsUser = this.onlineUserDict[user.Name];
                    existsUser.Count += 1;
                    isNew= false;
                }
                else
                {
                    onlineUserDict.Add(user.Name, user);
                                        
                    user.CheckIn += OnlineUserManager_CheckIn;
                }
            }
            return isNew;
        }
        public int TotalOnlineUserCount { get; private set; }

        private void OnlineUserManager_CheckIn(object sender, OnlineUserCheckInEventArgs e)
        {
            lock (this.onlineUserDict)
            {
                OnlineUser user = sender as OnlineUser;
                if (onlineUserDict.ContainsKey(user.Name) == false)
                {
                    TotalOnlineUserCount++;
                }
            }
        }
    }
}