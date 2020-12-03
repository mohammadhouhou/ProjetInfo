using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetInfo.dal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using ProjetInfo.bll.Services;
using ProjetInfo.bll;
using ProjetInfo.bll.Services.DocumentServices;
using ProjetInfo.bll.Services.CourseComponentTypeServices;

namespace ProjetInfo
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
            //InstitutionContext
            services.AddDbContext<InstitutionContext>(opt =>
              opt.UseSqlServer(Configuration.GetConnectionString("RayConnection")));
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IInstitutionService, InstitutionService>();

            //DocumentContext
            services.AddDbContext<DocumentContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("RayConnection")));
            services.AddScoped<IDocumentService, DocumentService>();

            //DocumentDataContext
            services.AddDbContext<DocumentDataContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("RayConnection")));
            services.AddScoped<IDocumentDataService, DocumentDataService>();

            //CourseComponentTypeContext
            services.AddDbContext<CourseComponentTypeContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("RayConnection")));
            services.AddScoped<ICourseComponentTypeService, CourseComponentTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
