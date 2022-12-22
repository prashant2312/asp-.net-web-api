using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationWEBAPI.Models
{
    public class UsersBL
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User()
            {
                ID = 1,
                UserName="MaleUser",
                Password="123456"
            });
            users.Add(new User()
            {
                ID = 2,
                UserName = "FemaleUser",
                Password = "abcdef"
            });
            return users;
        }
    }
}