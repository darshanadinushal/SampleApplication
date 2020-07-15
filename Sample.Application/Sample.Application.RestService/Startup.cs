using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Application.RestService.Business;
using Sample.Application.RestService.Service.Common;
using Sample.Application.RestService.Service.DBModel;
using Sample.Application.RestService.Service.Repository;
using Sample.Application.RestService.Shared;

namespace Sample.Application.RestService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });


            services.AddDbContext<UpworkdbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("UpworkdbContext"),
                     sqlOptions =>
                     {
                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
                         maxRetryDelay: TimeSpan.FromSeconds(3),
                         errorNumbersToAdd: null);
                     }));

            //Managers
            services.AddScoped<IDepartmentManager, DepartmentManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();

            services.AddSingleton<IEntityMapper, EntityMapper>();

            //Repositoty
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
