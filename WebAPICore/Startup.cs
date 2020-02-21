using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPICore.Model.DBContext;
using WebAPICore.Repository.Repository.Abstract;
using WebAPICore.Repository.Repository.Concrete;

namespace WebAPICore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddDbContext<APIDBContext>(options => options.UseSqlServer("Data Source=DESKTOP-VLLFDE5\\SQLEXPRESS;Initial Catalog=APIDB;Integrated Security=True;"));
            

            //Now register our services with Autofac container
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.Register(c =>

            {
                var config = c.Resolve<IConfiguration>();

                var opt = new DbContextOptionsBuilder<APIDBContext>();
                opt.UseSqlServer("Data Source=DESKTOP-VLLFDE5\\SQLEXPRESS;Initial Catalog=APIDB;Integrated Security=True;");

                return new APIDBContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();
            builder.Populate(services);

            var container = builder.Build();
            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
