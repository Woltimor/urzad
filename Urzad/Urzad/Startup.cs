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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Urzad.Data.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Urzad.Repository;
using Urzad.Services;
using Urzad.Repositories;

namespace Urzad
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

            services.AddDbContext<UrzadPracyContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddScoped<IPersonalAtributesRep, PersonalAtributesRep>();
            services.AddScoped<IPersonalAtributesServ,PersonalAtributesServ>();
            services.AddScoped<IOffersRep, OffersRep>();
            services.AddScoped<IOffersServ, OffersServ>();
            services.AddScoped<ILoginRep, LoginRep>();
            services.AddScoped<ILoginServ, LoginServ>();
            services.AddScoped<IManagementRep, ManagementRep>();
            services.AddScoped<IManagementServ, ManagementServ>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
