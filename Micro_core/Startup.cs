using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataModels;
using API.General;
using AutoMapper;
using Micro_core.BusinessLayer;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.IBusinessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Micro_core
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
            services.AddAutoMapper(); 
            services.AddDbContext<MicroContext>(options=> 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(
                Configuration=>{
                    Configuration.Filters.Add(typeof(MicroExceptionFilter));
                    Configuration.OutputFormatters.RemoveType<TextOutputFormatter>();
                    Configuration.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                    Configuration.RespectBrowserAcceptHeader = true;
                   
                }
            );

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",new Info{
                    Title = "Micro core", Version = "v1"
                });
            });

            services.AddSingleton<ILoanLayer, LoanLayer>();
            services.AddSingleton<IAkibaLayer, AkibaLayer>();  
            services.AddSingleton<IUserLayer, IApplicationUser>();
            services.AddSingleton<IEmailLayer, EmailLayer>();
            services.AddSingleton<ISetupLayer, SetUpLayer>();
            services.AddSingleton<IFields, FieldLayer>();
            services.AddSingleton<IReport, ReportLayer>();
            services.AddSingleton<IBaseLayer, BaseLayer>();  
            services.AddSingleton<IAuditis, Audits >();
            services.AddSingleton<IPage, PageLayer>();

            Sys.init(services); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=Index}/{id?}");

                    routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });

            });
        }
    }
}
