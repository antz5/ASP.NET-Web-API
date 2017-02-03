using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ExceptionHandling.Filters
{
    public class NotFound : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is KeyNotFoundException)
            {
                actionExecutedContext.Exception = new Exception("Data not found. Error status code: "+ System.Net.HttpStatusCode.NotFound.ToString());
            }
        }
    }
}