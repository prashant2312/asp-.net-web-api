using learn;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace learn
{
    public class BasicAutherizationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,"User is not autorized");
            }
            else
            {
                 var encrypted = actionContext.Request.Headers.Authorization.Parameter;
                var userpass = Encoding.UTF8.GetString(Convert.FromBase64String(encrypted));
                string[] userPassword = userpass.Split(':');
                string userName = userPassword[0];
                string password = userPassword[1];
                if (Login.Logins(userName, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "User is not autorized");
                }
            

            }
        }
    }
    
    public class Login
    {
       
        public static bool Logins(string username, string password)
        {
        web_api_crud_dbEntities db = new web_api_crud_dbEntities();
            return db.Users.Any(e=>e.username == username && e.password == password);
        }
    }
}