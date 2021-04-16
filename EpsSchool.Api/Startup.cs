using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using EpsSchool.Domain.Repositories;
using EpsSchool.Infra.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EpsSchool.Infra.Repositories;
using EpsSchool.Domain.Handlers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EpsSchool.Api
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
            // Database Context Dependency Injection.
            services.AddDbContext<SchoolContext>(
                context => context.UseMySql(Configuration.GetConnectionString("MySqlConnection"))
            );

            // Handling infinite loop error when sending Json.
            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            //Jwt Authentication.
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Automatic Mapping for Dtos - Helpers are the middle of the process.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Control Dependency Injection with Inversion of Control.
            // AddScoped creates a DataContext per request and reuses it, avoiding unnecessary connections with the database.
            // When he finish the DataContext using, he destroys it and closes the connection.
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentCourseSubjectRepository, StudentCourseSubjectRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<StudentHandler, StudentHandler>();
            services.AddScoped<TeacherHandler, TeacherHandler>();

            // Settings for choosing and controlling API versions.
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            var apiVersionDescriptionProvider = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();

            // Swagger - Used for API documentation, execution and testing.
            services.AddSwaggerGen(options =>
            {
                // Determines a version for each documentation according to the version informed in the api.
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    // Step by step to document the Swagger.
                    options.SwaggerDoc(description.GroupName,
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "EPS School API",
                        Version = description.ApiVersion.ToString(),
                        TermsOfService = new Uri("http://TermosDeUso"),
                        Description = "Web API desenvolvida com o objetivo de demonstar minhas habilidades em C# e nas ferramentas .NET.",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "EPS School License by Creative Commons",
                            Url = new Uri("https://creativecommons.org/licenses/by/4.0")
                        },
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Enrique Souza",
                            Email = "enriquepdsz@gmail.com",
                            Url = new Uri("https://www.linkedin.com/in/enriqueps/")
                        }
                    });
                }

                var xmlCommentFiles = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFiles);

                options.IncludeXmlComments(xmlCommentFullPath);
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              IApiVersionDescriptionProvider apiProviderDescription) // Injecting the version description data.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                    options.RoutePrefix = "";
                });
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
