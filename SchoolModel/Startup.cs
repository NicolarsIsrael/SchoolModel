﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolModel.Data;
using Microsoft.EntityFrameworkCore;
using SchoolModel.Core;
using Microsoft.AspNetCore.Identity;
//using SchoolModel.Areas.Identity.Data;
//using SchoolModel.Services.Contracts;
//using SchoolModel.Services.Implementations;
//using SchoolModel.Data.Implementations;
//using SchoolModel.Data.Contracts;

namespace SchoolModel
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddDbContext<AppDbContext>(options=>
            //options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddDbContext<SchoolContextData>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("SchoolModelContextConnection")));

            services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();
            services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<SchoolContextData>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            //services.AddDbContext<SchoolContext>(options =>
            //       options.UseSqlServer(
            //           context.Configuration.GetConnectionString("SchoolModelContextConnection")));


            services.AddMvc()
                    .AddControllersAsServices();

            
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IStudentDao, StudentDao>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<ICoreDao, CoreDao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
