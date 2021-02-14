using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoStandardProject.Data;
using DemoStandardProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoStandardProject
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
            services.AddHttpContextAccessor();
            services.AddResponseCaching();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                //    builder.WithExposedHeaders("totalAmountRecords");
                //    builder.WithExposedHeaders("totalAmountPages");
                //    builder.WithExposedHeaders("currentPage");
                //    builder.WithExposedHeaders("recordsPerPage");
            }));

            services.AddHealthChecks().AddDbContextCheck<AppDBContext>(tags: new[] { "ready" });

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<AppDBContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductGroupService, ProductGroupService>();
            services.AddScoped<IProductStockLogService, ProductStockLogService>();
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
