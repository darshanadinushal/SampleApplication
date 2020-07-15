using Sample.Application.RestService.Service.DBModel;
using Sample.Application.RestService.Shared;
using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Business
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> GetDepartmentList()
        {
            try
            {
                var returnObject = _departmentRepository.GetDepartmentList();

                return returnObject;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
