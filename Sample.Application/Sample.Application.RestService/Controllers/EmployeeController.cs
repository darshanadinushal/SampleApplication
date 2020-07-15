using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.RestService.Shared;
using Sample.Application.RestService.Shared.Model;

namespace Sample.Application.RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpPost]
        public bool Post([FromBody] Employee request)
        {
            try
            {
                var result = _employeeManager.SaveEmployee(request);

                return result;
            }
            catch (System.Exception)
            {
                throw;
            }

        }




        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                var result = _employeeManager.GetEmployeeList();

                return result;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                var result = _employeeManager.DeleteEmployee(id);

                return result;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

    }
}
