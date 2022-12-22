using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedBasicAuthenticationWEBAPI.Models
{
    public class UserValidate
    {
        //This method is used to check the user credentials
        public static bool Login(string username, string password)
        {
            UsersBL userBL = new UsersBL();
            var UserLists = userBL.GetUsers();
            Console.WriteLine(UserLists.Any(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password));
            return UserLists.Any(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
        //This method is used to return the User Details
        public static User GetUserDetails(string username, string password)
        {
            UsersBL userBL = new UsersBL();
            return userBL.GetUsers().FirstOrDefault(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
    }
}