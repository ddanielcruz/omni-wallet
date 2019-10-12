using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OmniWallet.Api.Constants;
using OmniWallet.Api.Contracts.Services.Entities;
using OmniWallet.Api.Services.Entities;
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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
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
            
            ConfigureJwtAuth(services);
            ConfigureContainer(services);
        }

        private void ConfigureContainer(IServiceCollection services)
        {
            // Database
            var connectionString = Configuration.GetConnectionString(ConfigurationConstants.ConnectionString);
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString), @"The connection string must not be null.");
            
            services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(connectionString));
            
            // TODO: Pensar em uma maneira melhorar de cadastrar os serviços sem construtor como o UnitOfWork
            // Services/Data
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        private void ConfigureJwtAuth(IServiceCollection services)
        {
            var appSecret = Configuration[ConfigurationConstants.AppSecret];
            var key = Encoding.ASCII.GetBytes(appSecret);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = Configuration[ConfigurationConstants.Environment] != EnvironmentConstants.Development;
                    options.SaveToken = true;
                    
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var unitOfWork = context.HttpContext.RequestServices.GetService<IUnitOfWork>();
                            var userId = int.Parse(context.Principal.FindFirstValue(ClaimTypes.NameIdentifier));
                            var user = await unitOfWork.Usuarios.GetAsync(userId);

                            if (user == null)
                            {
                                // Retorna "Unauthorized" caso o usuário não exista mais 
                                context.Fail("Unauthorized");
                            }
                        }
                    };
                });
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{VersionConstants.V1}/swagger.json", $"OmniWallet.Api ({VersionConstants.V1})"));
        }
    }
}