using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiVersioning.Models;

namespace WebApiVersioning.Controllers
{
    
    public class StudentV1Controller : ApiController
    {
        List<StudentV1> students=new List<StudentV1>()
        {
            new StudentV1(){Id = 1, Name = "Prashant"},
            new StudentV1(){Id = 2, Name = "Kane"},
            new StudentV1(){Id = 3, Name = "Undertaker"}
        };

        //[Route("api/v1/students")]
        public IEnumerable<StudentV1> Get()
        {
            return students;
        }

        //[Route("api/v1/students/{id}")]
        public StudentV1 Get(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }
    }
}
