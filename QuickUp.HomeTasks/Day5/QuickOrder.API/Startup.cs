using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuickOrder.DAL;
using QuickOrder.DAL.Infrastructure;
using QuickOrder.Entities;
using QuickOrder.Services;
using QuickOrder.Services.Contracts;

namespace QuickOrder.API
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QuickOrderContext>(
                options => options.UseSqlServer(Configuration["ConnectionStrings:TestAppDatabase"]));

            services.AddIdentity<User, Role>(opt =>
                {
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<QuickOrderContext, int>()
                .AddDefaultTokenProviders();

            // DI DAL
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IEntityBaseRepository<>), typeof(IEntityBaseRepository<>));

            // DI Services
            services.AddScoped<IProductService, ProductService>();
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

            app.UseIdentity();

            app.UseMvc();
        }
    }
}
