using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExceptionHandling.Repository;
using ExceptionHandling.Models;
using ExceptionHandling;
namespace ExceptionHandling.Controllers
{

    public class EmployeeController : ApiController
    {
        EmployeeRepo repository = new EmployeeRepo();
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<EmployeeModels> empList = repository.Get();
            if (empList == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }          
            
            return Ok(empList);
        }

        [HttpGet]
        [ExceptionHandling.Filters.NotFound]
        public IHttpActionResult Get(int id)
        {
            EmployeeModels employee = repository.Get(id);
            if (employee == null)
            {
                //For more control over the response unlike the above Get method, you can also construct the entire response message
                //and include it along with the HttpResponseException
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No employee found with the id :{0}", id)),
                    ReasonPhrase = "Employee Id not found",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new KeyNotFoundException();
            }
            else
            {
                return Ok(employee);
            }
        }
    }
}
