using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxiManagement.BLL.Contracts;
using TaxiManagement.BLL.Implementations;
using TaxiManagement.DataAccess.Context;
using TaxiManagement.DataAccess.Contracts;
using TaxiManagement.DataAccess.Implementations;

namespace TaxiManagement.WebAPI
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
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(IDepotCreateService), typeof(DepotCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDepotGetService), typeof(DepotGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDepotDeleteService), typeof(DepotDeleteService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarCreateService), typeof(CarCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarGetService), typeof(CarGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarUpdateService), typeof(CarUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ICarDeleteService), typeof(CarDeleteService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDriverCreateService), typeof(DriverCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDriverGetService), typeof(DriverGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDriverUpdateService), typeof(DriverUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IDriverDeleteService), typeof(DriverDeleteService), ServiceLifetime.Scoped));
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(IDepotDataAccess), typeof(DepotDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ICarDataAccess), typeof(CarDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IDriverDataAccess), typeof(DriverDataAccess), ServiceLifetime.Transient));
            //DB Context
            services.AddDbContext<TaxiManagementContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("TaxiManagement")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TaxiManagementContext>();
                context.Database.EnsureCreated();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}