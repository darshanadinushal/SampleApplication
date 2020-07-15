using AutoMapper;
using Sample.Application.RestService.Service.DBModel;
using Sample.Application.RestService.Shared;
using Sample.Application.RestService.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Application.RestService.Service.Common
{
    public class EntityMapper : IEntityMapper
    {

        private MapperConfiguration _config;


        private IMapper _mapper;

        public EntityMapper()
        {
            Configure();
            Create();
        }

        private void Configure()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TblEmployee, Employee>()
                .ForMember(t => t.DepartmentId, m => m.MapFrom(u => u.DepartmentId))
                .ReverseMap();

                cfg.CreateMap<TblDepartment, Department>().ReverseMap();
            });
        }

        private void Create()
        {
            _mapper = _config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
