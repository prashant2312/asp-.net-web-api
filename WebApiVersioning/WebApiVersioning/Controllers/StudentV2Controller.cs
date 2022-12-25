using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiVersioning.Models;

namespace WebApiVersioning.Controllers
{
    public class StudentV2Controller : ApiController
    {
        List<StudentV2> students = new List<StudentV2>()
        {
            new StudentV2(){Id = 1, FirstName = "Prashant",LastName="Joshi"},
            new StudentV2(){Id = 2, FirstName = "Kane",LastName="Demon"},
            new StudentV2(){Id = 3, FirstName = "Undertaker",LastName="Kane"}
        };

        //[Route("api/v2/students")]
        public IEnumerable<StudentV2> Get()
        {
            return students;
        }

        //[Route("api/v2/students/{id}")]
        public StudentV2 Get(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }
    }
}
