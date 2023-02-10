using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace learn.Controllers
{
    public class StudentV2Controller : ApiController
    {
        //[Route("api/student/v2")]
        public IHttpActionResult Get()
        {
            StudentV1Controller.students.Add(new Student() { Id = 2, Name = "Roman" });
            return Ok(StudentV1Controller.students);
        }

        [Route("api/student/v2/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            StudentV1Controller.students.Add(new Student() { Id = 3, Name = "Roman" });

            return Ok(StudentV1Controller.students.Where(e=>e.Id==id).FirstOrDefault());
        }

        [Route("api/student/v2/{gender:alpha}")]
        public IHttpActionResult Get(string gender)
        {
            StudentV1Controller.students.Add(new Student() { Id = 2, Name = "Roman" });

            return Ok(StudentV1Controller.students.Where(e => e.Name.ToLower() == gender));
        }
    }
}
