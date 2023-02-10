using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace learn.Controllers
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class StudentV1Controller : ApiController
    {
       public static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Prashant" },
           new Student(){ Id=2,Name="Rajat"} };
        //[Route("api/student/v1")]
        public IHttpActionResult Get()
        {
            return Ok(students);
        }
    }
}
