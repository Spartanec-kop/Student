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
using StudentData.Infrastructure.Business;
using StudentData.Infrastructure.Data;
using StudentData.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentData.Domain.Interfaces;
using StudentData.Domain.Core;
using Newtonsoft.Json;
using StudentData.Api;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using StudentData.Infrastructure.Business.Security;

namespace StudentData
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
            services.AddDbContext<StudentContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString(nameof(StudentContext))));

            services.AddTransient<IStudentsServices, StudentsServices>();
            services.AddTransient<IGroupsServices, GroupsServices>();
            services.AddTransient<IStudentGroupServices, StudentGroupServices>();
            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IRepository<Group>, GroupRepository>();
            services.AddTransient<IStudentGroupRepository, StudentGroupRepository>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddControllers();
            // added CORS
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = AuthOptions.GetTokenParameters();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Adjusted CORS
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            JsonConvert.DefaultSettings = () => ApiSettings.DefaultJsonSerializerSettings;
        }
    }
}
