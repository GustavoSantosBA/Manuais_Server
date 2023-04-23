using Manuais_Data.Context;
using Manuais_Data.Repositories.Interfaces;
using Manuais_Data.Repositories.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manuais_Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string server = "135.148.95.246";
            string dataBase = "mc_manuais";
            string user = "megacontrol";
            string password = "Gc40012114@";

            services.AddControllers(
                options => options.MaxIAsyncEnumerableBufferLimit = 100000000
            );
            services.AddDbContext<ManuaisContext>(options =>
            {
                string conn = Configuration.GetConnectionString("MySql");
                options.UseMySQL(conn);
            }, ServiceLifetime.Transient);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manuais_Application", Version = "v1" });
            });

            services.AddSignalR(options =>
            {
                options.MaximumReceiveMessageSize = 9999999;
                options.EnableDetailedErrors = true;
            });

            services.AddScoped<IManuaisRepository, ManuaisRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manuais_Application v1"));
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
