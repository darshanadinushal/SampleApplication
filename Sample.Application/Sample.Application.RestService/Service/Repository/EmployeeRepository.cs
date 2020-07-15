using Sample.Application.RestService.Service.DBModel;
using Sample.Application.RestService.Shared;
using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Transactions;

namespace Sample.Application.RestService.Service.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly UpworkdbContext _upworkdbContext;

        private readonly IEntityMapper _entityMapper;

        public EmployeeRepository(UpworkdbContext upworkdbContext, IEntityMapper entityMapper)
        {
            _upworkdbContext = upworkdbContext;
            _entityMapper = entityMapper;
        }


        public IEnumerable<Employee> GetEmployeeList()
        {
            try
            {

                var returnObj = _upworkdbContext.TblEmployee
                    .Where(x=>x.IsActive==1)
                    .Join(
                        _upworkdbContext.TblDepartment,
                        emp => emp.DepartmentId,
                        dep => dep.Id,
                        (emp, dep) => new Employee
                        {
                            Id = emp.Id,
                            Address = emp.Address,
                            DepartmentName = dep.Name,
                            DepartmentId=dep.Id,
                            Email=emp.Email,
                            FirstName =emp.FirstName,
                            LastName=emp.LastName,
                            Phone=emp.Phone,
                            Salary= emp.Salary
                        }
                    ).ToList();

                

                return returnObj;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Employee GetEmployeeById(int empId)
        {
            try
            {
                
                var employee = _upworkdbContext.TblEmployee.Where(x=>x.Id== empId).FirstOrDefault();
                if (employee!=null)
                {
                    return _entityMapper.Map<TblEmployee ,Employee>(employee);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


            public bool AddEmployee(Employee employee)
        {
            try
            {
                var tblEmployee =_entityMapper.Map<Employee ,TblEmployee >(employee);
                tblEmployee.CreatedBy = "Admin";
                tblEmployee.ModifitedBy = "Admin";
                tblEmployee.CreatedDate =  DateTime.Now;
                tblEmployee.ModifitedDate = DateTime.Now;
                tblEmployee.IsActive = 1;
                tblEmployee.Department = null;
                _upworkdbContext.TblEmployee.Add(tblEmployee);
                _upworkdbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                var tblEmployee = _entityMapper.Map<Employee, TblEmployee>(employee);
                tblEmployee.CreatedBy = "Admin";
                tblEmployee.ModifitedBy = "Admin";
                tblEmployee.CreatedDate = DateTime.Now;
                tblEmployee.ModifitedDate = DateTime.Now;
                tblEmployee.IsActive = 1;
                tblEmployee.Department = null;
                _upworkdbContext.TblEmployee.Update(tblEmployee);
                _upworkdbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public bool DeleteEmployee(int empId)
        {
            try
            {
                var employee = _upworkdbContext.TblEmployee.Where(x => x.Id == empId).FirstOrDefault();
                if (employee != null)
                {
                    employee.Department = null;
                    employee.IsActive = 0;
                    _upworkdbContext.TblEmployee.Update(employee);
                    _upworkdbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
