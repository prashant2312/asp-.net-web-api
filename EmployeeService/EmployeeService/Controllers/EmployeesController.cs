using EmployeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeService.Controllers
{
    [EnableCorsAttribute("*","*","*")]
    public class EmployeesController : ApiController
    {
        
        [HttpGet]
        [BasicAuthentication]
        public HttpResponseMessage LoadAllEmployee(string gender="All")
        {
            string username=Thread.CurrentPrincipal.Identity.Name;
            using (EmployeeDBEntities entities=new EmployeeDBEntities())
            {
                switch (username.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK,entities.Employees.ToList());

                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e=>e.Gender=="male").ToList());

                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e=>e.Gender=="female").ToList());

                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                        break;
                }
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadIdEmp(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var entity= entities.Employees.FirstOrDefault(e=>e.ID==id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id " + id + " not found");
                }
            }
        }

        
        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri, employee.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return message;
            }
        }


        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    var entity = db.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id =" + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        db.Employees.Remove(entity);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        public HttpResponseMessage Put([FromUri]int id, [FromUri]Employee employee) 
        {
            try
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    var entity = db.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Salary = employee.Salary;
                        entity.Gender = employee.Gender;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                
            }
        }

    }
}
