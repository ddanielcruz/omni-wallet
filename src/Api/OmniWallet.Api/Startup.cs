using System;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OmniWallet.Api.Constants;
using OmniWallet.Api.Contracts.Services.Data;
using OmniWallet.Api.Services.Data;
using OmniWallet.Database.Contracts.Persistence;
using OmniWallet.Database.Persistence;

namespace OmniWallet.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = false;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });
            
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(conf =>
            {
                conf.SwaggerDoc(VersionConstants.V1, new OpenApiInfo
                {
                    Title = $"OmniWallet.Api ({VersionConstants.V1})",
                    Version = VersionConstants.V1,
                    Description = "API utilizada para realizar a comunicação entre o sistema web e o aplicativo.",
                    Contact = new OpenApiContact
                    {
                        Name = "Daniel Cunha",
                        Url = new Uri("https://www.linkedin.com/in/daniel-cunha-53053816b/"),
                        Email = "danielcunha54@gmail.com"
                    }
                });
            });
            
            ConfigureContainer(services);
        }

        private void ConfigureContainer(IServiceCollection services)
        {
            // Database
            var connectionString = Configuration.GetConnectionString("Default");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "The connection string must not be null.");
            
            services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(connectionString));
            
            // Services/Data
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{VersionConstants.V1}/swagger.json", $"OmniWallet.Api ({VersionConstants.V1})"));
        }
    }
}