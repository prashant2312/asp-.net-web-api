using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace learn.Controllers
{
    [BasicAutherization]
    public class EmployeeController : ApiController
    {
        web_api_crud_dbEntities db=new web_api_crud_dbEntities();
        [HttpGet]
        public HttpResponseMessage GetAllEmp()
        {
            var emp = db.Employees.ToList();
            if (emp != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, emp);
                return response;
            }
            else 
            { 
            return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

        [HttpGet]
        public HttpResponseMessage EmployeeById(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK,db.Employees.FirstOrDefault(e=>e.id==id));
            return response;
        }
        [HttpGet]
        public IHttpActionResult EmployeeByGender(string gender = "all")
        {
            var genders = gender.ToLower();
            switch (genders)
            {
                case "female":
                    var data = db.Employees.Where(e => e.gender == "female");
                    return Ok(data);

                case "male":
                    var datas = db.Employees.Where(e => e.gender == "male");
                    return Ok(datas);
                default:
                    return Ok(db.Employees.ToList());
            }
        }

        [HttpPost]
        public HttpResponseMessage PostEmployee([FromBody] Employee e)
        {
            db.Employees.Add(e);
            db.SaveChangesAsync().Wait();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult UpdateData(int id, [FromBody]Employee emp)
        {
            var data = db.Employees.FirstOrDefault(e => e.id == id);
            if (data != null)
            {
                data.designation=emp.designation;
                data.gender=emp.gender;
                data.age = emp.age;
                data.name=emp.name;
                data.salary=emp.salary;
                db.SaveChanges();
                var message = "Data save successfully";
                return Ok(message);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var data = db.Employees.FirstOrDefault(e => e.id == id);
            if (data != null)
            {
                db.Employees.Remove(data);
                db.SaveChangesAsync().Wait();
                return Ok();

            }
            else
            {
                return NotFound();
            }
        }

    }
}
