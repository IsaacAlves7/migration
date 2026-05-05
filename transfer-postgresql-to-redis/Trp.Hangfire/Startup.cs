using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trp.Domain;
using Trp.Jobs;
using Trp.Service;
using Trp.Service.Cache;
using Trp.Service.Interface;

namespace Trp.Hangfire
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
            services.AddEntityFrameworkNpgsql().AddDbContext<TrpDbContext>(opt =>
            opt.UseNpgsql(Configuration.GetConnectionString("ConnectionString")));

            RedisCacheOptions options = new();
            var section = Configuration.GetSection("Redis");
            section.Bind(options);

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = options.Configuration;
                option.InstanceName = options.InstanceName;
            });

            services.AddScoped<ITransfer, Transfer>()
            .AddScoped<IRedisCacheService, RedisCacheService>()
            .AddSingleton<RedisCacheOptions>(options);


            services.AddControllers();
            services.AddHangfire(x => x.UsePostgreSqlStorage(Configuration.GetConnectionString("ConnectionStringHanfigre")));
            services.AddHangfireServer();
            services.AddMvc(Options => Options.EnableEndpointRouting = false);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            RecurringJobs.RecurringJobList();

            app.UseHangfireDashboard();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
