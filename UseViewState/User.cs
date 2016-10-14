using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UseViewState
{
    [Serializable]
    public class User
    {
        public User(string userName) 
        {
            this._userName = userName;
        }

        string _userName = string.Empty;

        public string UserName {

            get { return _userName; }
            private set {

                value = "Hello," + value;
                _userName = value;
            }
        }

        public string Email
        {
            get;
            set;
        }
    }
}