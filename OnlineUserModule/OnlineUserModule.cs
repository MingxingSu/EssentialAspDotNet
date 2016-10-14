using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineUserModule
{
    public class OnlineUserModule:IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += new EventHandler(Application_PostAuthenticateRequest);
        }

        
        void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            string userId =request.IsAuthenticated ?
                context.User.Identity.Name :
                context.Request.AnonymousID;
            
            OnlineUser onlineUser= new OnlineUser();
            if (context.User == null)
            {
                return;
            }

            var identity = context.User.Identity;

            onlineUser.ID = userId;
            if (identity.IsAuthenticated)
            {
                onlineUser.Name = identity.Name;
            }
            else 
            {
                onlineUser.Name = "匿名";
            }
            onlineUser.ListVisitTime = DateTime.Now;
            onlineUser.Count = 1;


            OnlineUserManager manager = context.Application[OnlineUserManager.ApplicationKey] as OnlineUserManager;

            bool isRegistered = true;
            if (manager.Register(onlineUser) == isRegistered) 
            {
            }

            //触发事件
            OnlineUserCheckInEventArgs args = new OnlineUserCheckInEventArgs(onlineUser);
            onlineUser.OnCheckIn(args);


        }

        private void OnUserCheckIn(OnlineUserCheckInEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}