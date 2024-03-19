using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    class loginBL
    {
        public string username;
        public string password;
        public string role;

        public loginBL(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public loginBL(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public bool isOwner()
        {
            if (role == "Owner" || role == "owner")
            {
                return true;
            }
            return false;
        }
        public bool isCustomer()
        {
            if (role == "Customer" || role == "customer")
            {
                return true;
            }
            return false;
        }

    }
}