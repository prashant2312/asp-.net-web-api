using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationWEBAPI.Models
{
    public class EmployeeBL
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            for (int i = 1; i <= 10; i++)
            {
                if (i>=5)
                {
                    employees.Add(new Employee()
                    {
                        ID = i,
                        Name = "Name " + i,
                        Gender = "Male",
                        Dept = "IT",
                        Salary = 1000 + i
                    });
                    
                }
                else
                {
                    employees.Add(new Employee()
                    {
                        ID = i,
                        Name = "Name " + i,
                        Gender = "Female",
                        Dept = "HR",
                        Salary = 500 + i
                    });
                }
            }
            return employees;
        }
    }
}