using Sample.Application.RestService.Shared;
using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Business
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            try
            {
                var returnObject = _employeeRepository.GetEmployeeList();

                return returnObject;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool SaveEmployee(Employee employee)
        {
            try
            {
                if (employee.Id >0)
                {
                    var returnObject = _employeeRepository.UpdateEmployee(employee);
                    return returnObject;
                }
                else
                {
                    var returnObject = _employeeRepository.AddEmployee(employee);
                    return returnObject;
                }
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool DeleteEmployee(int empId)
        {
            try
            {
                if (empId > 0)
                {
                      return _employeeRepository.DeleteEmployee(empId);
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
