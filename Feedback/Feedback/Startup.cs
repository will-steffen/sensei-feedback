using Feedback.Business.Entities;
using Feedback.DataAccess.Entities;
using Feedback.DomainModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Feedback
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("1.0", new Info
                {
                    Title = "SenseiFeedback",
                    Version = "1.0"
                });
            });

            services.AddCors(o => o.AddPolicy("CORS_POLICY_NAME", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<ApplicationContext>();
            services.AddScoped<FeedbackSeasonDataAccess>();
            services.AddScoped<UserDataAccess>();
            services.AddScoped<ProjectDataAccess>();
            services.AddScoped<CompetenceDataAccess>();
            services.AddScoped<FeedbackModelDataAccess>();

            services.AddScoped<UserBusiness>();
            services.AddScoped<MockBusiness>();
            services.AddScoped<CompetenceBusiness>();
            services.AddScoped<FeedbackSeasonBusiness>();
            services.AddScoped<FeedbackModelBusiness>();
            

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            MockBusiness m = serviceProvider.GetService<MockBusiness>();
            m.Mock();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint($"./../swagger/1.0/swagger.json", "SenseiFeedback");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});

            app.UseCors("CORS_POLICY_NAME");

        }
    }
}
