using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Shared
{
    public interface IEmployeeRepository
    {
         bool AddEmployee(Employee employee);

         bool UpdateEmployee(Employee employee);

        IEnumerable<Employee> GetEmployeeList();

        Employee GetEmployeeById(int empId);

        bool DeleteEmployee(int empId);
    }
}
