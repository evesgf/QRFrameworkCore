using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySQL.Data.EntityFrameworkCore.Extensions;
using TestAll.Config;
using TestAll.Dao;
using TestAll.Entitys;
using TestAll.Resposity;
using TestAll.Services;

namespace TestAll
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加数据库链接配置
            var dblink = "Data Source=localhost;port=3306;Initial Catalog=TestAll;uid=root;password=;Charset=utf8";
            //services.AddDbContext<TestAllDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("DbLink")));
            services.AddDbContext<TestAllDbContext>(options => options.UseMySQL(dblink));

            //依赖注入
            services.AddTransient<IAppConfigService, AppConfigService>();

            //services.AddTransient<IUserService, UserService>();

            services.AddTransient<IRepository<Sys_User>, TestRepository>();

            //循环依赖注入
            services.AddCommandHandlers(Assembly.GetEntryAssembly());

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //检查数据库
            //new InitDB().InitializeAsync(context);

            //检查数据库
            using (var ser = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ser.ServiceProvider.GetService<TestAllDbContext>().Database.Migrate();
                //ser.ServiceProvider.GetService<TestAllDbContext>().Database.EnsureSeedData();
            }
        }
    }
}
