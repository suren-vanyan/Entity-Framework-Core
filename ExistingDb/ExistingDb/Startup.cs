using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingDb.Models.Scaffold;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExistingDb
{
    public class Startup
    {
        public Startup(IConfiguration config) => Configuration = config;
        public IConfiguration Configuration { get; set; }


        public void ConfigureServices(IServiceCollection services)
        {
            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ZoomShoesDbContext>(options =>
            options.UseSqlServer(conString));

            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
