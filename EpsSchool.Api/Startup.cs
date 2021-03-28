using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using EpsSchool.Domain.Repositories;
using EpsSchool.infra.Repositories;
using EpsSchool.infra.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            // Injeção de Dependencia do Contexto de Banco de Dados.
            services.AddDbContext<SchoolContext>(
                context => context.UseMySql(Configuration.GetConnectionString("MySqlConnection"))
            );

            // Tratando erro de loop infinito no envio do Json.
            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Mapeamento Automatico Para os Dtos - Os Helpers são o meio de campo.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Injeção de Dependencia do Controle com Inversão de Controle.
            // AddScoped cria um DataContext por requisição e reutiliza ele, evitando conexões desnecessárias com o banco.
            // Terminou de utilizar ele destroi o DataContext e fecha a conexão.
            services.AddScoped<IRepository, Repository>();

            // Configurações para escolher e controlar as versões da API.
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

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();

            // Swagger - Utilizado para execução e testes da API.
            services.AddSwaggerGen(options =>
            {
                // Determina uma versão para cada documentação de acordo com a versão informada na api.
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    // Etapa que demonstra quais os passos para documentar o Swagger.
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
                              IApiVersionDescriptionProvider apiProviderDescription) // Injetando os dados de descrição da Versão.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

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

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
