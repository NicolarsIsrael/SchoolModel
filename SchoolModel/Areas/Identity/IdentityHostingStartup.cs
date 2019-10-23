using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolModel.Core;
//using SchoolModel.Areas.Identity.Data;
using SchoolModel.Data;

[assembly: HostingStartup(typeof(SchoolModel.Areas.Identity.IdentityHostingStartup))]
namespace SchoolModel.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
               

                //services.AddDefaultIdentity<ApplicationUser>()
                //    .AddEntityFrameworkStores<SchoolContextData>();
            });
        }
    }
}