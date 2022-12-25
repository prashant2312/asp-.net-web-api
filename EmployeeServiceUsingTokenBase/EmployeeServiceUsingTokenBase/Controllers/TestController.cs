using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeServiceUsingTokenBase.Controllers
{
    public class TestController : ApiController
    {
        public string Get()
        {
            return "Hello from test";
        }
    }
}
