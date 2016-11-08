using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestApp.WebApp.Core.Extensions;
using TestApp.WebApp.Core.Logging;

namespace TestApp.WebApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var contentRootPath = env.ContentRootPath;

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appSettings.json");

            Configuration = configBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IFileService fileService)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddFile(Configuration["LogConfig:LogFilePath"], fileService, LogLevel.Error);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
