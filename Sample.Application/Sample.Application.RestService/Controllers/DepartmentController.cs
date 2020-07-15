using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.RestService.Service.DBModel;
using Sample.Application.RestService.Shared;
using Sample.Application.RestService.Shared.Model;

namespace Sample.Application.RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentManager _departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            try
            {
                var result = _departmentManager.GetDepartmentList();

                return result;
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}
