using AttributeRouting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AttributeRouting.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){Id=1,Name="Prashant"},
            new Student(){Id=2,Name="Kane"},
            new Student(){Id=3,Name="Roman"}
        };
        //[Route("~/api/teachers")]
        //public IEnumerable<Teacher> GetTeachers()
        //{
        //    List<Teacher> teachers = new List<Teacher>()
        //    {
        //        new Teacher(){Id=1,Name="Roman"},
        //        new Teacher(){Id=2,Name="Sohan"},
        //        new Teacher(){Id=3,Name="Mohan"},
        //    };
        //    return teachers;
        //}

        //[Route("")]
        //public IEnumerable<Student> Get()
        //{
        //    return students;
        //}

        //[Route("{id:range(1,3)}",Name ="GetStudentById")]
        //public Student Get(int id)
        //{
        //    return students.FirstOrDefault(e => e.Id == id);
        //}

        //[Route("{name:alpha}")]
        //public Student Get(string name)
        //{
        //    return students.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        //}


        //[Route("{id}/courses")]
        //public IEnumerable<string> GetStudentCourses(int id)
        //{
        //    if (id == 1)
        //    {
        //        return new List<string>() { "C#","Java","Python"};
        //    }
        //    else if (id == 2)
        //    {
        //        return new List<string>() { "English", "Hindi", "Python" };
        //    }
        //    else 
        //    {
        //        return new List<string>() { "Math","Angular","C#" };
        //    }
        //}

        [Route("{id:int}", Name = "GetStudentById")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }


        public HttpResponseMessage Post(Student student)
        {
            //students.Add(s);
            //var response= Request.CreateResponse(HttpStatusCode.Created);
            ////response.Headers.Location = new Uri(Request.RequestUri + s.Id.ToString());
            //response.Headers.Location = new Uri(Url.Link("GetStudentById", new { id = s.Id }));
            //return response;


            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new
                Uri(Url.Link("GetStudentById", new { id = student.Id }));
            return response;
        }
    }
}
