using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Shared
{
    public interface IEmployeeManager
    {
        IEnumerable<Employee> GetEmployeeList();

        bool SaveEmployee(Employee employee);

        bool DeleteEmployee(int empId);
    }
}
