using System;
using ApexLegendsTeamBuilder.Areas.Identity.Data;
using ApexLegendsTeamBuilder.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ApexLegendsTeamBuilder.Areas.Identity.IdentityHostingStartup))]
namespace ApexLegendsTeamBuilder.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApexDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ApexDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<ApexDbContext>();
            });
        }
    }
}