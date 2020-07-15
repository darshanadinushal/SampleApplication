using Sample.Application.RestService.Service.DBModel;
using Sample.Application.RestService.Shared;
using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Service.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UpworkdbContext _upworkdbContext;

        private readonly IEntityMapper _entityMapper;

        public DepartmentRepository(UpworkdbContext upworkdbContext, IEntityMapper entityMapper)
        {
            _upworkdbContext = upworkdbContext;
            _entityMapper = entityMapper;
        }


        public IEnumerable<Department> GetDepartmentList()
        {
            try
            {
                var returnObj = _upworkdbContext.TblDepartment.ToList();

               return _entityMapper.Map<IList<TblDepartment>, List<Department>>(returnObj);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
