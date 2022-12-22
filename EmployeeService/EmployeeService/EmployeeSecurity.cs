using EmployeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService
{
    public class EmployeeSecurity
    {
        public static bool Login(string username,string password)
        {
            using (EmployeeDBEntities db=new EmployeeDBEntities())
            {
                return db.Users.Any(users=>users.Username.Equals(username, 
                    StringComparison.OrdinalIgnoreCase)&&
                    users.Password==password);
            }
        }
    }
}