using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestApp.DAL;
using Microsoft.EntityFrameworkCore;
using TestApp.DAL.Infrastructure;
using TestApp.DAL.Repositrories;
using TestApp.Service;
using TestApp.ServiceContracts;

namespace TestApp.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var contentRootPath = env.ContentRootPath;

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = configBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestAppContext>(options =>
               options.UseSqlServer(Configuration["ConnectionStrings:TestAppDatabase"]));

            // DI
            services.AddScoped(typeof(IRepository<>), typeof (GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
