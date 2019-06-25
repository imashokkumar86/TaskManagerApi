using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagerApi
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
      services.AddCors(); // Make sure you call this previous to AddMvc
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IManageParentTaskDetails, ManageParentTaskDetails>();
            
            services.AddTransient<IManageTask, ManageTask>();           
          
     
            //Configuring database connection
            ConfigOtherServices(services);
        }
       
        public virtual void ConfigOtherServices(IServiceCollection services)
        {

       
      ServiceConfig.Config(services, Configuration);
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
      app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials());
      //      app.UseCors(
      //  options => options.WithOrigins("http://localhost:5000/").AllowAnyHeader().AllowAnyMethod()
      //);
      //app.UseHttpsRedirection();
      app.UseMvc();
        }
    }
}
