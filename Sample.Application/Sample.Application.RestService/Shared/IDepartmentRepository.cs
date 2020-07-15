using Sample.Application.RestService.Service.DBModel;
using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Shared
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartmentList();
    }
}
