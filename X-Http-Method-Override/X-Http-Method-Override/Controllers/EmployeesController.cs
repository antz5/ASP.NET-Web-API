using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using X_Http_Method_Override.Helpers;
using X_Http_Method_Override.Models;

namespace X_Http_Method_Override.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            return EmployeesHelper.All();
        }

        [HttpGet]
        public Employee GetEmployee(int id)
        {
            return EmployeesHelper.Single(id);
        }

        [HttpPost]
        public HttpResponseMessage Add([FromBody]Employee employee)
        {
            int count = EmployeesHelper.empList.Count;
            var httpresponse = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            EmployeesHelper.empList.Add(employee);
            if(EmployeesHelper.empList.Count > count)
            {
                httpresponse.Content = new StringContent("Employee was added successfully");
            }
            else
            {
                httpresponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                httpresponse.Content = new StringContent("There was an error while creating a new employee");
            }

            return httpresponse;

        }

        [HttpPut]
        public IHttpActionResult Modify(int id, [FromBody]Employee employee)
        {
            var httpresponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            var emp = EmployeesHelper.Modify(employee);
            if (emp == null)
            {
                httpresponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return Ok(httpresponse);
            }            
                return Ok(emp);
        }

        [HttpPost]
        [ActionName("DeleteEmployee")]
        public void DeleteEmployee(int id)
        {
            var httpresponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            EmployeesHelper.Delete(id);
            
        }

    }
}
